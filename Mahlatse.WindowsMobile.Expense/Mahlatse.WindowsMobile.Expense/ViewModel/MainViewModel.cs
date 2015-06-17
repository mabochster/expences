using GalaSoft.MvvmLight;
using Mahlatse.WindowsMobile.Expense.Common;
using Mahlatse.WindowsMobile.Expense.Message;
using Mahlatse.WindowsMobile.Expense.Model;
using Mahlatse.WindowsMobile.Expense.Service.Implementation;
using Mahlatse.WindowsMobile.Expense.Service.Interface;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace Mahlatse.WindowsMobile.Expense.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 

        private IExpenseClaimService _explenseClaimService;
        private INavigationService _iNavigationService;
        public MainViewModel(INavigationService _iNavigationService)
        {

            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
                _explenseClaimService = new Design.DesignExpenseClaimService();
            }
            else
            {
                // Code runs "for real"
                //_explenseClaimService = new Service.Implementation.ExpenseClaimService();
                _explenseClaimService = new Design.DesignExpenseClaimService();
            }

            this._iNavigationService = _iNavigationService;

            _explenseClaimService.List(result =>
                {
                    AllExpenseClaims = new ObservableCollection<ExpenseClaim>(result);
                });

            AddExpenseClaimCommand = new RelayCommand(() => AddExpenseClaim());
        }
        public const string AllExpensesPropertyChanged = "AllExpenseClaims";
        public string ApplicationTitle
        {
            get
            {
                return "Expense Claim MVVM Light";
            }
        }

        public string PageName
        {
            get
            {
                return "Expense Claims:";
            }
        }

        private ObservableCollection<ExpenseClaim> _expenseClaims = null;
        public string Welcome
        {
            get
            {
                return "Welcome to My Expense Cliam Page";
            }
        }

        public ObservableCollection<ExpenseClaim> AllExpenseClaims
        {
            get 
            {
                return _expenseClaims;
            }
            set
            {
                _expenseClaims = value;
                RaisePropertyChanged(AllExpensesPropertyChanged);
            }
        }
       //seclected item
        private ExpenseClaim _expenseClaim;
        public const string ExpenseClaimChanged = "ExpenseClaim";

        public ExpenseClaim ExpenseClaim
        {
            get
            {
                return _expenseClaim;
            }
            set
            {
                _expenseClaim = value;
                //RaisePropertyChanged(ExpenseClaimChanged);
                _iNavigationService.Navigate(typeof(AddEditExpenseClaim),ExpenseClaim);
            }
        }


        #region relay methods
        private void AddExpenseClaim()
        {
            _iNavigationService.Navigate(typeof(AddExpenseClaim));
        }

        public RelayCommand AddExpenseClaimCommand
        {
            get;
            private set;
        }

        #endregion
    }
}