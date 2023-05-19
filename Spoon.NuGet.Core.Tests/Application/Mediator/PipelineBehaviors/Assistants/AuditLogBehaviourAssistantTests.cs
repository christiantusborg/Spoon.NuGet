namespace Spoon.NuGet.Core.Tests.Application.Mediator.PipelineBehaviors.Assistants;

using Core.Application.Interfaces;
using Core.Application.Mediator.PipelineBehaviors.AuditLog.Assistants;
using Core.Application.Mediator.PipelineBehaviors.AuditLog.Attributes;
using Core.Application.Mediator.PipelineBehaviors.AuditLog.Interfaces;
using Core.Presentation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Moq;
using NSubstitute;

public class AuditLogBehaviourAssistantTests
{
    private IMockbleDateTime? _mockDateTime;
    private IAuditContextManager? _auditContextManager;
    private IAuditLocationService? _auditLocationService;

    [Fact]
    public void HasPipelineBehaviorAuditLog_ShouldReturnTrueForIPipelineBehaviorAuditLog()
    {
        // Arrange
        var mockRequest = new Mock<IPipelineBehaviorAuditLog>();
        var assistant = this.CreateAssistant();

        // Act
        var result = assistant.HasPipelineBehaviorAuditLog(mockRequest.Object);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HasPipelineBehaviorAuditLog_ShouldReturnFalseForNonIPipelineBehaviorAuditLog()
    {
        // Arrange
        var mockRequest = new Mock<IRequest<string>>();
        var assistant = this.CreateAssistant();

        // Act
        var result = assistant.HasPipelineBehaviorAuditLog(mockRequest.Object);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void HasAuditLogExcludeAttribute_ShouldReturnTrueIfAttributeExists()
    {
        // Arrange
        var assistant = this.CreateAssistant();

        // Act
        var result = assistant.HasAuditLogExcludeAttribute<BaseExcludeAttribute>();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HasAuditLogExcludeAttribute_ShouldReturnFalseIfAttributeDoesNotExist()
    {
        // Arrange
        var assistant = this.CreateAssistant();

        // Act
        var result = assistant.HasAuditLogExcludeAttribute<int>();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetAuditLogTime_Returns_Current_Utc_DateTime()
    {
        var assistant = CreateAssistant();

        // Act
        var result = assistant.GetAuditLogTime();

        // Assert
        Assert.Equal(new DateTime(2000, 1, 1, 0, 0, 0), result);
    }

    [Fact]
    public void GetUserId_Returns_Current_UserId()
    {
        var assistant = CreateAssistant();

        // Act
        var result = assistant.GetUserId();

        // Assert
        Assert.Equal(EndpointExample.ExampleGuid.ToString(), result);
    }    
    
    [Fact]
    public void GetLocation_Returns_Correct_Location()
    {
        var assistant = CreateAssistant();

        // Act
        var result = assistant.GetLocation();

        // Assert
        Assert.Equal("Copenhagen", result);
    }   
    
    [Fact]
    public void GetIpAddress_Returns_Correct_Location()
    {
        var assistant = CreateAssistant();

        // Act
        var result = assistant.GetIpAddress();

        // Assert
        Assert.Equal("127.0.0.1", result);
    }
    
    [Fact]
    public void IIsAuditLogIpAddressAllowed_Returns_Correct()
    {
        var assistant = this.CreateAssistant();

        // Act
        var result = assistant.IsAuditLogIpAddressAllowed();

        // Assert
        Assert.True(result);
    }  
    
    [Fact]
    public void IsAuditLogIpAddressAllowed_Returns_Invalid()
    {
        
        var configurationRoot = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                {
                    "AuditLogPipeline:ExcludeIpAddress", "invalid"
                }, // Valid configuration value
            }!)
            .Build();
        var assistant = CreateAssistant(configurationRoot);

        // Act
        var result = assistant.IsAuditLogIpAddressAllowed();

        // Assert
        Assert.False(result);
    }      
    
    [Fact]
    public void IsAuditLogIpAddressAllowed_Returns_Missing()
    {
        
        var configurationRoot = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>
            {
            }!)
            .Build();
        var assistant = CreateAssistant(configurationRoot);

        // Act
        var result = assistant.IsAuditLogIpAddressAllowed();

        // Assert
        Assert.True(result);
    } 
    
    // ************
    [Fact]
    public void IsAuditLogLocationAllowed_Returns_Correct()
    {
        var assistant = this.CreateAssistant();

        // Act
        var result = assistant.IsAuditLogLocationAllowed();

        // Assert
        Assert.True(result);
    }  
    
    [Fact]
    public void IsAuditLogLocationAllowed_Returns_Invalid()
    {
        
        var configurationRoot = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                {
                    "AuditLogPipeline:LocationAllowed", "invalid"
                }, // Valid configuration value
            }!)
            .Build();
        var assistant = CreateAssistant(configurationRoot);

        // Act
        var result = assistant.IsAuditLogLocationAllowed();

        // Assert
        Assert.False(result);
    }      
    
    [Fact]
    public void IsAuditLogLocationAllowed_Returns_Missing()
    {
        
        var configurationRoot = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>
            {
            }!)
            .Build();
        var assistant = CreateAssistant(configurationRoot);

        // Act
        var result = assistant.IsAuditLogLocationAllowed();

        // Assert
        Assert.True(result);
    }
    // ****
    
    
    
    // Other test methods for the remaining members of AuditLogBehaviourAssistant

    private AuditLogBehaviourAssistant CreateAssistant(IConfigurationRoot? configurationRoot = null)
    {
        this._mockDateTime = Substitute.For<IMockbleDateTime>();
        this._mockDateTime.UtcNow.Returns(new DateTime(2000, 1, 1, 0, 0, 0));

        this._auditContextManager = Substitute.For<IAuditContextManager>();
        this._auditContextManager.GetUserId().Returns(EndpointExample.ExampleGuid.ToString());
        this._auditContextManager.GetIpAddress().Returns("127.0.0.1");

        this._auditLocationService = Substitute.For<IAuditLocationService>();
        this._auditLocationService.GetLocation("127.0.0.1").Returns("Copenhagen");

        if (configurationRoot is null)
        {
            configurationRoot = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>
                {
                    {
                        "AuditLogPipeline:ExcludeIpAddress", "true"
                    }, // Valid configuration value
                    {
                        "AuditLogPipeline:LocationAllowed", "true"
                    },                    
                }!)
                .Build();
        }


        var assistant = new AuditLogBehaviourAssistant(
            this._auditContextManager,
            this._auditLocationService,
            this._mockDateTime,
            configurationRoot);

        return assistant;
    }
}


[AuditLogExclude("Test")]
internal class BaseExcludeAttribute
{
}