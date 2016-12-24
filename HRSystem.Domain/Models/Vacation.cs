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
        //Gokhan's Comments: Repository is a technology. It should be avoided on domain layer. Both instance and interface level. Clearly it is not a part of approving algorithm.
        //You can initialize repository on app level and pass its returning type as a parameter to a the model. (domain objects)
        //Same criticism applies for DataSource folder too. UOW should be on app layer. Domain is not technogy-agnostic here due to the dbcontext references, data types and algotihms. 
        //In an ideal domain model library there would be no need to create a folder named 'Models'. Every type is a model of a real world. They are purely domain objects, they are not a model of a any special technology or something.
        //IPayrollSystem parameter dependency is acceptable as an interface I think.(Interface only. And interface should stay in the same library.) I assume PayrollSystem is a part of domain analysis itself (elicited from domain experts) not like any aspects of the applicaion layer.
        //DomainEvents shouldnt have push you to the anemic model?! Invoking an event to the caller is a pure technique. You can place domain events on domain objects while retaining domain algorithms on domain objects still.
        //Finally, my generic advice would be writing unit tests(not integration you know :)) on Vacation(domain) object(s) without faking/stubbing any technology(repo,uow,etc.). If you can do that easily, we can call that pure domain model I think. 
        //I just realized I forgot IUserInfo part. User is a part of application flow. Both repo and usercontext/info should stay in app layer. (People solve that with ambientcontext pattern too. Its not that crutial.)
        //All of your questions are caused by a single architectural error i think: Lack of application/service layer.  
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
