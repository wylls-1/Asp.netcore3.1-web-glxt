using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHomework.Models
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext>options ):base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("employee").HasKey(a => a.EmpId);
            modelBuilder.Entity<Department>().ToTable("department").HasKey(a => a.DepId);
            modelBuilder.Entity<MoveDep>().ToTable("movedep").HasKey(a => a.Id);
            modelBuilder.Entity<Apply>().ToTable("apply").HasKey(a => a.Id);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<MoveDep> MoveDeps { get; set; }
        public DbSet<Apply> Applies { get; set; }
    }
}
