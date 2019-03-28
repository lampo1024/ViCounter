namespace ViCounter
{
    /// <summary>
    /// ViCounter options class
    /// </summary>
    public sealed class ViCounterSettings
    {
        static ViCounterSettings()
        {
            RefreshInterval = 10;
            ActivityDuration = 300;
        }
        /// <summary>
        /// Gets or sets the refresh interval, expressed in seconds, default:10 secs
        /// </summary>
        public static int RefreshInterval { get; set; }

        /// <summary>
        /// Gets or sets the activity duration, expressed in seconds, default:300 secs
        /// </summary>
        public static int ActivityDuration { get; set; }
    }
}
