using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using UsersApp;

namespace Курсач
{
    internal class ApplicationContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Work> works { get; set; }

        public ApplicationContext() : base("DefaultConnection") { }

    }
}