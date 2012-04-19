using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace AMEEInExcel
{
    class BuildWikiList
    {
        static List<String> wikiList;
        static int startPos = 20000;
        static int incrLimit = 100;


        public static List<String> MapWikiListNames()
        {
            try
            {
                wikiList = new List<String>();

                int pos = startPos;

                while (true)
                {
                    if (MapWikiNames(pos, incrLimit) == 0)
                        break;

                    pos += incrLimit;
                }

#if _DEBUG_OUTPUT_
            
            foreach (String nme in wikiList)
            {
                Console.Out.WriteLine("Wikiname: {0}", nme);
            }
            

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\tmp\WikiNames.txt", true))
            {


                foreach (String nme in wikiList)
                {
                    file.WriteLine("Wikiname:{0}", nme);
                }

            }

#endif


            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Exception in BuildWikiList "+ ex.Message);
            }

            return wikiList;
        }



        static void TestBuildWikiList()
        {
            wikiList = new List<String>();

            int pos = startPos;

            while (true)
            {
                if (MapWikiNames(pos, incrLimit) == 0)
                    break;

                pos += incrLimit;
            }

            /*
            foreach (String nme in wikiList)
            {
                Console.Out.WriteLine("Wikiname: {0}", nme);
            }
            */

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\tmp\WikiNames.txt", true))
            {

                foreach (String nme in wikiList)
                {
                    file.WriteLine("Wikiname:{0}", nme);
                }

            }

        }

        static int MapWikiNames(int startCat, int blockSize)
        {
            int recortCount = 0;

            String url = "https://platform-api-science.amee.com/3/categories?resultStart=" + startCat + "&resultLimit=" + blockSize;

            Console.Out.WriteLine("Url: " + url);

            HttpWebRequest request
                = WebRequest.Create(url) as HttpWebRequest;

            // Add authentication to request  
            request.Credentials = new NetworkCredential("calexander", "tr1nNy");
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Accept = "application/xml";

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
                    expr = nav.Compile("/Representation/Categories/Category");

                    XPathNodeIterator iterator = nav.Select(expr);

                    recortCount = nav.Select(expr).Count;
                    Console.Out.WriteLine(recortCount);

                    while (iterator.MoveNext())
                    {

                        iterator.Current.MoveToChild("Name", "");
                        //Console.Out.WriteLine(iterator.Current.Value.ToString());

                        iterator.Current.MoveToNext("WikiName", "");
                        //Console.Out.WriteLine(iterator.Current.Value.ToString());

                        wikiList.Add(iterator.Current.Value.ToString());

                    }

                    Console.Out.WriteLine("Count of Wikinames: {0}", wikiList.Count);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return recortCount;
        }

    }
}

