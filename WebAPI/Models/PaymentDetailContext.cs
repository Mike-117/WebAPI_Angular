using Microsoft.EntityFrameworkCore; // installed from NuGet Package manager, allows for the creation of a DbContext class to map to a database
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class PaymentDetailContext : DbContext //Inherits from DbContext (from Entity Framework Core)
    {
        //constructor with single parameter, DbContextOptions of the PaymentDetailContext type, which also calls the parent constuctor, passing the object "options" as its parameter
        public PaymentDetailContext(DbContextOptions<PaymentDetailContext> options) : base(options) // in this constructor are passed info like db provider, db connection string
        {

        }
        
        // add a property of the type DbSet this is a context class which saves instances of the PaymentDetail class as a property of PaymentDetailContext
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
    }
}
