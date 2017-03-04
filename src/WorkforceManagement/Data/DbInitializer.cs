using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WorkforceManagement.Models;
namespace WorkforceManagement.Data
{
    public class DbInitializer
    {
        public static void Read() {
            using (var stream = new FileStream(@"C:\Users\Liz\Documents\Visual Studio 2015\Projects\WorkforceManagement\src\WorkforceManagement\EmployeeSeed.txt", FileMode.Open))
            using (var reader = new StreamReader(stream))
            {
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WorkforceDbContext(serviceProvider.GetRequiredService<DbContextOptions<WorkforceDbContext>>()))
            {
                if (context.Employee.Any())
                {
                    return;
                }

                var EmployeeArr = new Employee[]
                {


                    new Employee {
                    FirstName = "Jim",
                    LastName = "Thompson",
                    DepartmentId = 1

                },

                    new Employee {
                    FirstName = "Jane",
                    LastName = "Goodall",
                    DepartmentId = 2

                },
                    new Employee {
                    FirstName = "Jerry",
                    LastName = "Seinfeld",
                    DepartmentId = 3

                }
            };


                var ComputerArr = new Computer[] {

                        new Computer {
                        DatePurchased = DateTime.Now,
                        SerialNumber = "#1245.3edwue.8345",
                        },

                        new Computer {
                        DatePurchased = DateTime.Today,
                        SerialNumber = "#weg.hreee78.9945",
                        },

                        new Computer {
                        DatePurchased = DateTime.Now,
                        SerialNumber = "#gweeeU.3edwue.2e45",
                        }
                    };

                var DepartmentArr = new Department[] {

                    new Department
                    {
                        Name = "Pamphleteering"
                    },

                     new Department
                     {
                         Name = "Jumpsuits"
                     },

                     new Department
                     {
                         Name = "Ambrosia Sales"
                     }


                };
                var TrainingArr = new Training[] {

                     new Training
                     {
                         Topic ="Workplace Bullying"
                     },

                     new Training
                     {
                         Topic = "Professional Attire"
                     },

                     new Training
                     {
                         Topic = "Using a Garden Hose"
                     },

                     new Training
                     {
                         Topic = "Yard Gnomes I Have Known"
                     }
                    };


                foreach (var c in ComputerArr)
                {
                    context.Computer.Add(c);
                }

                foreach (var t in TrainingArr)
                {
                    context.Training.Add(t);
                }
                foreach (var d in DepartmentArr)
                {
                    context.Department.Add(d);
                }

                foreach (var e in EmployeeArr)
                {
                    context.Employee.Add(e);
                }
                context.SaveChanges();
            }
        }
    }
}

