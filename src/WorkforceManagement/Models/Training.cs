using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkforceManagement.Models
{
    public class Training
    {
       [Key]

        public int TrainingId { get; set; }

        public string Topic { get; set; }
    }
}
