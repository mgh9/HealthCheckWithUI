using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthCheckWithUI;

public class SimpleServiceHealthCheck : IHealthCheck
{
    private readonly Random _random = new();

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        int responseTimeInMS = _random.Next(0, 300);
        if (responseTimeInMS < 100)
        {
            return Task.FromResult(HealthCheckResult.Healthy($"Response time : {responseTimeInMS}"));
        }
        else if (responseTimeInMS < 200)
            return Task.FromResult(HealthCheckResult.Degraded($"Response Time: {responseTimeInMS}"));
        else
            return Task.FromResult(HealthCheckResult.Unhealthy($"Response Time: {responseTimeInMS}"));
    }
}
