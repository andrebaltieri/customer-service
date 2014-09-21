using CustomerService.Domain;
using System.Data.Entity.ModelConfiguration;

namespace CustomerService.Data.Mappings
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable("Customer");

            HasKey(x => x.Id);
            Property(x => x.FirstName).IsRequired().HasMaxLength(20);
            Property(x => x.LastName).IsRequired().HasMaxLength(20);
            Property(x => x.Email).IsRequired().HasMaxLength(120);
        }
    }
}
