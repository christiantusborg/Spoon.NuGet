﻿namespace Spoon.NuGet.Core.Application.Interfaces.Metrics;

using App.Metrics.Timer;

/// <summary>
/// Interface IPipelineBehaviorMetricsTimerOptions.
/// </summary>
public interface IPipelineBehaviorMetricsTimerOptions
{
    /// <summary>
    /// Customs the benchmark.
    /// </summary>
    /// <returns>TimerOptions.</returns>
    TimerOptions CustomBenchmark();
}
