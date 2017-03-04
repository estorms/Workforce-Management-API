﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkforceManagement.Models
{
    public class Employee
    {
        [Key]

        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ComputerId { get; set; }

        public Computer Computer { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
