/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Mahlatse.WindowsMobile.Expense"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Mahlatse.WindowsMobile.Expense.Service.Implementation;
using Mahlatse.WindowsMobile.Expense.Service.Interface;
using Microsoft.Practices.ServiceLocation;

namespace Mahlatse.WindowsMobile.Expense.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<INavigationService, Design.DesignNavigationService>();
            }
            else
            {
                SimpleIoc.Default.Register<INavigationService>(() => new NavigationService());
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AddExpenseClaimViewModel>();
            SimpleIoc.Default.Register<EditExpenseClaimViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public EditExpenseClaimViewModel EditExpenseClaim
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditExpenseClaimViewModel>();
            }
        }

        public AddExpenseClaimViewModel AddExpenseClaim
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddExpenseClaimViewModel>();
            }
        }


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}