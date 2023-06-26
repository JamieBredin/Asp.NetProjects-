namespace Week8ClassLibary2022.DataLayer.Migrations
{
    using ClubModels;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tracker.WebAPIClient;

    internal sealed class Configuration : DbMigrationsConfiguration<ClubModels.ClubsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClubModels.ClubsContext context)
        {
            ActivityAPIClient.Track(StudentID: "S00211357", StudentName: "Jamie Bredin", activityName: "RAD301 Week 8 Lab 2223", Task: "Adding Club Events");
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Clubs.AddOrUpdate(club => club.ClubName, new Club[] {
            new Club
            {

                ClubName = "Basketball",
                CreationDate = new DateTime(day: 25, month: 01, year: 2021),
                clubEvents = new List<ClubEvent>()
                   {
                         new ClubEvent { StartDateTime = new DateTime(day:25, month:02, year:2021).Add(new TimeSpan(5,15,0,0,0)),
                                        EndDateTime =  new DateTime(day:25, month:02, year:2021).Add(new TimeSpan(5,16,0,0,0)),
                            Location = "Sligo", Venue="Arena"
                        },
                        new ClubEvent { StartDateTime = new DateTime(day:25, month:02, year:2021).Add(new TimeSpan(3,10,0,0,0)),
                                        EndDateTime =  new DateTime(day:25, month:02, year:2021).Add(new TimeSpan(3,12,0,0,0)),
                            Location = "Sligo", Venue="Main Canteen"
                        },
                        new ClubEvent { StartDateTime = new DateTime(day:05, month:03, year:2021).Add(new TimeSpan(5,15,0,0,0)),
                                        EndDateTime =  new DateTime(day:05, month:03, year:2021).Add(new TimeSpan(5,16,0,0,0)),
                            Location = "Sligo", Venue="Knocknarea"
                        },
                        new ClubEvent { StartDateTime = new DateTime(day:20, month:04, year:2021).Add(new TimeSpan(3,10,0,0,0)),
                                        EndDateTime =  new DateTime(day:20, month:04, year:2021).Add(new TimeSpan(3,12,0,0,0)),
                            Location = "Sligo", Venue="ATU"
                        },
                   }// End of new CLub events
            }, // End of First club added other clubs can be added next
            new Club
            {

                ClubName = "Boxing",
                CreationDate = new DateTime(day: 20, month: 02, year: 2021),
                clubEvents = new List<ClubEvent>()
                   {
                         new ClubEvent { StartDateTime = new DateTime(day:20, month:03, year:2021).Add(new TimeSpan(5,15,0,0,0)),
                                        EndDateTime =  new DateTime(day:20, month:03, year:2021).Add(new TimeSpan(5,16,0,0,0)),
                            Location = "Cavan", Venue="Town Hall"
                        },
                        new ClubEvent { StartDateTime = new DateTime(day:25, month:03, year:2021).Add(new TimeSpan(3,10,0,0,0)),
                                        EndDateTime =  new DateTime(day:25, month:03, year:2021).Add(new TimeSpan(3,12,0,0,0)),
                            Location = "Sligo", Venue="Knocknarea"
                        },
                         new ClubEvent { StartDateTime = new DateTime(day:20, month:04, year:2021).Add(new TimeSpan(5,15,0,0,0)),
                                        EndDateTime =  new DateTime(day:20, month:04, year:2021).Add(new TimeSpan(5,16,0,0,0)),
                            Location = "Cavan", Venue="Boxing Centre"
                        },
                        new ClubEvent { StartDateTime = new DateTime(day:25, month:05, year:2021).Add(new TimeSpan(3,10,0,0,0)),
                                        EndDateTime =  new DateTime(day:25, month:05, year:2021).Add(new TimeSpan(3,12,0,0,0)),
                            Location = "Sligo", Venue="ATU"
                        },
                   }
            },
            new Club
            {

                ClubName = "Golf",
                CreationDate = new DateTime(day: 15, month: 03, year: 2021),
                clubEvents = new List<ClubEvent>()
                   {
                         new ClubEvent { StartDateTime = new DateTime(day:25, month:03, year:2021).Add(new TimeSpan(5,15,0,0,0)),
                                        EndDateTime =  new DateTime(day:25, month:03, year:2021).Add(new TimeSpan(5,16,0,0,0)),
                            Location = "Offaly", Venue="Offaly Golf Course"
                        },
                        new ClubEvent { StartDateTime = new DateTime(day:15, month:04, year:2021).Add(new TimeSpan(3,10,0,0,0)),
                                        EndDateTime =  new DateTime(day:15, month:04, year:2021).Add(new TimeSpan(3,12,0,0,0)),
                            Location = "Dublin", Venue="Dublin Golf Course"
                        },
                          new ClubEvent { StartDateTime = new DateTime(day:25, month:05, year:2021).Add(new TimeSpan(5,15,0,0,0)),
                                        EndDateTime =  new DateTime(day:25, month:05, year:2021).Add(new TimeSpan(5,16,0,0,0)),
                            Location = "Galway", Venue="Galway Golf Course"
                        },
                        new ClubEvent { StartDateTime = new DateTime(day:15, month:06, year:2021).Add(new TimeSpan(3,10,0,0,0)),
                                        EndDateTime =  new DateTime(day:15, month:06, year:2021).Add(new TimeSpan(3,12,0,0,0)),
                            Location = "Cavan", Venue="Slieve Russel Hotel"
                        },
                   }
            },
            new Club
            {

                ClubName = "Motorsport",
                CreationDate = new DateTime(day: 10, month: 04, year: 2021),
                clubEvents = new List<ClubEvent>()
                   {
                         new ClubEvent { StartDateTime = new DateTime(day:25, month:04, year:2021).Add(new TimeSpan(5,15,0,0,0)),
                                        EndDateTime =  new DateTime(day:25, month:04, year:2021).Add(new TimeSpan(5,16,0,0,0)),
                            Location = "Donegal", Venue="Community Centre"
                        },
                        new ClubEvent { StartDateTime = new DateTime(day:18, month:05, year:2021).Add(new TimeSpan(3,10,0,0,0)),
                                        EndDateTime =  new DateTime(day:18, month:05, year:2021).Add(new TimeSpan(3,12,0,0,0)),
                            Location = "Galway", Venue="Main Canteen"
                        },
                        new ClubEvent { StartDateTime = new DateTime(day:25, month:06, year:2021).Add(new TimeSpan(5,15,0,0,0)),
                                        EndDateTime =  new DateTime(day:25, month:06, year:2021).Add(new TimeSpan(5,16,0,0,0)),
                            Location = "Cavan", Venue="Town Centre"
                        },
                        new ClubEvent { StartDateTime = new DateTime(day:18, month:07, year:2021).Add(new TimeSpan(3,10,0,0,0)),
                                        EndDateTime =  new DateTime(day:18, month:07, year:2021).Add(new TimeSpan(3,12,0,0,0)),
                            Location = "Mayo", Venue="City Centre"
                        },
                   }
            },
            new Club
            {

                ClubName = "Soccer",
                CreationDate = new DateTime(day: 5, month: 05, year: 2021),
                clubEvents = new List<ClubEvent>()
                   {
                         new ClubEvent { StartDateTime = new DateTime(day:20, month:05, year:2021).Add(new TimeSpan(5,15,0,0,0)),
                                        EndDateTime =  new DateTime(day:20, month:05, year:2021).Add(new TimeSpan(5,16,0,0,0)),
                            Location = "Killeshandra", Venue="Pitch"
                        },
                        new ClubEvent { StartDateTime = new DateTime(day:21, month:06, year:2021).Add(new TimeSpan(3,10,0,0,0)),
                                        EndDateTime =  new DateTime(day:21, month:06, year:2021).Add(new TimeSpan(3,12,0,0,0)),
                            Location = "Beltrubet", Venue="Pitch"
                        },
                         new ClubEvent { StartDateTime = new DateTime(day:20, month:07, year:2021).Add(new TimeSpan(5,15,0,0,0)),
                                        EndDateTime =  new DateTime(day:20, month:07, year:2021).Add(new TimeSpan(5,16,0,0,0)),
                            Location = "Blacklion", Venue="Pitch"
                        },
                        new ClubEvent { StartDateTime = new DateTime(day:21, month:08, year:2021).Add(new TimeSpan(3,10,0,0,0)),
                                        EndDateTime =  new DateTime(day:21, month:08, year:2021).Add(new TimeSpan(3,12,0,0,0)),
                            Location = "Cavan", Venue="Pitch"
                        },
                   }
            } 
            }
            );
            context.SaveChanges();
        }
    }
}
