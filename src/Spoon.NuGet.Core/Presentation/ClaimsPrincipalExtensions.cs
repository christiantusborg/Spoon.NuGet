namespace Spoon.NuGet.Core.Presentation;

using System.Security.Claims;

/// <summary>
/// Extensions ClaimsPrincipal
/// </summary>
public static class ClaimsPrincipalExtensions
{
    /// <summary>
    ///  Get UserID from ClaimsPrincipal->ClaimTypes.NameIdentifier
    /// </summary>
    /// <param name="principal"></param>
    /// <returns></returns>
    public static Guid GetUserId(this ClaimsPrincipal? principal)
    {
        var claim = principal?.FindFirst(ClaimTypes.NameIdentifier);
        return !Guid.TryParse(claim?.Value, out var userId) ? Guid.Empty : userId;
    }
    
    /// <summary>
    /// Get EmailId from ClaimsPrincipal->ClaimTypes.Email
    /// </summary>
    /// <param name="principal"></param>
    /// <returns></returns>
    public static Guid GetEmailId(this ClaimsPrincipal? principal)
    {
        var claim = principal?.FindFirst(ClaimTypes.Email);
        return !Guid.TryParse(claim?.Value, out var emailId) ? Guid.Empty : emailId;
    }    
    
    /// <summary>
    /// Get Iat from ClaimsPrincipal->ClaimTypes.Iat
    /// </summary>
    /// <param name="principal"></param>
    /// <returns></returns>
    public static long GetIat(this ClaimsPrincipal? principal)
    {
        var claim = principal?.FindFirst("iat");
        return !long.TryParse(claim?.Value, out var iat) ? 0 : iat;
    }    
    
}