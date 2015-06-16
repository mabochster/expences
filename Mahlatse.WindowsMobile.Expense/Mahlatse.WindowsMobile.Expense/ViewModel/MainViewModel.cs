using GalaSoft.MvvmLight;
using Mahlatse.WindowsMobile.Expense.Message;
using Mahlatse.WindowsMobile.Expense.Model;
using Mahlatse.WindowsMobile.Expense.Service.Interface;
using System.Collections.ObjectModel;

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
        public MainViewModel()
        {
            IExpenseClaimService _explenseClaimService;
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

            _explenseClaimService.List(result =>
                {
                    AllExpenseClaims = new ObservableCollection<ExpenseClaim>(result);
                });
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

        #region methods

        private object ReceiveMessage(NavigateToPageMessage action)
        {
            var page = string.Format("/View/{0}View.xaml", action.PageName);

            if (action.PageName == "Main")
            {
                page = "/MainPage.xaml";
            }

            return null;
            //NavigationService.Navigate(
            //   new System.Uri(page,
            //         System.UriKind.Relative));
            //return null;
        }
        #endregion
    }
}