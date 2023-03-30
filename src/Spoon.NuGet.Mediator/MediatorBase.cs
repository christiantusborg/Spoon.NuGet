namespace Spoon.NuGet.Mediator
{
    using System.Security.Claims;
    using App.Metrics;
    using App.Metrics.Counter;
    using App.Metrics.Timer;
    using Interfaces;
    using Interfaces.Metrics;
    using Interfaces.Permission;
    using Interfaces.WebHook;

    /// <summary>
    ///     Class MediatorBase.
    ///     Implements the <see cref="IPipelineBehaviorMetrics" />
    ///     Implements the <see cref="IPipelineBehaviorWebHook" />
    ///     Implements the <see cref="IPipelineBehaviorPermission" />.
    ///     Implements the <see cref="IPipelineBehaviorAuditLog" />.
    /// </summary>
    /// <seealso cref="IPipelineBehaviorMetrics" />
    /// <seealso cref="IPipelineBehaviorWebHook" />
    /// <seealso cref="IPipelineBehaviorPermission" />
    /// <seealso cref="IPipelineBehaviorAuditLog" />
    public abstract class MediatorBase : IHttpRequest, IPipelineBehaviorMetrics, IPipelineBehaviorWebHook, IPipelineBehaviorPermission, IPipelineBehaviorAuditLog
    {
        /// <summary>
        ///     The command.
        /// </summary>
        private readonly Type _command;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MediatorBase" /> class.
        /// </summary>
        /// <param name="command">The command.</param>
        public MediatorBase(Type command)
        {
            this._command = command;
        }

        /// <summary>
        ///     Customs the counter.
        /// </summary>
        /// <returns>CounterOptions.</returns>
        public virtual CounterOptions CustomCounter()
        {
            return new CounterOptions
            {
                Name = this._command.Name + "_Counter",
                Context = "IPipelineBehavior",
                MeasurementUnit = Unit.Calls,
            };
        }

        /// <summary>
        ///     Customs the benchmark.
        /// </summary>
        /// <returns>TimerOptions.</returns>
        public virtual TimerOptions CustomBenchmark()
        {
            return new TimerOptions
            {
                Name = this._command.Name + "_Benchmark",
                Context = "IPipelineBehavior",
                RateUnit = TimeUnit.Milliseconds,
            };
        }

        /// <summary>
        ///     Gets the required claims.
        /// </summary>
        /// <returns>IEnumerable&lt;Claim&gt;.</returns>
        public virtual IEnumerable<Claim> GetRequiredClaims()
        {
            return new List<Claim>
            {
                new ("root","root"),
                new (this._command.Name, this._command.Name),
            };
        }
    }
}