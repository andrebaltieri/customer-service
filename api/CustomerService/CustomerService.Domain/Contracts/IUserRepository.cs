﻿namespace CustomerService.Domain.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        User Authenticate(string username, string password);
    }
}
