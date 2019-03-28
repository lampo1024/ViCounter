using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace ViCounter
{
    /// <summary>
    /// 
    /// </summary>
    public class CounterProcessor
    {
        private static readonly bool Initialized = false;
        private static readonly object Lock = new object();
        private static Timer _timer;
        private static int _counter = 0;

        static CounterProcessor()
        {
            Init();
        }
        public static void Init()
        {
            if (!Initialized)
            {
                lock (Lock)
                {
                    if (!Initialized && _timer == null)
                    {
                        _counter++;
                        _timer = new Timer(ViCounterSettings.RefreshInterval * 1000) { Enabled = true };
                        _timer.Start();
                        _timer.Elapsed += (sender, e) =>
                        {
                            //Console.WriteLine($"Start clear expired session, interval:{ViCounterSettings.RefreshInterval}, count:{_counter}...");
                            VisitorList.RemoveWhere(x => x.ExpiredAt < DateTime.Now);
                            //Console.WriteLine("Expired session clear completed.");
                        };
                    }
                }
            }
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
                    LatestVisitAt = d,
                    ExpiredAt = d.AddSeconds(ViCounterSettings.ActivityDuration)
                });
            }
            else
            {
                visitor.LatestVisitAt = d;
                visitor.ExpiredAt = d.AddSeconds(ViCounterSettings.ActivityDuration);
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
