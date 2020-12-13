using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenMVC.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string Position { get; set; }
        public string Departament { get; set; }
        public decimal Version { get; set; }
    }
}