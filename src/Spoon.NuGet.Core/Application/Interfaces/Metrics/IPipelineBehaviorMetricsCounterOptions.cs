﻿namespace Spoon.NuGet.Core.Application.Interfaces.Metrics;

using App.Metrics.Counter;

/// <summary>
/// Interface IPipelineBehaviorMetricsCounterOptions.
/// </summary>
public interface IPipelineBehaviorMetricsCounterOptions
{
    /// <summary>
    /// Customs the counter.
    /// </summary>
    /// <returns>CounterOptions.</returns>
    CounterOptions CustomCounter();
}
