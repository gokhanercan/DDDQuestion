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
        protected internal Vacation(int requestedDays)
        {
            this.Days = requestedDays;
            this.Status = RequestStatus.RequestOpened;
        }
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int Days { get; set; }

        public RequestStatus Status { get; set; }
        public int ApprovedUserId { get; set; }

        protected internal virtual Employee Employee { get; set; }

        //ToDo: Is it Ok?
        public void Approve(VacationRepository vacationRepository, IPayrollSystem payrollClient, IUserProvider userInfo)
        {
            int sumOfPaidVacationDays = vacationRepository.GetApprovedVacationDays(this.EmployeeId);
            if (sumOfPaidVacationDays + this.Days > this.Employee.GrantedAnnualLeaveDays)
            {
                int unpaidVacationDays = sumOfPaidVacationDays + this.Days - this.Employee.GrantedAnnualLeaveDays;
                payrollClient.AddUnpaidVacation(unpaidVacationDays);
            }
            this.Status = RequestStatus.Approved;
            this.ApprovedUserId = userInfo.CurrentUserId;
        }
    }
}
