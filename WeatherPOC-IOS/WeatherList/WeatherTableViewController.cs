using Foundation;
using System;
using UIKit;
using WeatherPOC_IOS.WeatherList;
using WeatherPOC_IOS.Helpers;
using System.Threading.Tasks;
using WeatherPOC_ShareCode.WeatherModule;
using WeatherPOC_IOS.WeatherDetail;

namespace WeatherPOC_IOS
{
    public partial class WeatherTableViewController : UITableViewController
    {
        private LoadingOverlay loadPop;
        public WeatherTableViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            this.Signout.Clicked += PerforLogout;
            this.Refresh.Clicked += ReloadAction;

            var bounds = UIScreen.MainScreen.Bounds;
            loadPop = new LoadingOverlay(bounds);
            //TableView.Hidden = true;
            NavigationController.SetNavigationBarHidden(true, true);
            NavigationController.NavigationBar.BarTintColor = UIColor.FromRGB(238, 238, 238);
            NavigationController.NavigationBar.TintColor = UIColor.FromRGB(34, 40, 49);
            NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes
            {
                ForegroundColor = UIColor.FromRGB(34, 40, 49)
            };
            this.Add(loadPop);
        }

        public override void ViewDidAppear(bool animated)
        { 
            TableView.RegisterNibForCellReuse(UINib.FromName("Cell", null), "Cell");
            LoadDataTable();

        }

        private void PerforLogout(object sender, EventArgs e)
        {
            NSUserDefaults.StandardUserDefaults.RemovePersistentDomain(NSBundle.MainBundle.BundleIdentifier);
            NSUserDefaults.StandardUserDefaults.Synchronize();
            PerformSegue("GoLogin", this);

        }

        private void ReloadAction(object sender, EventArgs e)
        {
            var bounds = UIScreen.MainScreen.Bounds;
            loadPop = new LoadingOverlay(bounds);
            View.Add(loadPop);
            NavigationController.SetNavigationBarHidden(true, true);
            Task.Run(() => LoadDataTable());

        }

        private void LoadDataTable()
        {
            InvokeOnMainThread(() => {

                TableView.Source = new DataSource(this);
                TableView.ReloadData();
                loadPop.Hide();
                TableView.Hidden = false;
                NavigationController.SetNavigationBarHidden(false, true);
            });
        }


        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "GoWeatherDetail")
            {
                WeatherDetailViewController navctlr = segue.DestinationViewController as WeatherDetailViewController;
                if (navctlr != null)
                {
                    var source = TableView.Source as DataSource;
                    var rowPath = (NSIndexPath)sender;
                    WeatherData item = source.GetItem(rowPath.Row);
                    navctlr.CurrentWeather = item;
                }
            }
        }
    }
}