using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mahlatse.WindowsMobile.Expense.Model;
using Mahlatse.WindowsMobile.Expense.Service.Interface;
using System.Net.Http;
using Mahlatse.WindowsMobile.Expense.Constants;
using Newtonsoft.Json;

namespace Mahlatse.WindowsMobile.Expense.Service.Implementation
{
    public class ExpenseClaimService : IExpenseClaimService
    {
        private readonly HttpClient _client;

        public ExpenseClaimService()
        {
            _client = new HttpClient();
        }

        public void List(Action<List<ExpenseClaim>> _callback)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri(ServiceConstants.ListUrl));
            var response = _client.SendAsync(request);
            var result = response.Result.Content.ReadAsStringAsync();
            //get the list of 
            _callback(null);
            //var serializer = new JsonSerializer()//use json soft
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
