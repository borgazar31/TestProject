using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManagement.Data.Models;
using TaskManagement.Data.Interface;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TaskManagement.Pages
{
    public class IndexModel : PageModel
    {
        public Account user;

        private readonly IUser _user;

        public IndexModel(IUser user)
        {
            _user = user;
        }

        public void OnGet()
        {
            user = new Account();
        }

        public IActionResult OnPost(string email, string password)
        {
            try 
            {
                Account user = LogIn(email, password);
                HttpContext.Session.SetString("login", user.Login);
                return RedirectToPage("Task/Index");
            }
            catch
            {
                Response.WriteAsync("<script>alert('Неверный email или пароль');</script>");
                return RedirectToPage("Index");
            }
        }

        private Account LogIn(string email, string password)
        {
            Account user = _user.GetUser(email);
            if (user != null)
            {
                if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return user;
                }
            }
            return null;
        }
    }
}
