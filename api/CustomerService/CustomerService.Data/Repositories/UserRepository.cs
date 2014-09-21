using CustomerService.Data.DataContexts;
using CustomerService.Domain;
using CustomerService.Domain.Contracts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CustomerService.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private CustomerServiceDataContext _db;

        public UserRepository(CustomerServiceDataContext context)
        {
            _db = context;
        }

        public ICollection<User> Get()
        {
            return _db.Users.ToList();
        }

        public User Get(int id)
        {
            return _db.Users.Find(id);
        }

        public User Authenticate(string username, string password)
        {
            return _db.Users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }

        public void SaveOrUpdate(User entity)
        {
            if (entity.Id == 0)
                _db.Users.Add(entity);
            else
                _db.Entry<User>(entity).State = EntityState.Modified;

            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Users.Remove(_db.Users.Find(id));
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
