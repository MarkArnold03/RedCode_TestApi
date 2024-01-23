using Microsoft.EntityFrameworkCore;
using RedCode_Test.Models;
using System.Collections.Generic;

namespace RedCode_Test.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Citat> Citats { get; set; }
    }
}
