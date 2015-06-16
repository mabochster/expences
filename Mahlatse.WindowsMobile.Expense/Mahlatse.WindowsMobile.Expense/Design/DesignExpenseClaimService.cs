using Mahlatse.WindowsMobile.Expense.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahlatse.WindowsMobile.Expense.Design
{
    public class DesignExpenseClaimService : IDesignExpenseClaimService
    {
        
        public void List(Action<List<ExpenseClaim>> _callback)
        {
            var list = new List<ExpenseClaim>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(new ExpenseClaim { Name = "Name " + 1 });
            }

            _callback(list);
        }

        public void Add(ExpenseClaim entity, Action<ExpenseClaim> _callback)
        {
            throw new NotImplementedException();
        }

        public void Edit(string Id, Action<ExpenseClaim> _callback)
        {
            throw new NotImplementedException();
        }

        public void Delete(ExpenseClaim entity, Action<ExpenseClaim> _callback)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
