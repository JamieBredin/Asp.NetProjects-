namespace Week3ClubDomain22.BusinessModel.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Week3ClubDomain22.BusinessModel.ClubsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClubsContext context)
        {
           //Creating new club and adding members and events for each of them
            context.Clubs.AddOrUpdate(club => club.ClubName, new Club[] {
               new Club
               {

                   ClubName = "Club1",
                   CreationDate = new DateTime(day:25, month:01, year:2021),
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
                            approved = true
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
                   }// End of new CLub events
               }, // End of First club added other clubs can be added next

               new Club
               {

                   ClubName = "Club2",
                   CreationDate = new DateTime(day:15, month:02, year:2021),
                   clubMembers = new List<Member>()
                   {
                        new Member
                        {
                            StudentID = "S00000003",
                            approved = true
                        },

                        new Member
                        {
                            StudentID = "S00000004",
                            approved = true
                        }
                   },// End of new club members
                   clubEvents = new List<ClubEvent>()
                   {
                         new ClubEvent { StartDateTime = new DateTime(day:20, month:03, year:2021).Add(new TimeSpan(5,15,0,0,0)),
                                        EndDateTime =  new DateTime(day:20, month:03, year:2021).Add(new TimeSpan(5,16,0,0,0)),
                            Location = "Sligo", Venue="Knocknarea"
                        },
                        new ClubEvent { StartDateTime = new DateTime(day:05, month:06, year:2021).Add(new TimeSpan(1,10,0,0,0)),
                                        EndDateTime =  new DateTime(day:08, month:06, year:2021).Add(new TimeSpan(2,15,0,0,0)),
                            Location = "Cavan", Venue="Bus Station"
                        },
                   }// End of new CLub events
               }, // End of Second club added other clubs can be added next

               new Club
               {

                   ClubName = "Club3",
                   CreationDate = new DateTime(day:01, month:02, year:2021),
                   clubMembers = new List<Member>()
                   {
                        new Member
                        {
                            StudentID = "S00000001",
                            approved = true
                        },

                        new Member
                        {
                            StudentID = "S00000005",
                            approved = true
                        }
                   },// End of new club members
                   clubEvents = new List<ClubEvent>()
                   {
                         new ClubEvent { StartDateTime = new DateTime(day:10, month:03, year:2021).Add(new TimeSpan(5,8,0,0,0)),
                                        EndDateTime =  new DateTime(day:10, month:03, year:2021).Add(new TimeSpan(5,15,0,0,0)),
                            Location = "Dublin", Venue="Arena"
                        },
                        new ClubEvent { StartDateTime = new DateTime(day:16, month:10, year:2021).Add(new TimeSpan(2,10,0,0,0)),
                                        EndDateTime =  new DateTime(day:16, month:10, year:2021).Add(new TimeSpan(2,18,0,0,0)),
                            Location = "Sligo", Venue="Main Campus"
                        },
                   }// End of new CLub events
               }, // End of Third club added other clubs can be added next
            } // End of Clubs array
                 );// End of Add or Update
            context.SaveChanges();
            
            List<Club> clubs = context.Clubs.ToList(); 

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
