
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace IoTMonitor.UWP.Views
{
    public sealed partial class MainPivot : Page
    {
        //public ItemsViewModel BrowseViewModel { get; private set; }
        //public AboutViewModel AboutViewModel { get; private set; }

        Task loadItems;

        public MainPivot()
        {
            NavigationCacheMode = NavigationCacheMode.Required;

            InitializeComponent();

            //BrowseViewModel = new ItemsViewModel();
            //AboutViewModel = new AboutViewModel();

            //loadItems = BrowseViewModel.ExecuteLoadItemsCommand();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //if (BrowseViewModel.Items.Count == 0)
               // loadItems.Wait();
        }

        public void AddItem_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(AddItems), BrowseViewModel);
        }

        private void GvItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var item = e.ClickedItem as Item;
            //this.Frame.Navigate(typeof(BrowseItemDetail), item);
        }

        private void PivotItemChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((Pivot)sender).SelectedIndex)
            {
                case 0:
                    Toolbar.Visibility = Visibility.Visible;
                    break;
                case 1:
                    Toolbar.Visibility = Visibility.Collapsed;
                    break;
            }
        }
        #region Navigation

        /// <summary>
        /// Navigate to the Page for the selected <paramref name="listViewItem"/>.
        /// </summary>
        private void NavMenuList_ItemInvoked(object sender, ListViewItem listViewItem)
        {
            //foreach (var i in navlist)
            //{
            //    i.IsSelected = false;
            //}

            //var item = (NavMenuItem)((NavMenuListView)sender).ItemFromContainer(listViewItem);

            //if (item != null)
            //{
            //    item.IsSelected = true;
            //    if (item.DestPage != null &&
            //        item.DestPage != AppFrame.CurrentSourcePageType)
            //    {
            //        AppFrame.Navigate(item.DestPage, item.Arguments);
            //    }
            //}
        }

        /// <summary>
        /// Ensures the nav menu reflects reality when navigation is triggered outside of
        /// the nav menu buttons.
        /// </summary>
        private void OnNavigatingToPage(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                //var item = (from p in navlist where p.DestPage == e.SourcePageType select p).SingleOrDefault();

                //if (item == null && AppFrame.BackStackDepth > 0)
                //{
                //    // In cases where a page drills into sub-pages then we'll highlight the most recent
                //    // navigation menu item that appears in the BackStack
                //    foreach (var entry in MainPage.BackStack.Reverse())
                //    {
                //        item = (from p in navlist where p.DestPage == entry.SourcePageType select p).SingleOrDefault();
                //        if (item != null)
                //            break;
                //    }
                //}

                //foreach (var i in navlist)
                //{
                //    i.IsSelected = false;
                //}
                //if (item != null)
                //{
                //    item.IsSelected = true;
                //}

                //var container = (ListViewItem)NavMenuList.ContainerFromItem(item);

                //// While updating the selection state of the item prevent it from taking keyboard focus.  If a
                //// user is invoking the back button via the keyboard causing the selected nav menu item to change
                //// then focus will remain on the back button.
                //if (container != null) container.IsTabStop = false;
                //NavMenuList.SetSelectedItem(container);
                //if (container != null) container.IsTabStop = true;
            }
        }

        #endregion

        public Rect TogglePaneButtonRect { get; private set; }

        /// <summary>
        /// An event to notify listeners when the hamburger button may occlude other content in the app.
        /// The custom "PageHeader" user control is using this.
        /// </summary>
        public event TypedEventHandler<MainPivot, Rect> TogglePaneButtonRectChanged;

        /// <summary>
        /// Public method to allow pages to open SplitView's pane.
        /// Used for custom app shortcuts like navigating left from page's left-most item
        /// </summary>
        public void OpenNavePane()
        {
            TogglePaneButton.IsChecked = true;
            NavPaneDivider.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Hides divider when nav pane is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void RootSplitView_PaneClosed(SplitView sender, object args) =>
            NavPaneDivider.Visibility = Visibility.Collapsed;

        /// <summary>
        /// Callback when the SplitView's Pane is toggled closed.  When the Pane is not visible
        /// then the floating hamburger may be occluding other content in the app unless it is aware.
        /// </summary>
        private void TogglePaneButton_Unchecked(object sender, RoutedEventArgs e) =>
            CheckTogglePaneButtonSizeChanged();

        /// <summary>
        /// Callback when the SplitView's Pane is toggled opened.
        /// Restores divider's visibility and ensures that margins around the floating hamburger are correctly set.
        /// </summary>
        private void TogglePaneButton_Checked(object sender, RoutedEventArgs e)
        {
            NavPaneDivider.Visibility = Visibility.Visible;
            CheckTogglePaneButtonSizeChanged();
        }

        /// <summary>
        /// Check for the conditions where the navigation pane does not occupy the space under the floating
        /// hamburger button and trigger the event.
        /// </summary>
        private void CheckTogglePaneButtonSizeChanged()
        {
            if (RootSplitView.DisplayMode == SplitViewDisplayMode.Inline ||
                RootSplitView.DisplayMode == SplitViewDisplayMode.Overlay)
            {
                var transform = TogglePaneButton.TransformToVisual(this);
                var rect = transform.TransformBounds(new Rect(0, 0, TogglePaneButton.ActualWidth, TogglePaneButton.ActualHeight));
                TogglePaneButtonRect = rect;
            }
            else
            {
                TogglePaneButtonRect = new Rect();
            }

            var handler = TogglePaneButtonRectChanged;
            if (handler != null)
            {
                handler.DynamicInvoke(this, TogglePaneButtonRect);
            }
        }

        /// <summary>
        /// Enable accessibility on each nav menu item by setting the AutomationProperties.Name on each container
        /// using the associated Label of each item.
        /// </summary>s
        private void NavMenuItemContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            //if (!args.InRecycleQueue && args.Item != null && args.Item is NavMenuItem)
            //{
            //    args.ItemContainer.SetValue(AutomationProperties.NameProperty, ((NavMenuItem)args.Item).Label);
            //}
            //else
            //{
            //    args.ItemContainer.ClearValue(AutomationProperties.NameProperty);
            //}
        }
    }

}