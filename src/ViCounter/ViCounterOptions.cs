namespace ViCounter
{
    /// <summary>
    /// ViCounter options class
    /// </summary>
    public class ViCounterOptions
    {
        public ViCounterOptions()
        {
            RefreshInterval = 10;
            ActivityDuration = 300;
        }
        /// <summary>
        /// Gets or sets the refresh interval, expressed in seconds, default:10 secs
        /// </summary>
        public int RefreshInterval { get; set; }

        /// <summary>
        /// Gets or sets the activity duration, expressed in seconds, default:300 secs
        /// </summary>
        public int ActivityDuration { get; set; }
    }
}
