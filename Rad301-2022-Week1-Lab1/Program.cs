using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tracker.WebAPIClient;


namespace Rad301_2022_Week1_Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            ActivityAPIClient.Track(StudentID: "S00211357", StudentName: "Jamie Bredin",
               activityName: "Rad301 2022 Week 1 Lab 1 Part 2",
               Task: "Designing classes Model");


            //Linking ProductModel to the Main Program
            ProductModel _productModel = new ProductModel();

            Console.WriteLine("Starting Queries");

            //getting all categories from Product model
            var _categoryDetails = _productModel.categories
                .Select(p => new
                {
                    allCategoryInfo = String.Concat("\nCategoryID: ",p.id," \nCategory Description: ",p.Description)
                });
            //Looping through all the category data and printing it
            foreach (var pCategory in _categoryDetails)
                Console.WriteLine("--------------------------\n Category Information {0}",
                    String.Concat(pCategory.allCategoryInfo, " "));

            Console.WriteLine("\n-------------------------Next Query---------------------------------------");

            //Returning all products
            var _productDetails = _productModel.products
               .Select(p => new {
                   Name = String.Concat("\nProduct ID: ", p.ProductID, " \nProduct Description: ", p.Description, " \nProduct Quanitity: ", p.QuantityInStock, " \nProduct Unit Price: ", p.UnitPrice, " \nProduct CategoryID: ", p.CategoryID),
       
               });
            foreach (var pxp in _productDetails)
                Console.WriteLine("--------------------------\nProduct Information {0}",
                    String.Concat(pxp.Name, " "));

            Console.WriteLine("\n-------------------------Next Query---------------------------------------");

            //Returning all products less than 100 in stock

            var quantityLessThan100 = _productModel.products
                .Where(s => s.QuantityInStock <= 100)
                .Select(p => new {
                   Name = String.Concat("\nProduct ID: ", p.ProductID, " \nProduct Description: ", p.Description, " \nProduct Quanitity: ", p.QuantityInStock, " \nProduct Unit Price: ", p.UnitPrice, " \nProduct CategoryID: ", p.CategoryID),

                });
            foreach (var p in quantityLessThan100)
                Console.WriteLine("--------------------------\nProducts Less than 100 {0}",
                    String.Concat(p.Name, " "));

            Console.WriteLine("\n-------------------------Next Query---------------------------------------");
            
            //Returning all products and their total price

            float totalPrice = 0;
            var _productDetailsTotalPrice = _productModel.products
              .Select(p => new
              {
                  Name = String.Concat("\nProduct ID: ", p.ProductID, " \nProduct Description: ", p.Description, " \nProduct Quanitity: ", p.QuantityInStock, " \nProduct Unit Price: ", p.UnitPrice, " \nProduct CategoryID: ", p.CategoryID),

                  TotalValue = totalPrice += p.UnitPrice,
                 
              }) ;



            foreach (var pxp in _productDetailsTotalPrice)
                Console.WriteLine("--------------------------\nProduct Information {0}",
                    String.Concat("Total Product Price: ", pxp.TotalValue));

            Console.WriteLine("\n-------------------------Next Query---------------------------------------");
            // Returing all products that have a Category ID = 1
            var hardwareQuantity = _productModel.products
                .Where(s => s.CategoryID == 1)
                .Select(p => new {
                    Name = String.Concat("\nProduct ID: ", p.ProductID, " \nProduct Description: ", p.Description, " \nProduct Quanitity: ", p.QuantityInStock, " \nProduct Unit Price: ", p.UnitPrice, " \nProduct CategoryID: ", p.CategoryID),

                });
            foreach (var p in hardwareQuantity)
                Console.WriteLine("\n--------------------------\nProduct that are Hardware {0}",
                    String.Concat(p.Name, " "));

            Console.WriteLine("\n-------------------------Next Query---------------------------------------");
            // Returing all Suppliers information and products from that supplier
            var _supplierInfo = _productModel.supplier
                .Select(p => new {
                    Name = String.Concat("\nSupplier ID: ", p.SupplierID, " \nSupplier Name: ", p.SupplierName, " \nSupplier Address Line 1: ", p.SupplierAddressLine1, " \nSupplier Address Line 2: ", p.SupplierAddressLine2),

                });

            foreach(var p in _supplierInfo)
                Console.WriteLine("\n--------------------------\nSupplier Information {0}",
                   String.Concat(p.Name, " "));


            var supplierPart1 = (from s in _productModel.supplier
                                 join sp in _productModel.supplierProducts
                                 on s.SupplierID equals sp.SupplierID
                                 join p in _productModel.products
                                 on sp.ProductID equals p.ProductID
                                 where sp.SupplierID == 1
                                 select new
                                 {
                                     Name = String.Concat("\nSupplier Name: ", s.SupplierName,"\nSupplier ID: ", sp.SupplierID, " \nProduct ID: ", sp.ProductID, " \nDate First Supplied: ", sp.DateFirstSupplied, "\nProduct ID: ", p.ProductID, " \nProduct Description: ", p.Description, " \nProduct Quanitity: ", p.QuantityInStock, " \nProduct Unit Price: ", p.UnitPrice, " \nProduct CategoryID: ", p.CategoryID),

                                 }

                                 );

            foreach (var p in supplierPart1)
                Console.WriteLine("\n--------------------------\nProduct from supplier 1 {0}",
                    String.Concat(p.Name, " "));

             var supplierPart2 = (from s in _productModel.supplier
                                 join sp in _productModel.supplierProducts
                                 on s.SupplierID equals sp.SupplierID
                                 join p in _productModel.products
                                 on sp.ProductID equals p.ProductID
                                 where sp.SupplierID == 2
                                 select new
                                 {
                                     Name = String.Concat("\nSupplier Name: ", s.SupplierName,"\nSupplier ID: ", sp.SupplierID, " \nProduct ID: ", sp.ProductID, " \nDate First Supplied: ", sp.DateFirstSupplied, "\nProduct ID: ", p.ProductID, " \nProduct Description: ", p.Description, " \nProduct Quanitity: ", p.QuantityInStock, " \nProduct Unit Price: ", p.UnitPrice, " \nProduct CategoryID: ", p.CategoryID),

                                 }

                                 );

            foreach (var p in supplierPart2)
                Console.WriteLine("\n--------------------------\nProduct from supplier 2 {0}",
                    String.Concat(p.Name, " "));
            
        }
    }
}
