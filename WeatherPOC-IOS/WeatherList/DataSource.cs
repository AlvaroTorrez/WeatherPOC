using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using WeatherPOC_ShareCode.WeatherModule;


namespace WeatherPOC_IOS.WeatherList
{
    internal class DataSource : UITableViewSource
    {
        private WeatherTableViewController weatherTableViewController;

        public List<WeatherData> DepartmentList { get; set; }


        public DataSource(WeatherTableViewController weatherTableViewController)
        {
            this.weatherTableViewController = weatherTableViewController;
            WeatherRequests request = new WeatherRequests();
            DepartmentList = request.GetListDepartamentShortInfo();
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (Cell)tableView.DequeueReusableCell(Cell.Key, indexPath);
            cell.FillInfo(DepartmentList[indexPath.Row]);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return DepartmentList.Count;
        }
    }
}