using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkforceManagement.Models
{
    public class EmployeeTraining
    {

        [Key]
        public int EmployeeTrainingId { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int TrainingId { get; set; }

        public Training Training { get; set; }

    }
}
