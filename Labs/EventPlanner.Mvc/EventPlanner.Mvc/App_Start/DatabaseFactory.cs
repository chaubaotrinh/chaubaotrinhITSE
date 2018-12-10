/* 
 * Student: Chau Trinh
 * Class: ITSE 1430
 * Lab 5: Event Planner
 * Date: 10 Dec 2018
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventPlanner.Memory;

namespace EventPlanner.Mvc.App_Start
{
    public class DatabaseFactory
    {
        //public static readonly IEventDatabase Database = new MemoryEventDatabase();

        //private static DatabaseFactory databaseFactory;

        //private DatabaseFactory()
        //{

        //}

        //public static DatabaseFactory GetInstance()
        //{
        //    if (databaseFactory == null)
        //        databaseFactory = new DatabaseFactory();

        //    return databaseFactory;
        //}


        //public IEventDatabase EventDatabase()
        //{
        //    var events = new[]
        //    {
        //        new ScheduledEvent()
        //        {
        //            Name = "QuickBook Advance",
        //            Description = "How to use QuickBook",
        //            StartDate = new DateTime(2019, 02, 12),
        //            EndDate = new DateTime(2019, 03, 13),
        //            IsPublic = true,
        //        },

        //        new ScheduledEvent()
        //        {
        //            Name = "Michael Wedding",
        //            Description = "Important, must join",
        //            StartDate = new DateTime(2019, 01, 24),
        //            EndDate = new DateTime(2019, 01, 24),
        //            IsPublic = false,
        //        },

        //        new ScheduledEvent()
        //        {
        //            Name = "Fundalmental I Final",
        //            Description = "Must be on time",
        //            StartDate = new DateTime(2018, 11,30),
        //            EndDate = new DateTime(2018, 11,30),
        //            IsPublic = false,
        //        },

        //        new ScheduledEvent()
        //        {
        //            Name = "FBA conference",
        //            Description = "How to make money on Amazon",
        //            StartDate = new DateTime(2019, 01, 12),
        //            EndDate = new DateTime(2019, 01, 15),
        //            IsPublic = true,
        //        },

        //        new ScheduledEvent()
        //        {
        //            Name = "Tax Training",
        //            Description = "New Tax Regulation for 2019",
        //            StartDate = new DateTime(2018, 12,24),
        //            EndDate = new DateTime(2018, 12,30),
        //            IsPublic = false,
        //        },
        //    };


        //    for (var i = 0; i < events.Length; i++)
        //    {
        //        Database.Add(events[i]);
        //    }

        //    return Database;
        //}

        public static IEventDatabase Database = new MemoryEventDatabase();

        private DatabaseFactory()
        {

        }

        static DatabaseFactory()

        {
            //var db = new MyDatabase();

           Database.Seed();
            
        }

        
    }
}