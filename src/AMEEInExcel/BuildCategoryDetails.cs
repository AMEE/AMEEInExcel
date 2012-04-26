using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
//using BaseClassNameSpace.Web.BaseServices;
//using DeriveClassNameSpace.Services.Web;
using System.Xml;
using System.Xml.XPath;
using AMEEInExcel.Model;

namespace AMEEInExcel
{

    class BuildCategoryDetails
    {
        static String _domain = "api.amee.com";
        static String _categoryName = "Greenhouse_gases_Global_warming_potentials";
        static String _apiVersion = "3";

        static String _requestUsername = "excel";
        static String _requestPassword = "qkdA33eM";
        static String _requestContentType = "application/x-www-form-urlencoded; charset=UTF-8";
        static String _requestAcceptType = "application/xml";

        static DataCategory categoryData;

        public static HttpWebRequest AMEEWebRequest(String urlStr)
        {
            HttpWebRequest request = WebRequest.Create(urlStr) as HttpWebRequest;

            // Add authentication to request  
            request.Credentials = new NetworkCredential(_requestUsername, _requestPassword);
            request.ContentType = _requestContentType;
            request.Accept = _requestAcceptType;

            return request;
        }

        public static DataCategory getCategoryDetails()
        {
            return categoryData;
        }

        public static void GetCategoryDetails(string categoryWikiName)
        {

            categoryData = new DataCategory();

            MapCategoryHeaderData(categoryWikiName);
            GetDataItems(_domain, categoryWikiName);

        }

        public static void MapElement(XPathNavigator nav, string fullElementName, ref string dataElementName) 
        {
            XPathExpression expr;
            expr = nav.Compile(fullElementName);
            XPathNodeIterator iterator = nav.Select(expr);

            while (iterator.MoveNext())
            {
                dataElementName = iterator.Current.Value.ToString();
            }        
        }

        public static void MapElementAttribute(XPathNavigator nav, string fullElementName, string AttributeName, ref string dataElementName) 
        {
            XPathExpression expr;
            expr = nav.Compile(fullElementName);
            XPathNodeIterator iterator = nav.Select(expr);

            while (iterator.MoveNext())
            {
                dataElementName = iterator.Current.GetAttribute(AttributeName, "");
            }        
        }

        public static void MapCategoryHeaderData(String categoryName)
        {

            /*
             * Get the Category level details from the platform
             * these will be used to populate the spreadsheet for each item uid
             */
            String url = "https://" + _domain + "/" + _apiVersion + "/" + "categories" + "/" + categoryName;

            HttpWebRequest request = AMEEWebRequest(url + ";full");

            try
            {
                // Get response  
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {

                    // Get the response stream  
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    XPathDocument doc = new XPathDocument(reader);
                    XPathNavigator nav = doc.CreateNavigator();

                    MapElement(nav, "/Representation/Category/WikiName", ref categoryData.WikiName);
                    MapElement(nav, "/Representation/Category/Path", ref categoryData.Path);

                    MapElementAttribute(nav, "/Representation/Category", "uid", ref categoryData.Uid);
                    MapElementAttribute(nav, "/Representation/Category", "created", ref categoryData.Created);
                    MapElementAttribute(nav, "/Representation/Category", "modified", ref categoryData.Modified);

                    MapElement(nav, "/Representation/Category/FullPath", ref categoryData.FullPath);
                    MapElement(nav, "/Representation/Category/Name", ref categoryData.Name);
                    MapElement(nav, "/Representation/Category/Path", ref categoryData.Path);

                    MapElement(nav, "/Representation/Category/FullPath", ref categoryData.FullPath);
                    MapElement(nav, "/Representation/Category/ParentUid", ref categoryData.ParentUid);

                    MapElement(nav, "/Representation/Category/ParentWikiName", ref categoryData.ParentWikiName);

                    MapElement(nav, "/Representation/Category/Authority", ref categoryData.Authority);

                    MapElement(nav, "/Representation/Category/History", ref categoryData.History);
                    MapElement(nav, "/Representation/Category/Provenance", ref categoryData.Provenance);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        public static void GetDataItems(String domain, String categoryName)
        { 
            int startItem = 0;
            int numberItems = 100; // 100 appears to be the maximum

            while (GetDataItems(domain, categoryName, startItem, numberItems))
            {
                startItem += numberItems;
            }
            
        }

        public static Boolean GetDataItems(String domain, String categoryName,int start,int limit)
        {
            Boolean truncated = false; 

            // https://api-stage.amee.com/3/categories/Kitchen_Clothes_Washers/items;full?resultStart=301&resultLimit=100

            String url = "https://" + domain + "/" + _apiVersion + "/" + "categories" + "/" + categoryName + "/items;full" + "?resultStart=" + start + "&resultLimit=" + limit;

            HttpWebRequest request = AMEEWebRequest(url);

            try
            {
                // Get response  
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    String truncatedStr = "false";

                    // Get the response stream  
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    XPathDocument doc = new XPathDocument(reader);
                    XPathNavigator nav = doc.CreateNavigator();

                    try
                    {
                        MapElementAttribute(nav, "/Representation/Items", "truncated", ref truncatedStr);
                        truncated = Boolean.Parse(truncatedStr);
                    }
                    catch (ArgumentException)
                    {
                        truncated = false;
                    }
                    catch (FormatException)
                    {
                        truncated = false;                        
                    }  


                    XPathExpression expr;
                    expr = nav.Compile("/Representation/Items/Item");
                    XPathNodeIterator iterator = nav.Select(expr);

                    int cntr = 0;

                    if (categoryData.item == null)
                    {
                        cntr = 0;
                        // 1st time - a simple allocation of memory
                        categoryData.item = new DataItem[iterator.Count];
                    }
                    else
                    {
                        cntr = categoryData.item.Length;
                        // subsequent times - need to resize the array                                        
                        Array.Resize(ref categoryData.item, categoryData.item.Length + iterator.Count);
                    }

                    while (iterator.MoveNext())
                    {

                        categoryData.item[cntr] = new DataItem();

                        categoryData.item[cntr].Uid = iterator.Current.GetAttribute("uid", "");

                        categoryData.item[cntr].Created = iterator.Current.GetAttribute("created", "");
                        categoryData.item[cntr].Modified = iterator.Current.GetAttribute("modified", "");

                        iterator.Current.MoveToChild("Name", "");
                        categoryData.item[cntr].Name = iterator.Current.Value.ToString();

                        iterator.Current.MoveToParent();
                        iterator.Current.MoveToChild("Label", "");
                        categoryData.item[cntr].Label = iterator.Current.Value.ToString();

                        iterator.Current.MoveToParent();
                        iterator.Current.MoveToChild("Path", "");
                        categoryData.item[cntr].Path = iterator.Current.Value.ToString();

                        iterator.Current.MoveToParent();
                        iterator.Current.MoveToChild("FullPath", "");
                        categoryData.item[cntr].FullPath = iterator.Current.Value.ToString();

                        iterator.Current.MoveToParent();
                        iterator.Current.MoveToChild("CategoryUid", "");
                        categoryData.item[cntr].CategoryUid = iterator.Current.Value.ToString();

                        iterator.Current.MoveToParent();
                        iterator.Current.MoveToChild("CategoryWikiName", "");
                        categoryData.item[cntr].CategoryWikiName = iterator.Current.Value.ToString();

                        iterator.Current.MoveToParent();
                        iterator.Current.MoveToChild("WikiDoc", "");
                        categoryData.item[cntr].WikiDoc = iterator.Current.Value.ToString();

                        iterator.Current.MoveToParent();
                        iterator.Current.MoveToChild("Provenance", "");
                        categoryData.item[cntr].Provenance = iterator.Current.Value.ToString();

                        // Values will have N subnodes to process
                        iterator.Current.MoveToParent();
                        iterator.Current.MoveToChild("Values", "");


                        //string xml = iterator.Current.InnerXml;

                        XmlReaderSettings set = new XmlReaderSettings();
                        set.ConformanceLevel = ConformanceLevel.Fragment;

                        XPathDocument valuesdoc = new XPathDocument(XmlReader.Create(new StringReader(iterator.Current.InnerXml), set));

                        XPathNavigator valuesnav = valuesdoc.CreateNavigator();

                        Console.Out.WriteLine(valuesnav.Select("/Value").Count);

                        // need to sort the values otherwise  

                        //XPathExpression selectExpression = navigator.Compile("sales/item/@sTime");
                        //selectExpression.AddSort("@sTime",
                        //    XmlSortOrder.Descending,
                        //    XmlCaseOrder.None,
                        //    "",
                        //    XmlDataType.Number);

                        XPathExpression selectExpression = valuesnav.Compile("/Value");
                        selectExpression.AddSort("Path",
                            XmlSortOrder.Ascending,
                            XmlCaseOrder.None,
                            "",
                            XmlDataType.Text);

                        XPathNodeIterator valuesiterator = valuesnav.Select(selectExpression);

                        categoryData.item[cntr].ItemValues = new ItemValue[valuesnav.Select("/Value").Count];

                        int valueCntr = 0;

                        while (valuesiterator.MoveNext())
                        {

                            categoryData.item[cntr].ItemValues[valueCntr] = new ItemValue();

                            // there isn't an XML schema available from the platform team (sigh!)
                            // so it looks like we have to test for the existence of each node from each response
                            // yes, I know  (it's not my architecture so I can't do anything about it)

                            if (TestNode(valuesiterator.Current.OuterXml, "Value/Path"))
                            {

                                valuesiterator.Current.MoveToChild("Path", "");
                                categoryData.item[cntr].ItemValues[valueCntr].Path = valuesiterator.Current.Value.ToString();
                                valuesiterator.Current.MoveToParent();
                            }

                            if (TestNode(valuesiterator.Current.OuterXml, "Value/Value"))
                            {

                                valuesiterator.Current.MoveToChild("Value", "");
                                categoryData.item[cntr].ItemValues[valueCntr].Value = valuesiterator.Current.Value.ToString();
                                valuesiterator.Current.MoveToParent();
                            }

                            if (TestNode(valuesiterator.Current.OuterXml, "Value/Name"))
                            {                                
                                valuesiterator.Current.MoveToChild("Name", "");
                                categoryData.item[cntr].ItemValues[valueCntr].Name = valuesiterator.Current.Value.ToString();

                                valuesiterator.Current.MoveToParent();
                            }


                            if (TestNode(valuesiterator.Current.OuterXml, "Value/Unit"))
                            {                                
                                valuesiterator.Current.MoveToChild("Unit", "");
                                categoryData.item[cntr].ItemValues[valueCntr].Unit = valuesiterator.Current.Value.ToString();
                                valuesiterator.Current.MoveToParent();
                            }
                            valueCntr++;
                        }

                        cntr++;
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return truncated;
        }

        public static Boolean TestNode(string xmlFragment, string nodeName)
        {

            // this is quite expensive just to test for the existance of a node
            // but I havent been able to determine a better way using XPathNodeIterator

            try
            {
                // TODO: Revise & optimise
                XPathDocument doc = new XPathDocument(new StringReader(xmlFragment));
                XPathNavigator n = doc.CreateNavigator().SelectSingleNode(nodeName);
                if (n == null)
                    //Node does not exist
                    return false;
                else
                    return true;
            }
            catch (System.Xml.XmlException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region SUPPLEMENTAL_INFO

        public static void GetItemUids(String domain, String categoryName)
        {

            String url = "https://" + domain + "/" + _apiVersion + "/" + "categories" + "/" + categoryName;

            // var parameters = new Dictionary<string, string>() { { "uid", "uid" } };

            HttpWebRequest request = WebRequest.Create(url + "/items") as HttpWebRequest;

            // Add authentication to request  
            request.Credentials = new NetworkCredential(_requestUsername, _requestPassword);
            request.ContentType = _requestContentType;
            request.Accept = _requestAcceptType;

            try
            {
                // Get response  
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream  
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    XPathDocument doc = new XPathDocument(reader);
                    XPathNavigator nav = doc.CreateNavigator();

                    XPathExpression expr;
                    expr = nav.Compile("/Representation/Items/Item");
                    XPathNodeIterator iterator = nav.Select(expr);

                    iterator.MoveNext();

                    Console.Out.WriteLine(iterator.Current.GetAttribute("uid", "")/*.Value.ToString()*/);
                    //GetItemDefinition(iterator.Current.GetAttribute("uid", ""));

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void GetItemData(string uid)
        {

            String url = "https://" + _domain + "/" + _apiVersion + "/" + "categories" + "/" + _categoryName;

            HttpWebRequest request = AMEEWebRequest(url + "/items/" + uid + ";full");

            // var parameters = new Dictionary<string, string>() { { "uid", "uid" } };

            try
            {
                // Get response  
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {

                    // Get the response stream  
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    XPathDocument doc = new XPathDocument(reader);
                    XPathNavigator nav = doc.CreateNavigator();

                    XPathExpression expr;
                    expr = nav.Compile("/Representation/Item/ItemDefinition");  // this is a single item so the path is different
                    XPathNodeIterator iterator = nav.Select(expr);

                    iterator.MoveNext();
                    iterator.Current.GetAttribute("uid", "");

                    Console.Out.WriteLine("Itemdef: " + iterator.Current.GetAttribute("uid", ""));









                    expr = nav.Compile("/Representation/Item/Values/Value");  // this is a single item so the path is different
                    iterator = nav.Select(expr);

                    while (iterator.MoveNext())
                    {
                        iterator.Current.MoveToChild("Path", "");
                        Console.Out.WriteLine("Path: " + iterator.Current.Value.ToString());
                        iterator.Current.MoveToChild("Value", "");
                        Console.Out.WriteLine("Value: " + iterator.Current.Value.ToString());
                    }




                    GetDrillDown(iterator.Current.GetAttribute("uid", ""));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public static void GetDrillDown(String uid)
        {

            String url = "https://" + _domain + "/" + _apiVersion + "/" + "definitions" + "/" + uid + ";full";

            // var parameters = new Dictionary<string, string>() { { "uid", "uid" } };

            HttpWebRequest request = AMEEWebRequest(url);

            try
            {
                // Get response  
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {

                    // Get the response stream  
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    XPathDocument doc = new XPathDocument(reader);
                    XPathNavigator nav = doc.CreateNavigator();

                    XPathExpression expr;
                    expr = nav.Compile("/Representation/ItemDefinition/DrillDown");  // this is a single item so the path is different
                    XPathNodeIterator iterator = nav.Select(expr);
                    iterator.MoveNext();

                    Console.Out.WriteLine("DrillDown: " + iterator.Current.Value.ToString());


                    string[] words = iterator.Current.Value.ToString().Split(',');
                    foreach (string word in words)
                    {
                        Console.WriteLine(word);
                    }


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public static void BuildCategoryUIDPaths(String categoryName)
        {

            List<String> uids = new List<String>();
            String wikiName = "";
            String fullPath = "";

            // var parameters = new Dictionary<string, string>() { { "uid", "uid" } };

            String url = "https://" + _domain + "/" + _apiVersion + "/" + "categories" + "/" + categoryName;

            HttpWebRequest request = AMEEWebRequest(url + "/items");

            try
            {
                // Get response  
                // need to generate a list of item uids to fetch the details for each in turn
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream  
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    XPathDocument doc = new XPathDocument(reader);
                    XPathNavigator nav = doc.CreateNavigator();

                    XPathExpression expr;
                    expr = nav.Compile("/Representation/Items/Item");
                    XPathNodeIterator iterator = nav.Select(expr);

                    while (iterator.MoveNext())
                    {

                        uids.Add(iterator.Current.GetAttribute("uid", ""));

                        //Console.Out.WriteLine(iterator.Current.GetAttribute("uid", "")/*.Value.ToString()*/);
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        #endregion
    }
}

