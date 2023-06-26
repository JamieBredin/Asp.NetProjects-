using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tracker.WebAPIClient;
using static System.Console;

namespace Week2Lab1ConsoleApp2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ActivityAPIClient.Track(StudentID: "S00211357", StudentName: "Jamie Bredin",
               activityName: "Rad301 2022 Week 2 Lab 1",
               Task: "Lab finshed");

            using (BusinesContext db = new BusinesContext())
            {
                //Calling all the Methods
                list_categories();
                Console.ReadLine();
                list_products();
                Console.ReadLine();
                list_products(100);
                Console.ReadLine();
                list_product_value();
                Console.ReadLine();
                list_category_products("Hardware");
                Console.ReadLine();
                list_supplier_parts();
            };
        }

        static void list_categories()
        {
            //Printing all the Data in the Categories
            using (BusinesContext db = new BusinesContext())
            {
                List<Category> Query = db.Categories.ToList();

                Console.WriteLine("Query Categories List");
                foreach (var item in Query)
                {
                    Console.WriteLine("Category ID: {0}, Category Description: {1}", item.CategoryID, item.Description);
                }
            }
            }

        static void list_products()
        {
            //Listing all the Products
            Console.WriteLine("---------------New Query---------------");

            using (BusinesContext db = new BusinesContext())
            {
                List<Product> Query2 = db.Products.ToList();

                Console.WriteLine("Query Product List");
                foreach (var item in Query2)
                {
                    Console.WriteLine("Product ID: {0}\n Product Description: {1} \n Product Price {2} \n Product Quantity: {3} \n Product First Issued {4}", item.ProductID, item.Description, item.UnitPrice, item.QuantityInStock, item.dateFirstIssued.ToString());
                }
            }
            
        }

        static void list_products(int UpperLimit)
        {
            //Listing all the Products that are less than 100 in stock
            Console.WriteLine("---------------New Query---------------");

            using (BusinesContext db = new BusinesContext())
            {
                List<Product> quantityLessThan100 = db.Products.ToList();
                var newSortedQuantity = quantityLessThan100.Where(p => p.QuantityInStock <= UpperLimit);

                foreach (var item2 in newSortedQuantity)
                {
                    Console.WriteLine("Product ID: {0}\n Product Description: {1} \n Product Price {2} \n Product Quantity: {3} \n Product First Issued {4}", item2.ProductID, item2.Description, item2.UnitPrice, item2.QuantityInStock, item2.dateFirstIssued.ToString());
                }
            }
        }

        static void list_product_value()
        {
            Console.WriteLine("---------------New Query---------------");
            //Listing all the products and displaying there total price
            using (BusinesContext db = new BusinesContext())
            {
                List<Product> allProducts = db.Products.ToList();
                float total = 0;
                foreach (var item in allProducts)
                {
                    total += item.UnitPrice;
                    Console.WriteLine("Product ID: {0}\n Product Description: {1} \n Product Price {2} \n Product Quantity: {3} \n Product First Issued {4}", item.ProductID, item.Description, item.UnitPrice, item.QuantityInStock, item.dateFirstIssued.ToString());
                }
                Console.WriteLine("Total Value: {0}", total);
            }
        }

        static void list_category_products(string category)
        {//Printing all the products in a category
            Console.WriteLine("---------------New Query---------------");

            using (BusinesContext db = new BusinesContext())
            {
                var joinedTables = from p in db.Products
                                   join c in db.Categories on p.CategoryID equals c.CategoryID
                                   where c.Description == category
                                   select new
                                   {
                                       id = p.ProductID,
                                       date = p.dateFirstIssued,
                                       desc = p.Description,
                                       unit = p.UnitPrice
                                   };
                foreach (var item in joinedTables)
                {
                    Console.WriteLine("Product ID: {0}\n Product Description: {1} \n Product Price {2} \n Product Quantity: {3}", item.id, item.desc, item.unit, item.date);
                }


            }

        }


        static void list_supplier_parts()
        {//Printing all the Suppliers and then there Parts
            Console.WriteLine("---------------New Query---------------");

            using (BusinesContext db = new BusinesContext())
            {
                var joinedTables = from p in db.Products
                                   join sp in db.SupplierProducts on p.ProductID equals sp.ProductID
                                   join s in db.Suppliers on sp.SupplierID equals s.SupplierID
                                   where sp.ProductID == p.ProductID
                                   select new
                                   {
                                       id = p.ProductID,
                                       date = p.dateFirstIssued,
                                       desc = p.Description,
                                       unit = p.UnitPrice,

                                       supplierID = s.SupplierID,
                                       supplierName = s.SupplierName,
                                       supplierAddressLine1 = s.SupplierAddressLine1,
                                       supplierAddressLine2 = s.SupplierAddressLine2,

                                   };
                foreach (var item in joinedTables)
                {
                    WriteLine("SupplierID: {0} \n Supplier Name: {1} \n Supplier Address Line 1: {2} \n Supplier Address Line 2: {3}",item.supplierName,item.supplierName,item.supplierAddressLine1,item.supplierAddressLine2);
                    Console.WriteLine("Product ID: {0}\n Product Description: {1} \n Product Price {2} \n Product Quantity: {3}", item.id, item.desc, item.unit, item.date);
                }

            }
        }
    }
}
