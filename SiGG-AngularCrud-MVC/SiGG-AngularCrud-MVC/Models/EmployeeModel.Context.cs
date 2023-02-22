using SiGG_AngularCrud_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace SiGG_AngularCrud_MVC.Models
{
    public partial class EmployeeEntities : DbContext   
    {
        public EmployeeEntities ()
            : base("name=EmployeeEntities")   
        {
        }

        protected override void OnModeCreating(DbModeBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();  
        }

        public virtual DbSet<Employee> Employee { get; set; }   
    }
}