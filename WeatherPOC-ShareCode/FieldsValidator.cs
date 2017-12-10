using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeatherPOC_ShareCode
{
    public static class FieldsValidator
    {
        private const string REG_VALID_EMAIL = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        public static bool isValidEmail(string email) {
            bool result = false;
            if (!String.IsNullOrEmpty(email) && Regex.IsMatch(email, REG_VALID_EMAIL, RegexOptions.IgnoreCase)) {
                result = true;
            }
            return result;
        }

    }
}
