namespace Week2Lab1ConsoleApp2022.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Runtime.Remoting.Metadata.W3cXsd2001;
    using Tracker.WebAPIClient;

    internal sealed class Configuration : DbMigrationsConfiguration<Week2Lab1ConsoleApp2022.BusinesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Week2Lab1ConsoleApp2022.BusinesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            ActivityAPIClient.Track(StudentID: "S00211357", StudentName: "Jamie Bredin",
               activityName: "Rad301 2022 Week 2 Lab 1",
               Task: "Seeding Data");

            DateTime baseDate = new DateTime(year: 2019, month: 12, day: 9);
            Random r = new Random();



            context.Categories.AddOrUpdate(c => c.Description, new Category[]
         {
                new Category {Description = "Hardware"},
                new Category{Description = "Electrical Appliances"},
         });
            context.SaveChanges();

            context.Products.AddOrUpdate(p => p.Description,

               new Product[]
               {
                   //new Product{Description="Chimney Hoover",
                   //QuantityInStock= 10, UnitPrice = 100.5f,
                   //dateFirstIssued = baseDate.AddDays(r.Next(1,5)),
                    
                   //associatedCategory = new Category {CategoryId = 2, Description = "Building Supplies"},
                   //},

                   
                            new Product
                            {
                             Description = "9 Inch Nails",
                             QuantityInStock = 200,
                             UnitPrice=0.10f,
                             CategoryID=1,
                             dateFirstIssued = new DateTime(year:2019,month:02,day:05)
                            },
                      new Product
                      {
                        Description = "9 Inch Bolts",
                        QuantityInStock = 120,
                        UnitPrice=0.20f,
                        CategoryID=1,
                        dateFirstIssued = new DateTime(year:2019,month:05,day:19)
                      },
        new Product {
            Description = "Chimney Hoover",
            QuantityInStock = 10,
            UnitPrice=100.50f,
            CategoryID=2,
            dateFirstIssued = new DateTime(year:2019,month:03,day:10)
        },
        new Product {
            Description = "Washing Machine",
            QuantityInStock = 7,
            UnitPrice=399.99f,
            CategoryID=2,
            dateFirstIssued = new DateTime(year:2019,month:04,day:15)
        },
            new Product
            {
                Description="Android Apple",
                QuantityInStock = 69,
                UnitPrice=420.00f,
                CategoryID=2,
                dateFirstIssued= new DateTime(year:2022, month:04, day:03)
            }
               });
            context.SaveChanges();





            context.Suppliers.AddOrUpdate(p => p.SupplierName,
                new Supplier[]
                {
                    new Supplier
                    {
                        SupplierName="Parts 1",
                        SupplierAddressLine1="Addr 11",
                        SupplierAddressLine2="Addr 21"
                    },

                    new Supplier
                    {
                        SupplierName="Parts 2",
                        SupplierAddressLine1="Addr 11",
                        SupplierAddressLine2="Addr 21" },

                    new Supplier
                    {
                        SupplierName = "JamieIsTheBest",
                        SupplierAddressLine1 = "TheRoadHeLivesOn",
                        SupplierAddressLine2 = "HisAddress"
                    }

                }
                );
            context.SaveChanges();

            context.SupplierProducts.AddOrUpdate(p => new {p.SupplierID,p.ProductID},


            new SupplierProduct[]
            {
                new SupplierProduct{SupplierID=1,
            ProductID=1,
            DateFirstSupplied=new DateTime(year:2012,month:12,day:12)},

            new SupplierProduct{SupplierID=1,
            ProductID=2,
            DateFirstSupplied=new DateTime(year:2013,month:01,day:06)},

            new SupplierProduct{SupplierID=2,
            ProductID=3,
            DateFirstSupplied=new DateTime(year:2017,month:09,day:09) },

            new SupplierProduct{SupplierID=2,
            ProductID=4,
            DateFirstSupplied=new DateTime(year:2017,month:09,day:10)},

            new SupplierProduct{SupplierID=3,ProductID=5,DateFirstSupplied = new DateTime(year:2001, month:01, day:06)
            }
            }
            );
            context.SaveChanges();

        }

        
    }
}
