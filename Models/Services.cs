using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Models
{
    public class Services
    {
        public int ID { get; set; }
        public string Name { get; set; }
        //Spa Services:  full-day, half-day,two-hour, one-hour
        public string Classification { get; set; } = "Full";
        public double Fee { get; set; } = 200.00;
    }
}
