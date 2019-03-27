using System;

namespace ViCounter
{
    /// <summary>
    /// Contains visitor's information
    /// e.g.
    /// Id--visitor identity
    /// FirstVisitAt--first visit time at ...
    /// </summary>
    public class Visitor
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// first visit time
        /// </summary>
        public DateTime FirstVisitAt { get; set; }
        /// <summary>
        /// latest visit time
        /// </summary>
        public DateTime LatestVisitAt { get; set; }
        /// <summary>
        /// The active expiration time of the current user
        /// </summary>
        public DateTime ExpiredAt { get; set; }
        /// <summary>
        /// visit count
        /// </summary>
        public int Count { get; set; }
    }
}