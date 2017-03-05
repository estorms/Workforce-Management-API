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
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var stream = new FileStream(@"C:\Users\Liz\Documents\Visual Studio 2015\Projects\WorkforceManagement\src\WorkforceManagement\EmployeeSeed.txt", FileMode.Open))
            {
                using (var context = new WorkforceDbContext(serviceProvider.GetRequiredService<DbContextOptions<WorkforceDbContext>>()))

                using (var reader = new StreamReader(stream))
                {
                    if (context.Employee.Any())
                    {
                        return;
                    }

                    var empList = new List<Employee>();
                    var allLines = reader.ReadToEnd();
                    var delimiter = new string[] { "\r\n" };
                    var linesArray = allLines.Split(delimiter, StringSplitOptions.None);
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

                    var i = 0;
                    while (i < linesArray.Length)
                    {
                        empList.Add(new Employee(linesArray[i], linesArray[i + 1], Convert.ToInt32(linesArray[i + 2])));
                        i = i + 3;
                    }
                    foreach (var emp in empList)
                    {
                        context.Employee.Add(emp);

                    }
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
                    context.SaveChanges();
                }

            }

        }

    }
}

