using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace UserAPP
{
    class AppContext : DbContext
    {

        public DbSet<User> Users { get; set; } // DbSet список внутри которого находятся определенные элементы с таблицы

        public AppContext() : base("DefaultConnection") { }


    }
}
