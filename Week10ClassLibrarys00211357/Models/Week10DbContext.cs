using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10ClubDomain22
{
    public class ClubsContext : DbContext
    {

        
        public DbSet<Student> Student { get; set; }
        public ClubsContext()
            : base("name=Week10LabConnection")
        {
        }

        public static ClubsContext Create()
        {
            return new ClubsContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
        

    }
}
