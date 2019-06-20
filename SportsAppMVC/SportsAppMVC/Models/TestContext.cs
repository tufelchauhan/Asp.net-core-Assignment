using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsAppMVC.Models
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options): base(options)
        {

        }
        public DbSet<CooperTest> CooperTests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
    }
}
