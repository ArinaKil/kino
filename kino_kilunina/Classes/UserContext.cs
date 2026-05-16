using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kino_kilunina.Models;
using Microsoft.EntityFrameworkCore;

namespace kino_kilunina.Classes
{
    public class UserContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public UserContext()
        {
            Database.EnsureCreated();
            Users.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Common.Config.ConnectionConfig, Common.Config.Version);
        }
    }
}
