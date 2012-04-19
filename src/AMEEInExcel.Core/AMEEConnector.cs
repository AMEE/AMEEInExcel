using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using AMEEClient;
//using AMEEClient.CS.Model;
//using AMEEClient.Model;
using AMEE;
using AMEE.Model;


namespace AMEEInExcel.Core
{
    public class AMEEConnector
    {
        private Client _client;
        private static string _ameeUrl = "https://api.amee.com";
        private static string _ameeUserName = "excel";
        private static string _ameePassword = "qkdA33eM";
        //private string _ameeUrl = string.Empty;
        //private string _ameeUserName = string.Empty;
        //private string _ameePassword = string.Empty;

        public AMEEConnector()
        {
            _client = new Client(new Uri(_ameeUrl), _ameeUserName, _ameePassword);
        }

        public AMEEConnector(string ameeUrl, string ameeUserName, string ameePassword)
        {
            _client = new Client(new Uri(ameeUrl), ameeUserName, ameePassword);
        }

        public string GetDataItemLabel(string path, string uid)
        {
            var dataItemResponse = _client.GetDataItem(path, uid);
            return dataItemResponse.DataItem.Label;
        }


        public string GetDataItemUnit(string path, string uid)
        {
            var dataItemResponse = _client.GetDataItem(path, uid);
            return dataItemResponse.Amount.Unit;
        }

        public string GetDataItemPerUnit(string path, string uid)
        {
            var dataItemResponse = _client.GetDataItem(path, uid);
            return dataItemResponse.Amount.PerUnit;
        }


        public string GetDataItemUnit(string path, string uid, string valuePath)
        {
            var dataItemResponse = _client.GetDataItem(path, uid);
            var dataItemValue = dataItemResponse.DataItem.ItemValues.First(v => v.ItemValueDefinition.Path == valuePath).Unit;
            return dataItemValue;
        }

        public string GetDataItemPerUnit(string path, string uid, string valuePath)
        {
            var dataItemResponse = _client.GetDataItem(path, uid);
            var dataItemValue = dataItemResponse.DataItem.ItemValues.First(v => v.ItemValueDefinition.Path == valuePath).PerUnit;
            return dataItemValue;
        }

        public string GetDataItemValue(string path, string uid, string valuePath)
        {
            var dataItemResponse = _client.GetDataItem(path, uid);
            var dataItemValue = dataItemResponse.DataItem.ItemValues.First(v => v.ItemValueDefinition.Path == valuePath).Value;
            return dataItemValue;
        }

        public string Calculate(string path, string uid, string amountType, string argName, string argValue)
        {
            var dataItemResponse = _client.Calculate(path, uid, new ValueItem(argName, argValue));
            var dataItemValue = dataItemResponse.Amounts.Amount.First(a => a.Type == amountType).Value;
            return dataItemValue;
        }


        // Kludge 
        public void MapCredentials(string ameeUrl, string ameeUserName, string ameePassword)
        {
            _ameeUrl = ameeUrl;
            _ameeUserName = ameeUserName;
            _ameePassword = ameePassword;
        }



        // account details: getters/setters 
        public string Url
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

        public string UserName
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

        public string Password
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
