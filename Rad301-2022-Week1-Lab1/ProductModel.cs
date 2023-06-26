using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad301_2022_Week1_Lab1
{

    public class ProductModel
    {
        public List<Supplier> supplier = new List<Supplier>
        {
            new Supplier{SupplierID = 1,
            SupplierName="Parts 1",
            SupplierAddressLine1="Addr 11",
            SupplierAddressLine2="Addr 21"},

            new Supplier{SupplierID = 2,
            SupplierName="Parts 2",
            SupplierAddressLine1="Addr 11",
            SupplierAddressLine2="Addr 21"}
        };

        public List<Product> products = new List<Product>
    {
        new Product {ProductID = 1,
            Description = "9 Inch Nails",
            QuantityInStock = 200,
            UnitPrice=0.10f,
            CategoryID=1},
        new Product {ProductID = 2,
            Description = "9 Inch Bolts",
            QuantityInStock = 120,
            UnitPrice=0.20f,
            CategoryID=1},
        new Product {ProductID = 3,
            Description = "Chimney Hoover",
            QuantityInStock = 10,
            UnitPrice=100.50f,
            CategoryID=2},
        new Product {ProductID = 4,
            Description = "Washing Machine",
            QuantityInStock = 7,
            UnitPrice=399.99f,
            CategoryID=2},
        };

        public List<Category> categories = new List<Category>
        {
            new Category{id = 1,
            Description="Hardware"},

            new Category{id = 2,
            Description="Electrical Appliences"},
        };

        public List<SupplierProduct> supplierProducts = new List<SupplierProduct>
        {
            new SupplierProduct{SupplierID=1,
            ProductID=1,
            DateFirstSupplied=new DateTime(2012/12/12)},

            new SupplierProduct{SupplierID=1,
            ProductID=2,
            DateFirstSupplied=new DateTime(2013/01/06)},

            new SupplierProduct{SupplierID=2,
            ProductID=3,
            DateFirstSupplied=new DateTime(2017/09/09) },

            new SupplierProduct{SupplierID=2,
            ProductID=4,
            DateFirstSupplied=new DateTime(2017/09/10)}
        };

    }

    public class Product
    {
        public int ProductID { get; set; }//PK
        public string Description { get; set; }
        public int QuantityInStock { get; set; }
        public float UnitPrice { get; set; }
        public int CategoryID { get; set; }//FK


    }

    public class Supplier
    {
        public int SupplierID { get; set; }//PK
        public string SupplierName { get; set; }
        public string SupplierAddressLine1 { get; set; }
        public string SupplierAddressLine2 { get; set; }


    }

    public class SupplierProduct
    {
        public int SupplierID { get; set; }//PK
        public int ProductID { get; set; }//PK
        public DateTime DateFirstSupplied { get; set; }
    }

    public class Category
    {
        public int id { get; set; }//PK
        public string Description { get; set; }
    }

}
      
           
            
    
  

