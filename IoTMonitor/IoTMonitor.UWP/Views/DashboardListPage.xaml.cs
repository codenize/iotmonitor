
using IoTMonitor.ViewModels;
using PropertyChanged;
using System;
using Windows.ApplicationModel.Email;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace IoTMonitor.Views
{
    /// <summary>
    /// Displays the list of orders.
    /// </summary>
    [ImplementPropertyChanged]
    public sealed partial class OrderListPage : Page
    {
        /// <summary>
        /// We use this object to bind the UI to our data. 
        /// </summary>
        public RecipeListPageViewModel ViewModel { get;  } = new RecipeListPageViewModel();

        /// <summary>
        /// Creates a new OrderListPage.
        /// </summary>
        public OrderListPage()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Retrieve the list of orders when the user navigates to the page. 
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        
    }
}
