using FrameworkX.Common.Infrastructure;
using HRSystem.Domain.Datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Domain.Repositories
{
    public class EmployeeRepository
    {
        public HumanResourcesDbContext db { get; set; }
        public IUserProvider User { get; set; }
        public Employee GetCurrentEmployee()
        {
            return db.Employees.Find(this.User.CurrentUserId);
        }
    }
}
