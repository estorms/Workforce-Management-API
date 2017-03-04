using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkforceManagement.Models;

namespace WorkforceManagement.Data
{
    public class WorkforceDbContext : DbContext
    {

        public DbSet<Computer> Computer { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Training> Training { get; set; }

        public DbSet<EmployeeTraining> EmployeeTraining { get; set; }

        public DbSet<Department> Department { get; set; }


        public WorkforceDbContext(DbContextOptions<WorkforceDbContext> options)
                : base(options)
        {
        }


    }
}
