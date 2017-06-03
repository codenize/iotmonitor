using IoTMonitor.UWP.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace IoTMonitor.UWP.Views
{
    public sealed partial class GatewaysDetailControl : UserControl
    {
        public SampleModel MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as SampleModel; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem",typeof(SampleModel),typeof(GatewaysDetailControl),new PropertyMetadata(null));

        public GatewaysDetailControl()
        {
            InitializeComponent();
        }
    }
}
