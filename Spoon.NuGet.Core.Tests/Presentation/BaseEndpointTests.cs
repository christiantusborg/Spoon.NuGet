using System.Diagnostics;
using Spoon.NuGet.Core.Presentation;
using Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.MultiLevel;
using Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.MultiLevel.Overwrite;
using Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.Single;
using Spoon.NuGet.Core.Tests.Presentation.BaseCreateEndpoint.Uri.Single.Overwrite;

namespace Spoon.NuGet.Core.Tests.Presentation;

public class BaseEndpointTests
{
    [Theory]
    [InlineData(typeof(MultiGroupControllerV1CreateEndpoint), "/v1/multi/group/controller")]
    [InlineData(typeof(MultiGroupControllerV1UpdateEndpoint), "/v1/multi/group/controller/{groupControllerId}")]
    [InlineData(typeof(MultiGroupControllerV1GetEndpoint), "/v1/multi/group/controller/{groupControllerId}")]
    [InlineData(typeof(MultiGroupControllerV1GetAllEndpoint), "/v1/multi/group/controller")]
    [InlineData(typeof(MultiGroupControllerV1DeleteEndpoint), "/v1/multi/group/controller/{groupControllerId}")]
    [InlineData(typeof(MultiGroupControllerV1DeletePermanentEndpoint),
        "/v1/multi/group/controller/{groupControllerId}/permanent")]
    [InlineData(typeof(MultiGroupControllerV1UnDeleteEndpoint),
        "/v1/multi/group/controller/{groupControllerId}/undelete")]
    [InlineData(typeof(MultiGroupControllerV1UnknownEndpoint), "Unknown action: MultiGroupControllerV1UnknownEndpoint")]
    [InlineData(typeof(SingleV1CreateEndpoint), "/v1/single")]
    [InlineData(typeof(SingleV1UpdateEndpoint), "/v1/single/{singleId}")]
    [InlineData(typeof(SingleV1GetEndpoint), "/v1/single/{singleId}")]
    [InlineData(typeof(SingleV1GetAllEndpoint), "/v1/single")]
    [InlineData(typeof(SingleV1DeleteEndpoint), "/v1/single/{singleId}")]
    [InlineData(typeof(SingleV1DeletePermanentEndpoint), "/v1/single/{singleId}/permanent")]
    [InlineData(typeof(SingleV1UnDeleteEndpoint), "/v1/single/{singleId}/undelete")]
    [InlineData(typeof(SingleV1UnknownEndpoint), "Unknown action: SingleV1UnknownEndpoint")]
    public void GetEndpointName_ReturnsCorrectName(Type classType, string whenSuccess)
    {
        var endpoint = Activator.CreateInstance(classType);

        var result = ((BaseEndpoint)endpoint).GetEndpointName();

        Assert.Equal(whenSuccess, result);
    }


    [Theory]
    [InlineData(typeof(OverwriteV1CreateEndpoint), "v1/something")] // 
    [InlineData(typeof(OverwriteV1GetEndpoint), "v1/something/{advancedId}")]
    [InlineData(typeof(OverwriteV1GetAllEndpoint), "v1/something")]
    [InlineData(typeof(OverwriteV1DeleteEndpoint), "v1/something/{advancedId}")]
    [InlineData(typeof(OverwriteV1DeletePermanentEndpoint), "v1/something/{advancedId}/permanent")]
    [InlineData(typeof(OverwriteV1UnDeleteEndpoint), "v1/something/{advancedId}/undelete")]
    [InlineData(typeof(OverwriteV1UpdateEndpoint), "v1/something/{advancedId}")]
    public void GetEndpointNameOverwrite_ReturnsCorrectUri(Type classType, string whenSuccess)
    {
        var endpoint = Activator.CreateInstance(classType);

        var result = ((BaseEndpoint)endpoint).GetEndpointName();

        Assert.Equal(whenSuccess, result);
    }

    [Theory]
    [InlineData(typeof(MultiGroupControllerV1CreateEndpoint), "Creating a new Controller")]
    [InlineData(typeof(MultiGroupControllerV1UpdateEndpoint), "Update a Controller by id")]
    [InlineData(typeof(MultiGroupControllerV1GetEndpoint), "Get a Controller by id")]
    [InlineData(typeof(MultiGroupControllerV1GetAllEndpoint), "Get Controller by search criteria")]
    [InlineData(typeof(MultiGroupControllerV1DeleteEndpoint), "Delete a Controller by id")]
    [InlineData(typeof(MultiGroupControllerV1DeletePermanentEndpoint), "Permanent delete a Controller by id")]
    [InlineData(typeof(MultiGroupControllerV1UnDeleteEndpoint), "UnDelete a Controller by id")]
    [InlineData(typeof(MultiGroupControllerV1UnknownEndpoint), "Unknown action: MultiGroupControllerV1UnknownEndpoint")]
    [InlineData(typeof(SingleV1CreateEndpoint), "Creating a new Single")]
    [InlineData(typeof(SingleV1UpdateEndpoint), "Update a Single by id")]
    [InlineData(typeof(SingleV1GetEndpoint), "Get a Single by id")]
    [InlineData(typeof(SingleV1GetAllEndpoint), "Get Single by search criteria")]
    [InlineData(typeof(SingleV1DeleteEndpoint), "Delete a Single by id")]
    [InlineData(typeof(SingleV1DeletePermanentEndpoint), "Permanent delete a Single by id")]
    [InlineData(typeof(SingleV1UnDeleteEndpoint), "UnDelete a Single by id")]
    [InlineData(typeof(SingleV1UnknownEndpoint), "Unknown action: SingleV1UnknownEndpoint")]
    public void GetEndpointSummary_ReturnsCorrectSummary(Type classType, string whenSuccess)
    {
        var endpoint = Activator.CreateInstance(classType);


        var result = ((BaseEndpoint)endpoint).GetEndpointSummary();

        Debug.WriteLine(result);
        Assert.Equal(whenSuccess, result);
    }
    
    [Theory]
    [InlineData(typeof(OverwriteV1CreateEndpoint), "Overwrite Summary - Creating a new Base")] // 
    [InlineData(typeof(OverwriteV1GetEndpoint), "Overwrite Summary - Get a new Base")]
    [InlineData(typeof(OverwriteV1GetAllEndpoint), "Overwrite Summary - GetAll a new Base")]
    [InlineData(typeof(OverwriteV1DeleteEndpoint), "Overwrite Summary - Delete a new Base")]
    [InlineData(typeof(OverwriteV1DeletePermanentEndpoint), "Overwrite Summary - DeletePermanent a new Base")]
    [InlineData(typeof(OverwriteV1UnDeleteEndpoint), "Overwrite Summary - UnDelete a new Base")]
    [InlineData(typeof(OverwriteV1UpdateEndpoint), "Overwrite Summary - Update a new Base")]
    [InlineData(typeof(MultiGroupOverwriteV1CreateEndpoint), "Overwrite Summary - Creating a new Base")] // 
    [InlineData(typeof(MultiGroupOverwriteV1GetEndpoint), "Overwrite Summary - Get a new Base")]
    [InlineData(typeof(MultiGroupOverwriteV1GetAllEndpoint), "Overwrite Summary - GetAll a new Base")]
    [InlineData(typeof(MultiGroupOverwriteV1DeleteEndpoint), "Overwrite Summary - Delete a new Base")]
    [InlineData(typeof(MultiGroupOverwriteV1DeletePermanentEndpoint), "Overwrite Summary - DeletePermanent a new Base")]
    [InlineData(typeof(MultiGroupOverwriteV1UnDeleteEndpoint), "Overwrite Summary - UnDelete a new Base")]
    [InlineData(typeof(MultiGroupOverwriteV1UpdateEndpoint), "Overwrite Summary - Update a new Base")]    
    public void GetEndpointNameOverwrite_ReturnsCorrectSummary(Type classType, string whenSuccess)
    {
        var endpoint = Activator.CreateInstance(classType);

        var result = ((BaseEndpoint)endpoint).GetEndpointSummary();

        Assert.Equal(whenSuccess, result);
    }



    [Theory]
    [InlineData(typeof(MultiGroupControllerV1CreateEndpoint), "Creating a new <i>Controller</i>")]
    [InlineData(typeof(MultiGroupControllerV1UpdateEndpoint), "Update a <i>Controller</i> by id")]
    [InlineData(typeof(MultiGroupControllerV1GetEndpoint), "Get a <i>Controller</i> by id")]
    [InlineData(typeof(MultiGroupControllerV1GetAllEndpoint), "Get <i>Controller</i> by search criteria")]
    [InlineData(typeof(MultiGroupControllerV1DeleteEndpoint), "Delete a <i>Controller</i> by id")]
    [InlineData(typeof(MultiGroupControllerV1DeletePermanentEndpoint), "Permanent delete a <i>Controller</i> by id")]
    [InlineData(typeof(MultiGroupControllerV1UnDeleteEndpoint), "UnDelete a <i>Controller</i> by id")]
    [InlineData(typeof(MultiGroupControllerV1UnknownEndpoint), "Unknown action: MultiGroupControllerV1UnknownEndpoint")]
    [InlineData(typeof(SingleV1CreateEndpoint), "Creating a new <i>Single</i>")]
    [InlineData(typeof(SingleV1UpdateEndpoint), "Update a <i>Single</i> by id")]
    [InlineData(typeof(SingleV1GetEndpoint), "Get a <i>Single</i> by id")]
    [InlineData(typeof(SingleV1GetAllEndpoint), "Get <i>Single</i> by search criteria")]
    [InlineData(typeof(SingleV1DeleteEndpoint), "Delete a <i>Single</i> by id")]
    [InlineData(typeof(SingleV1DeletePermanentEndpoint), "Permanent delete a <i>Single</i> by id")]
    [InlineData(typeof(SingleV1UnDeleteEndpoint), "UnDelete a <i>Single</i> by id")]
    [InlineData(typeof(SingleV1UnknownEndpoint), "Unknown action: SingleV1UnknownEndpoint")]
    public void GetEndpointDescription_ReturnsCorrectDescription(Type classType, string whenSuccess)
    {
        var endpoint = Activator.CreateInstance(classType);


        var result = ((BaseEndpoint)endpoint).GetEndpointDescription();


        Assert.Equal(whenSuccess, result);
    }
    
    [Theory]
    [InlineData(typeof(OverwriteV1CreateEndpoint), "Overwrite Description - Creating a new Base")] // 
    [InlineData(typeof(OverwriteV1GetEndpoint), "Overwrite Description - Get a new Base")]
    [InlineData(typeof(OverwriteV1GetAllEndpoint), "Overwrite Description - GetAll a new Base")]
    [InlineData(typeof(OverwriteV1DeleteEndpoint), "Overwrite Description - Delete new Base")]
    [InlineData(typeof(OverwriteV1DeletePermanentEndpoint), "Overwrite Description - DeletePermanent a new Base")]
    [InlineData(typeof(OverwriteV1UnDeleteEndpoint), "Overwrite Description - UnDelete a new Base")]
    [InlineData(typeof(OverwriteV1UpdateEndpoint), "Overwrite Description - Update a new Base")]
    [InlineData(typeof(MultiGroupOverwriteV1CreateEndpoint), "Overwrite Description - Creating a new Base")] // 
    [InlineData(typeof(MultiGroupOverwriteV1GetEndpoint), "Overwrite Description - Get a new Base")]
    [InlineData(typeof(MultiGroupOverwriteV1GetAllEndpoint), "Overwrite Description - GetAll a new Base")]
    [InlineData(typeof(MultiGroupOverwriteV1DeleteEndpoint), "Overwrite Description - Delete new Base")]
    [InlineData(typeof(MultiGroupOverwriteV1DeletePermanentEndpoint), "Overwrite Description - DeletePermanent a new Base")]
    [InlineData(typeof(MultiGroupOverwriteV1UnDeleteEndpoint), "Overwrite Description - UnDelete a new Base")]
    [InlineData(typeof(MultiGroupOverwriteV1UpdateEndpoint), "Overwrite Description - Update a new Base")]    
    public void GetEndpointNameOverwrite_ReturnsCorrectDescription(Type classType, string whenSuccess)
    {
        var endpoint = Activator.CreateInstance(classType);

        var result = ((BaseEndpoint)endpoint).GetEndpointDescription();

        Assert.Equal(whenSuccess, result);
    }
}