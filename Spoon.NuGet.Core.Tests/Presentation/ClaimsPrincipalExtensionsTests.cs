namespace Spoon.NuGet.Core.Tests.Presentation;

using System.Security.Claims;
using Core.Presentation;

public class ClaimsPrincipalExtensionsTests
{
    [Fact]
    public void GetUserId_ReturnsUserIdFromClaim()
    {
        // Arrange
        var userId = new Guid("12345678-1234-1234-1234-1234567890AB");
        var claim = new Claim(ClaimTypes.NameIdentifier, userId.ToString());
        var principal = new ClaimsPrincipal(new ClaimsIdentity(new[]
        {
            claim,
        }));

        // Act
        var result = principal.GetUserId();

        // Assert
        Assert.Equal(userId, result);
    }

    [Fact]
    public void GetUserId_ReturnsEmptyGuidWhenClaimValueIsInvalid()
    {
        // Arrange
        var invalidClaimValue = "invalid-guid";
        var claim = new Claim(ClaimTypes.NameIdentifier, invalidClaimValue);
        var principal = new ClaimsPrincipal(new ClaimsIdentity(new[]
        {
            claim,
        }));

        // Act
        var result = principal.GetUserId();

        // Assert
        Assert.Equal(Guid.Empty, result);
    }


    [Fact]
    public void GetEmailId_ReturnsEmailIdFromClaim()
    {
        // Arrange
        var emailId = new Guid("11111111-1111-1111-1111-111111111111");
        var claim = new Claim(ClaimTypes.Email, emailId.ToString());
        var principal = new ClaimsPrincipal(new ClaimsIdentity(new[]
        {
            claim,
        }));

        // Act
        var result = principal.GetEmailId();

        // Assert
        Assert.Equal(emailId, result);
    }

    [Fact]
    public void GetIar_ReturnsIatFromClaim()
    {
        // Arrange
        var unixTimeSecond = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var claim = new Claim("Iat", unixTimeSecond.ToString());
        var principal = new ClaimsPrincipal(new ClaimsIdentity(new[]
        {
            claim,
        }));

        // Act
        var result = principal.GetIat();

        // Assert
        Assert.Equal(unixTimeSecond, result);
    }
    
    
    [Fact]
    public void GetSessionId_ReturnsSessionIdFromClaim()
    {
        // Arrange
        var sessionId = new Guid("11111111-1111-1111-1111-111111111111");
        var claim = new Claim("SessionId", sessionId.ToString());
        var principal = new ClaimsPrincipal(new ClaimsIdentity(new[]
        {
            claim,
        }));

        // Act
        var result = principal.GetSessionId();

        // Assert
        Assert.Equal(sessionId, result);
    }    
    // Add more tests for the remaining extension methods

    [Fact]
    public void GetRefreshTokenVerifier_ReturnsRefreshTokenVerifierFromClaim()
    {
        // Arrange
        var refreshTokenVerifier = "abcdefg";
        var claim = new Claim("RefreshTokenVerifier", refreshTokenVerifier);
        var principal = new ClaimsPrincipal(new ClaimsIdentity(new[]
        {
            claim,
        }));

        // Act
        var result = principal.GetRefreshTokenVerifier();

        // Assert
        Assert.Equal(refreshTokenVerifier, result);
    }

    [Fact]
    public void GetRefreshTokenVerifier_ReturnsEmptyStringWhenClaimIsNull()
    {
        // Arrange
        ClaimsPrincipal principal = null;

        // Act
        var result = principal.GetRefreshTokenVerifier();

        // Assert
        Assert.Equal(string.Empty, result);
    }
}