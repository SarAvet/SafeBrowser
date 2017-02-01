using System;
using System.Collections.Generic;
using System.Resources;
using System.Xml.Linq;

namespace WpfApplication1
{
    
    class URLGroup
    {
        public delegate void SetButtonName(URL old, URL newURL);
        static public SetButtonName onURLsUpdate;

        public delegate void SetEnableToolBar(bool state);
        static public SetEnableToolBar onCloseEditWindow;

        public delegate void BrowserNavigate();
        static public BrowserNavigate onSaveAndGo;

        public static string FileName = "URLs.xml";

        public static List<URL> urls;

        public static void initURLs()
        {
            int i = 1;
            List<URL> result = new List<URL>();
            XDocument urlsDoc = XDocument.Load(FileName);

            foreach (XElement element in urlsDoc.Root.Elements())
            {
                string href = element.Attribute("href").Value;
                string name = element.Attribute("name").Value;

                if (href.Equals(""))
                    href = "http://localhost";

                if (name.Equals(""))
                {
                    name = "Без имени " + i;
                    i++;
                }


                result.Add(new URL(name, href));
            }
            
            

            urls = result;
        }

        static public bool isExists(Predicate<URL> condition)
        {
            if (urls == null)
                return false;

            return urls.Exists(condition);
        }

        static public URL findURL(Predicate<URL> condition)
        {
            return urls.Find(condition);
        }

        static public void setActive(URL activeUrl)
        {
            foreach (URL url in urls)
                if (url.Equals(activeUrl))
                    url.isActive = true;
                else
                    url.isActive = false;
        }

        static public void updateURL(URL oldURL, URL newURL)
        {
            XDocument urlsDoc = XDocument.Load(FileName);

            foreach(XElement elements in urlsDoc.Root.Elements())
                if(elements.Attribute("name").Value.Equals(oldURL.Name))
                {
                    elements.Attribute("name").Value = newURL.Name;
                    elements.Attribute("href").Value = newURL.Href;
                }

            urlsDoc.Save(FileName);
            newURL.isActive = true;
            urls.Insert(urls.IndexOf(oldURL), newURL);
            urls.Remove(oldURL);

            if (onURLsUpdate!=null)
                onURLsUpdate.Invoke(oldURL,newURL);
        }
        

    }
}
