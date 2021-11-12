using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Data.Models;

namespace TaskManagement.Data.Interface
{
    public interface IUser
    {
        IEnumerable<Account> AllUser { get; }
        Account GetUser(string email);
        void AddUser(Account user);
    }
}
