using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherPOC_ShareCode.LoginModule
{
    public interface ILoginRequests
    {
        bool ValidateLoginUser(string userName, string password);
    }
}
