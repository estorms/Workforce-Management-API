using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace WorkforceManagement.Models
{
    public class Computer
    {

        [Key]

        public int ComputerId { get; set; }

        public DateTime DatePurchased { get; set; }

        public string SerialNumber { get; set; }

    }
}
