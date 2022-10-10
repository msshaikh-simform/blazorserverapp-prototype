using Microsoft.Extensions.DependencyInjection;
using QuotationMgmtSystem.ApplicationDbContext;
using QuotationMgmtSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuotationMgmtSystem.Authentication
{
    public class UserAccountService
    {
        private List<User> _users;
        private readonly AppDbContext _dbContext;

        public UserAccountService(IServiceProvider serviceProvider)
        {
            // below line is used to consume scopedservice: [dbcontext] from singletone service: [useraccountservice]            
            this._dbContext = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
            _users = _dbContext.Users.ToList();
        }

        public User? GetByUserName(string userName) => _users.FirstOrDefault(x => x.UserName == userName);
    }
}