using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace SiGG_AngularCrud_MVC.Models
{
    public partial class Employee
    {
        public int Emp_Id { get; set; }
        public string Emp_Name { get; set; }
        public string Emp_City { get; set; }
        public Nullable<int> Emp_Age { get; set; }
    }
}