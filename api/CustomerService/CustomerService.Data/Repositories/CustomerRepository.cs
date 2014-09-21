using CustomerService.Data.DataContexts;
using CustomerService.Domain;
using CustomerService.Domain.Contracts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CustomerService.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerServiceDataContext _db;

        public CustomerRepository(CustomerServiceDataContext context)
        {
            _db = context;
        }

        public ICollection<Customer> Get()
        {
            return _db.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return _db.Customers.Find(id);
        }

        public void SaveOrUpdate(Customer entity)
        {
            if (entity.Id == 0)
                _db.Customers.Add(entity);
            else
                _db.Entry<Customer>(entity).State = EntityState.Modified;

            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Customers.Remove(_db.Customers.Find(id));
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
