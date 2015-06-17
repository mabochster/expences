using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Mahlatse.WindowsMobile.Expense.Common;
using Mahlatse.WindowsMobile.Expense.Model;
using Mahlatse.WindowsMobile.Expense.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahlatse.WindowsMobile.Expense.ViewModel
{
    public class EditExpenseClaimViewModel : ViewModelBase
    {
        IExpenseClaimService _explenseClaimService;
        INavigationService _iNavigationService;

        public EditExpenseClaimViewModel(ExpenseClaim ExpenseCliam,INavigationService _iNavigationService)
        {
            
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
                _explenseClaimService = new Design.DesignExpenseClaimService();
            }
            else
            {
                // Code runs "for real"
                _explenseClaimService = new Service.Implementation.ExpenseClaimService();
            }
            this._iNavigationService = _iNavigationService;
            Messenger.Default.Register<ExpenseClaim>(
            this,
                claim =>
                {
                    ExpenseClaim = claim;
                });
            //_explenseClaimService.Edit(Id,result =>
            //{
            //    ExpenseClaim = result;
            //});
        }
        public ExpenseClaim _ExpenseClaim;
        public const string ExpensesPropertyChanged = "ExpenseClaim";

        public ExpenseClaim ExpenseClaim
        {
            get
            {
                return _ExpenseClaim;
            }
            set
            {
                _ExpenseClaim = value;
                RaisePropertyChanged(ExpensesPropertyChanged);
            }
        }

        #region relay methods
        private void EditExpenseClaim()
        {
            //navigate back to list
            _iNavigationService.Navigate(typeof(MainPage));
        }

        public RelayCommand EditExpenseClaimCommand
        {
            get;
            private set;
        }
        #endregion
    }
}
