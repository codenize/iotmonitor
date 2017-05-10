using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace IoTMonitor.UWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageC : Page, INotifyPropertyChanged
    {


        public PageC()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

           
            await Task.Run(() =>
            {
               //Do Work Here

            });

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            this.SizeChanged -= StatsPage_SizeChanged;
        }

        private double _pageWidth = Window.Current.Bounds.Width;
        private int barMargin = 5;

        private void StatsPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.ActualWidth < 720)
            {
                barMargin = 2;
            }
            else
            {
                barMargin = 5;
            }

            _pageWidth = this.ActualWidth - 96 - (barMargin * 31);

           
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

       
    }
}