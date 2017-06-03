using System.ComponentModel;
using System.Runtime.CompilerServices;

using IoTMonitor.UWP.Models;
using IoTMonitor.UWP.Services;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace IoTMonitor.UWP.Views
{
    public sealed partial class DashboardsDetailPage : Page, INotifyPropertyChanged
    {
        private SampleModel _item;
        public SampleModel Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        public DashboardsDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Item = e.Parameter as SampleModel;
        }

        private void WindowStates_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            if (e.OldState == NarrowState && e.NewState == WideState)
            {
                NavigationService.GoBack();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
