using HRSystem.Domain;
using HRSystem.Domain.Datasource;
using HRSystem.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Domain.Repositories
{
    public class VacationRepository
    {
        public HumanResourcesDbContext db { get; set; }

        public IEnumerable<Vacation> GetOpenRequests()
        {
            return db.Vacations.Where(vacation => vacation.Status == RequestStatus.RequestOpened);
        }
        public Vacation GetById(int vacationId)
        {
            return db.Vacations.Find(vacationId);
        }

        public int GetApprovedVacationDays(int employeeId)
        {
            return db.Vacations
                .Where(vacation => vacation.EmployeeId == employeeId && vacation.Status == RequestStatus.Approved)
                .Sum(izin => izin.Days);
        }
    }
}
