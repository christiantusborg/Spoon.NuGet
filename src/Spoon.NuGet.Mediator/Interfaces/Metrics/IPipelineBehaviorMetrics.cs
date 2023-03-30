namespace Spoon.NuGet.Mediator.Interfaces.Metrics;

/// <summary>
/// Interface IPipelineBehaviorMetrics
/// Extends the <see cref="IPipelineBehaviorMetricsCounterOptions" />
/// Extends the <see cref="IPipelineBehaviorMetricsTimerOptions" />.
/// </summary>
/// <seealso cref="IPipelineBehaviorMetricsCounterOptions" />
/// <seealso cref="IPipelineBehaviorMetricsTimerOptions" />
public interface IPipelineBehaviorMetrics : IPipelineBehaviorMetricsCounterOptions,
    IPipelineBehaviorMetricsTimerOptions
{
}
