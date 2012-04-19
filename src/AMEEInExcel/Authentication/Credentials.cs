using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AMEEInExcel.Authentication
{
    class Credentials
    {
        private static string _ameeUrl = string.Empty;
        private static string _ameeUserName = string.Empty;
        private static string _ameePassword = string.Empty;

        // account details: getters/setters 
        public static string Url
        {
            get
            {
                return _ameeUrl;
            }
            set
            {
                _ameeUrl = value;
            }
        }

        public static string UserName
        {
            get
            {
                return _ameeUserName;
            }
            set
            {
                _ameeUserName = value;
            }
        }

        public static string Password
        {
            get
            {
                return _ameePassword;
            }
            set
            {
                _ameePassword = value;
            }
        }
    }
}



