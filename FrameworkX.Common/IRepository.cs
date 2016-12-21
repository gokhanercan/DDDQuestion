using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkX.Common
{
    public interface IRepository<TModel> where TModel : class
    {
        void Delete(TModel model);
        TModel FindById(int primaryFieldValue);
        void Insert(TModel model);
    }
}
