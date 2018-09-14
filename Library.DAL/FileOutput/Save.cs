using System.Collections.Generic;

namespace Library.DAL.FileOutput
{
    public static class Save
    {
        public static void SaveItems<T>(IEnumerable<T> items, string path) where T : class
        {
            Txt.SaveItemsToTextFile(items, $"{path}.txt");
            Xml.SaveItemsToXml(items, $"{path}.xml");
        }

        public static void AddItem<T>(T item, string path)
        {
            Txt.SaveItemToTxtFile(item, $"{path}.txt");
            Xml.AddItemToXml(item, $"{path}.xml");
        }
    }
}