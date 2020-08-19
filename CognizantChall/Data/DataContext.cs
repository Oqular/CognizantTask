using CognizantChall.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizantChall.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Players> players { get; set; }
        public DbSet<Tasks> tasks { get; set; }
    }
}
