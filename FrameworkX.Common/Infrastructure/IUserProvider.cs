using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkX.Common.Infrastructure
{
    public interface IUserProvider
    {
        int CurrentUserId { get; }
    }
}
