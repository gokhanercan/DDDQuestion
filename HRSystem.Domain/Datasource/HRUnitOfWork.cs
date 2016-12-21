using HRSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Domain.Datasource
{
    public class HRUnitOfWork
    {
        public HumanResourcesDbContext db { get; set; }
        public VacationRepository VacationRepository { get; set; }
        public EmployeeRepository EmployeeRepository { get; set; }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
