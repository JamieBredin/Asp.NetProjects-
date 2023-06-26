using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Lab1ConsoleApp2022
{

    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }//PK
        public string Description { get; set; }
        public virtual ICollection<Product> productsInCategory { get; set; }
    }
    public class Product
    {
        [Key]
        public int ProductID { get; set; }//PK
        [ForeignKey("associatedCategory")]
        public int CategoryID { get; set; }//FK
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public DateTime dateFirstIssued { get; set; }
        public int QuantityInStock { get; set; }
        public virtual Category associatedCategory { get; set; }
    }

    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }//PK
        public string SupplierName { get; set; }
        public string SupplierAddressLine1 { get; set; }
        public string SupplierAddressLine2 { get; set; }


    }

    public class SupplierProduct
    {
        [Key,Column(Order=0)]
        [ForeignKey("FK_Supplier")]
        public int SupplierID { get; set; }//PK
        [Key, Column(Order = 1)]
        [ForeignKey("FK_Product")]
        public int ProductID { get; set; }//PK
        public DateTime DateFirstSupplied { get; set; }
        public virtual Supplier FK_Supplier { get; set; }
        public virtual Product FK_Product { get; set; }

    }

   
}
