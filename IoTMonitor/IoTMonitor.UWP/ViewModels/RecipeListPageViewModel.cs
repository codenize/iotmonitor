
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace IoTMonitor.ViewModels
{
    [ImplementPropertyChanged]
    /// <summary>
    /// Encapsulates data for the CustomerListPage. The page UI
    /// binds to the properties defined here. 
    /// </summary>
    public class RecipeListPageViewModel : BindableBase
    {
        /// <summary>
        /// Creates a new CustomerListPageViewModel.
        /// </summary>
        public RecipeListPageViewModel()
        {
            //Task.Run(GetCustomerListAsync);
            //SyncCommand = new RelayCommand(OnSync);
        }
        
        /// <summary>
        /// The collection of customers in the list. 
        /// </summary>
        public ObservableCollection<CustomerViewModel> Customers { get; set; } = 
            new ObservableCollection<CustomerViewModel>(); 

        private CustomerViewModel _selectedCustomer;
        /// <summary>
        /// Gets or sets the selected customer, or null if no customer is selected. 
        /// </summary>
        public CustomerViewModel SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                SetProperty(ref _selectedCustomer, value); 
            }
        }

        private string _errorText = null;
        /// <summary>
        /// Gets or sets the error text.
        /// </summary>
        public string ErrorText
        {
            get { return _errorText; }

            set
            {
                SetProperty(ref _errorText, value);
            }
        }

        private bool _isLoading = false;
        /// <summary>
        /// Gets or sets whether to show the data loading progress wheel. 
        /// </summary>
        public bool IsLoading
        {
            get { return _isLoading; }

            set
            {
                SetProperty(ref _isLoading, value);
            }
        }

    }
}
