
using BulkyBook.Models;
using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections.Generic;

namespace BulkyBookWeb.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        //Here we create the Category Table in database using EntityFrameworkCore
        public DbSet<Category> categories { get; set; }
        //Here we create the Login Table in database using EntityFrameworkCore
        public DbSet<LoginViewModel> Logins { get; set; }
    }
   
}
