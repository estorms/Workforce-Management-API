using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkforceManagement.Models;
namespace WorkforceManagement.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WorkforceDbContext(serviceProvider.GetRequiredService<DbContextOptions<WorkforceDbContext>>()))
            {
                if (context.Employee.Any())
                {
                    return;
                }

                var emp = new Employee
                {
                    FirstName = "Jim",
                    LastName = "Thompson",
                    ComputerId = 1,
                    DepartmentId = 1

                };

                var comp = new Computer
                {
                    DatePurchased = DateTime.Now
                };

                var dept = new Department
                {
                    Name = "Electronics"
                };

                var training = new Training
                {
                   Topic = "Workplace Bullying"
                };

                context.Employee.Add(emp);
                context.Computer.Add(comp);
                context.Department.Add(dept);
                context.Training.Add(training);
                context.SaveChanges();
                }
        }
    }
}

