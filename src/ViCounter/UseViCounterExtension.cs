using Microsoft.AspNetCore.Builder;

namespace ViCounter
{
    /// <summary>
    /// ViCounter static extension class
    /// </summary>
    public static class UseViCounterExtension
    {
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
