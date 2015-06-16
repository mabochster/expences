using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahlatse.WindowsMobile.Expense.Service.Interface
{
    public interface IBaseService<T> where T : class
    {

        void Add(T entity,Action<T> _callback);
        void Edit(string Id, Action<T> _callback);
        void Delete(T entity,Action<T> _callback);
        void List(Action<List<T>> _callback);
        void Save();
        
        
    }
}
