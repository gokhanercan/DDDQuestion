using HRSystem.Domain;
using HRSystem.Domain.Datasource;
using HRSystem.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Tests.Common
{
    public class HRSystemDatabaseInitializer : DropCreateDatabaseAlways<HumanResourcesDbContext>
    {
        public Employee EmployeeAliVeli { get; set; }
        public Employee Manager { get; set; }
        protected override void Seed(HumanResourcesDbContext db)
        {
            this.EmployeeAliVeli = new Employee { FullName = "Ali Veli", GrantedAnnualLeaveDays = 20 };
            this.Manager = new Employee { FullName = "Manager", GrantedAnnualLeaveDays = 20 };

            this.EmployeeAliVeli.Vacations.Add(new Vacation { Days = 19, Status = RequestStatus.Approved });

            db.Employees.AddRange(new[] { this.EmployeeAliVeli, this.Manager });
            db.SaveChanges();
        }
    }
}
