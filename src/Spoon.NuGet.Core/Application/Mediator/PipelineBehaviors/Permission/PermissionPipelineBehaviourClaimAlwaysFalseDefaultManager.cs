﻿namespace Spoon.NuGet.Core.Application.Mediator.PipelineBehaviors.Permission;

using LogInterceptor;
using Microsoft.Extensions.Logging;

/// <summary>
///     Class PermissionPipelineBehaviourClaimManager.
///     Implements the <see cref="IPermissionPipelineBehaviourClaimManager" />
/// </summary>
/// <seealso cref="IPermissionPipelineBehaviourClaimManager" />
[LogInterceptorDefaultLogLevel(LogLevel.Debug)]
public class PermissionPipelineBehaviourClaimAlwaysFalseDefaultManager : IPermissionPipelineBehaviourClaimManager
{
    /// <summary>
    ///     Determines whether [has required claim] [the specified required claims].
    /// </summary>
    /// <param name="requiredClaims">The required claims.</param>
    /// <returns><c>true</c> if [has required claim] [the specified required claims]; otherwise, <c>false</c>.</returns>
    public bool HasRequiredClaim(List<string> requiredClaims)
    {
        return false;
    }
}