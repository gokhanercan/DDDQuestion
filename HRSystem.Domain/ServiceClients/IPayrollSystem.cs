using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Domain.ServiceClients
{
    public interface IPayrollSystem
    {
        void AddUnpaidVacation(int employeeId);
    }
}
