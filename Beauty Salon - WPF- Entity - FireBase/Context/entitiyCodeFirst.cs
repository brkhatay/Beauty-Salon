using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using PetraEntity.Context;
using System.IO;

namespace PetraEntity
{
    public class AdminContext : DbContext
    {
        public static string MDF_Directory
        {
            get
            {
                var directoryPath = ***************************************************;
            }
        }

        public string dbConnectionString = **************************************************;

     

        public AdminContext() 
        {
      
                Database.Connection.ConnectionString = dbConnectionString;
        }
 

        public virtual DbSet<Clock> Clocks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerLOG> CustomersLOG { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<PhoneBook> PhoneBooks { get; set; }
        public virtual DbSet<DayNote> DayNotes { get; set; }
        public virtual DbSet<AdminPS> AdminPSs { get; set; }

    }
}
