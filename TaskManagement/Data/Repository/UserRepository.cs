using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Data.Models;
using TaskManagement.Data.Interface;


namespace TaskManagement.Data.Repository
{
    public class UserRepository : IUser
    {
        private readonly AppDBContent appDBContent;

        public UserRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Account> AllUser => appDBContent.Account;

        public void AddUser(Account user)
        {
            appDBContent.Account.Add(user);
            appDBContent.SaveChanges();
        }

        public Account GetUser(string email) => appDBContent.Account.FirstOrDefault(a => a.Email == email);

    }
}
