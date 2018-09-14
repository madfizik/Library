using System.Collections.Generic;
using System.Xml.Linq;

namespace Library.DAL.FileOutput
{
    public static class Xml
    {
        public static void SaveItemsToXml<T>(IEnumerable<T> items, string path) where T : class
        {
            XDocument xDoc = new XDocument();
            XElement xmlItems = new XElement("publications");
            foreach (T item in items)
            {
                XElement xmlItem = new XElement(typeof(T).Name.ToLower());
                foreach (var property in item.GetType().GetProperties())
                {
                    XElement xmlItemElement = new XElement(property.Name, property.GetValue(item));
                    xmlItem.Add(xmlItemElement);
                }
                xmlItems.Add(xmlItem);
            }
            xDoc.Add(xmlItems);
            xDoc.Save(path);
        }

        public static void AddItemToXml<T>(T item, string path)
        {
            XDocument xDoc = XDocument.Load(path);
            XElement root = xDoc.Element("publications");
            XElement xmlItem = new XElement(typeof(T).Name.ToLower());
            foreach (var property in item.GetType().GetProperties())
            {
                XElement xmlItemElement = new XElement(property.Name, property.GetValue(item));
                xmlItem.Add(xmlItemElement);
            }
            root.Add(xmlItem);
            xDoc.Save(path);
        }
    }
}
