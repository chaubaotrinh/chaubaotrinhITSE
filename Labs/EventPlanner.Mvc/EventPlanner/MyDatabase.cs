/* 
 * Student: Chau Trinh
 * Class: ITSE 1430
 * Lab 5: Event Planner
 * Date: 10 Dec 2018
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPlanner.Memory;

namespace EventPlanner
{
    public static class MemoryEventDatabaseExtensions
    {
        public static void Seed( this IEventDatabase source)
        {
            var events = new[]
            {
                    new ScheduledEvent()
                    {
                        Name = "QuickBook Advance",
                        Description = "How to use QuickBook",
                        StartDate = new DateTime(2019, 02, 12),
                        EndDate = new DateTime(2019, 03, 13),
                        IsPublic = true,
                    },

                    new ScheduledEvent()
                    {
                        Name = "Michael Wedding",
                        Description = "Important, must join",
                        StartDate = new DateTime(2019, 01, 24),
                        EndDate = new DateTime(2019, 01, 24),
                        IsPublic = false,
                    },

                    new ScheduledEvent()
                    {
                        Name = "Fundalmental I Final",
                        Description = "Must be on time",
                        StartDate = new DateTime(2018, 11,30),
                        EndDate = new DateTime(2018, 11,30),
                        IsPublic = false,
                    },

                    new ScheduledEvent()
                    {
                        Name = "FBA conference",
                        Description = "How to make money on Amazon",
                        StartDate = new DateTime(2019, 01, 12),
                        EndDate = new DateTime(2019, 01, 15),
                        IsPublic = true,
                    },

                    new ScheduledEvent()
                    {
                        Name = "Tax Training",
                        Description = "New Tax Regulation for 2019",
                        StartDate = new DateTime(2018, 12,24),
                        EndDate = new DateTime(2018, 12,30),
                        IsPublic = false,
                    },
            };
            Seed(source, events);
        }
        public static void Seed( this IEventDatabase source, ScheduledEvent[] events)
        {
            foreach (var scheduledEvent in events)
                source.Add(scheduledEvent);
        }

    }
}

