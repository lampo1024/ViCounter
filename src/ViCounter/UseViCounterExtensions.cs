using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ViCounter
{
    /// <summary>
    /// ViCounter static extension class
    /// </summary>
    public static class UseViCounterExtensions
    {
        public static IServiceCollection AddViCounter(this IServiceCollection service,
            ViCounterOptions options = default(ViCounterOptions))
        {
            if (options == null) return service;
            if (options.RefreshInterval < 3)
            {
                options.RefreshInterval = 3;
            }

            if (options.ActivityDuration < 1)
            {
                options.ActivityDuration = 1;
            }
            ViCounterSettings.RefreshInterval = options.RefreshInterval;
            ViCounterSettings.ActivityDuration = options.ActivityDuration;
            CounterMonitor.Init();
            return service;
        }
        /// <summary>
        /// Use ViCounter middleware to record online users
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseViCounter(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ViCounterMiddleware>();
        }
    }
}
