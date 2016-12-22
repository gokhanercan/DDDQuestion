namespace HRSystem.Domain
{
    using Datasource;
    using FrameworkX.Common.Infrastructure;
    using Models.Enums;
    using Repositories;
    using ServiceClients;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Vacation")]
    public partial class Vacation
    {
        protected internal Vacation()
        {

        }
        internal static Vacation Create(Employee employee, int requestedDays)
        {
            return new Vacation
            {
                Days = requestedDays,
                Status = RequestStatus.RequestOpened,
                Employee = employee,
                AssignedManagerId = employee.ManagerId.Value
            };
        }
        public int Id { get; private set; }

        public int EmployeeId { get; private set; }
        public int AssignedManagerId { get; private set; }
        public int Days { get; internal set; }

        public RequestStatus Status { get; internal set; }
        protected internal virtual Employee Employee { get; private set; }

        //ToDo: Is it Ok?
        public void Approve(VacationRepository vacationRepository, IPayrollSystem payrollClient)
        {
            int sumOfPaidVacationDays = vacationRepository.GetApprovedVacationDays(this.EmployeeId);
            if (sumOfPaidVacationDays + this.Days > this.Employee.GrantedAnnualLeaveDays)
            {
                int unpaidVacationDays = sumOfPaidVacationDays + this.Days - this.Employee.GrantedAnnualLeaveDays;
                payrollClient.AddUnpaidVacation(unpaidVacationDays);
            }
            this.Status = RequestStatus.Approved;
        }
    }
}
