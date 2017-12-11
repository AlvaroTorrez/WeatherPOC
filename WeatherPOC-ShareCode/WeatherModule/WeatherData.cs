using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherPOC_ShareCode.WeatherModule
{
    public class WeatherData
    {
        public QueryData Query { get; set; }

    }

    public class QueryData
    {
        public string Count { get; set; }
        public ResultData Results { get; set; }

    }

    public class ResultData
    {
        public ChannelData Channel { get; set; }
    }

    public class WeatherListData
    {
        public QueryListData Query { get; set; }

    }

    public class QueryListData
    {
        public string Count { get; set; }
        public ResultListData Results { get; set; }

    }

    public class ResultListData
    {
        public List<ChannelData> Channel { get; set; }
    }

    public class ChannelData
    {
        public string Title { get; set; }
        public UnitsData Units { get; set; }
        public LocationData Location { get; set; }
        public ItemData Item { get; set; }
    }

    public class UnitsData
    {
        public string Distance { get; set; }
        public string Pressure { get; set; }
        public string Speed { get; set; }
        public string Temperature { get; set; }
    }

    public class LocationData
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
    }

    public class ItemData
    {
        public ConditionData Condition { get; set; }
    }

    public class ConditionData
    {
        public string Code { get; set; }
        public string Date { get; set; }
        public string Temp { get; set; }
        public string Text { get; set; }
    }
}
