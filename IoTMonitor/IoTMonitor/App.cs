using IoTMonitor.Helpers;
using IoTMonitor.Interfaces;
using IoTMonitor.Services;
using IoTMonitor.Model;

namespace IoTMonitor
{
    public partial class App
    {
        public App()
        {
        }

        public static void Initialize()
        {
            ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
        }
    }
}