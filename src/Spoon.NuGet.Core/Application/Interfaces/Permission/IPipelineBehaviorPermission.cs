namespace Spoon.NuGet.Core.Application.Interfaces.Permission
{
    using System.Security.Claims;

    /// <summary>
    ///     Interface IPipelineBehaviorPermission.
    /// </summary>
    public interface IPipelineBehaviorPermission
    {
        /// <summary>
        ///     Gets the required claims.
        /// </summary>
        /// <returns>IEnumerable&lt;Claim&gt;.</returns>
        public IEnumerable<Claim> GetRequiredClaims();
    }
}