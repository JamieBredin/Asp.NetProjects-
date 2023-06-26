namespace Week09.Data.ClassLib.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tracker.WebAPIClient;
    using Week9ClubDomain22;

    internal sealed class Configuration : DbMigrationsConfiguration<Week9ClubDomain22.Week09DbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Week9ClubDomain22.Week09DbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            ActivityAPIClient.Track(StudentID: "S00211357", StudentName: "Jamie Bredin", activityName: "RAD301 Week 09 Lab 2223", Task: "Seeding Clubs");

            context.Clubs.AddOrUpdate(club => club.ClubName, new Club[] {
            new Club
            {

                ClubName = "Basketball",
                CreationDate = new DateTime(day: 25, month: 01, year: 2021),
                clubMembers = new List<Member>()
                   {
                        new Member
                        {
                            StudentID = "S00000001",
                            approved = true
                        },

                        new Member
                        {
                            StudentID = "S00000002",
                            approved =false
                        },
                         new Member
                        {
                            StudentID = "S00000003",
                            approved = false
                        },
                          new Member
                        {
                            StudentID = "S00000004",
                            approved = false
                        },
                           new Member
                        {
                            StudentID = "S00000005",
                            approved = false
                        }
                   },// End of new club members
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
                          new ClubEvent { StartDateTime = new DateTime(day:03, month:03, year:2021).Add(new TimeSpan(3,10,0,0,0)),
                                        EndDateTime =  new DateTime(day:04, month:03, year:2021).Add(new TimeSpan(3,12,0,0,0)),
                            Location = "Sligo", Venue="Knocknarea"
                        },
                   }// End of new CLub events
            }, // End of First club added other clubs can be added next
            new Club
            {

                ClubName = "Boxing",
                CreationDate = new DateTime(day: 20, month: 02, year: 2021),
                   clubMembers = new List<Member>()
                   {
                        new Member
                        {
                            StudentID = "S00000006",
                            approved = true
                        },

                        new Member
                        {
                            StudentID = "S00000007",
                            approved = false
                        },
                         new Member
                        {
                            StudentID = "S00000008",
                            approved = false
                        },
                          new Member
                        {
                            StudentID = "S00000009",
                            approved = false
                        },
                           new Member
                        {
                            StudentID = "S00000010",
                            approved = false
                        }
                   },// End of new club members
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
                          new ClubEvent { StartDateTime = new DateTime(day:04, month:04, year:2021).Add(new TimeSpan(3,10,0,0,0)),
                                        EndDateTime =  new DateTime(day:05, month:04, year:2021).Add(new TimeSpan(3,12,0,0,0)),
                            Location = "Galway", Venue="Main Canteen"
                        },
                   }
            },
            new Club
            {

                ClubName = "Golf",
                CreationDate = new DateTime(day: 15, month: 03, year: 2021),
                   clubMembers = new List<Member>()
                   {
                        new Member
                        {
                            StudentID = "S00000011",
                            approved = true
                        },

                        new Member
                        {
                            StudentID = "S00000012",
                            approved = false
                        },
                         new Member
                        {
                            StudentID = "S00000013",
                            approved = false
                        },
                          new Member
                        {
                            StudentID = "S00000014",
                            approved = false
                        },
                           new Member
                        {
                            StudentID = "S00000015",
                            approved = false
                        }
                   },// End of new club members
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
                          new ClubEvent { StartDateTime = new DateTime(day:06, month:05, year:2021).Add(new TimeSpan(3,10,0,0,0)),
                                        EndDateTime =  new DateTime(day:07, month:05, year:2021).Add(new TimeSpan(3,12,0,0,0)),
                            Location = "Sligo", Venue="Sligo Golf Course"
                        },
                   }
            },
          
            }
             );
            context.SaveChanges();
            List<Club> clubs = context.Clubs.ToList();
            foreach (Club club in clubs)
            {
                club.adminID = club.clubMembers.First().MemberID;//getting first club's first member and making its member ID an AdminID

            }
            context.SaveChanges();
            //Adding each member of each club to attend the events of that club
            List<EventAttendnace> attendances = new List<EventAttendnace>();
            foreach (var club in clubs)
            {
                foreach (var e in club.clubEvents)
                {
                    foreach (var member in club.clubMembers)
                    {
                        attendances.Add(new EventAttendnace
                        {
                            associatedEvent = e,
                            memberAttending = member
                        });
                    }
                   ;
                }

            }
            //Adding Event attendance
            context.EventAttendances.AddOrUpdate(
                a => new { a.EventID, a.AttendeeMember },
                attendances.ToArray());
            context.SaveChanges();
        }
    }
}
