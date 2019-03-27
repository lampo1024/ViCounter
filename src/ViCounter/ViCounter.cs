using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace ViCounter
{
    /// <summary>
    /// 
    /// </summary>
    public class ViCounter
    {
        private static ViCounter _instance = new ViCounter();

        private ViCounter()
        {
            var timer = new Timer(10000) { Enabled = true };
            timer.Start();
            timer.Elapsed += (sender, e) => VisitorList.RemoveWhere(x => x.ExpiredAt < DateTime.Now);
        }

        /// <summary>
        /// This method called when the request arrives.
        /// </summary>
        /// <param name="visitorId">visitor identity</param>
        public static void Visit(string visitorId)
        {
            var visitor = VisitorList.FirstOrDefault(x => x.Id == visitorId);
            var d = DateTime.Now;
            if (visitor == null)
            {
                VisitorList.Add(new Visitor
                {
                    Id = visitorId,
                    FirstVisitAt = d,
                    LatestVisitAt = d
                });
            }
            else
            {
                visitor.LatestVisitAt = d;
                visitor.ExpiredAt = d.AddSeconds(5 * 60);
            }
        }

        /// <summary>
        /// Gets number of current online visitors
        /// </summary>
        public static int VisitorNumber => VisitorList.Count;

        /// <summary>
        /// Gets list of current online visitors
        /// </summary>
        public static HashSet<Visitor> VisitorList { get; } = new HashSet<Visitor>();
    }
}
