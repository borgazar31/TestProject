using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TaskManagement.Data.Models;
using TaskManagement.Data.Interface;

namespace TaskManagement.Pages.Users
{
    public class RegistrModel : PageModel
    {
        private readonly IUser _user;

        public Account user;

        public RegistrModel(IUser iuser)
        {
            _user = iuser;     
        }

        public void OnGet()
        {
            user = new Account();
        }

        public IActionResult OnPost(string email, string password, string login)
        {
            Account user = new Account() 
            {
                Login = login,
                Email = email,
                Password = password
            };
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _user.AddUser(user);
            return RedirectToPage("/Index");
        }
    }
}
