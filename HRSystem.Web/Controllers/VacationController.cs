using FrameworkX.Common.Infrastructure;
using HRSystem.Domain;
using HRSystem.Domain.Datasource;
using HRSystem.Domain.ServiceClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HRSystem.Web.Controllers
{
    public class VacationController : ApiController
    {
        public HRUnitOfWork UnitOfWork { get; set; }
        public IPayrollSystem PayrollClient { get; set; }

        public IUserProvider User { get; set; }

        [HttpPost]
        public void OpenVacationRequest(int requestedDays)
        {
            var currentEmployee = UnitOfWork.EmployeeRepository.GetCurrentEmployee();
            currentEmployee.OpenVacationRequest(requestedDays);
            UnitOfWork.SaveChanges();
        }

        public IEnumerable<Vacation> GetOpenRequests()
        {
            return this.UnitOfWork.VacationRepository.GetOpenRequests();
        }

        [HttpPost]
        public IHttpActionResult ApproveRequest(int vacationId)
        {
            var vacation = this.UnitOfWork.VacationRepository.GetById(vacationId);
            vacation.Approve(this.UnitOfWork.VacationRepository, this.PayrollClient, this.User);

            UnitOfWork.SaveChanges();

            return Ok();
        }
    }
}
