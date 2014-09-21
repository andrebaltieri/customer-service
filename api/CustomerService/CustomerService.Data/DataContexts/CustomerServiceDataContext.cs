using CustomerService.Data.Mappings;
using CustomerService.Domain;
using System.Data.Entity;

namespace CustomerService.Data.DataContexts
{
    public class CustomerServiceDataContext : DbContext
    {
        public CustomerServiceDataContext()
            : base("CustomerServiceConnectionString") 
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
