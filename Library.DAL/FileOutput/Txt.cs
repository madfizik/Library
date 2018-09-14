using System;
using System.Collections.Generic;
using System.IO;

namespace Library.DAL.FileOutput
{
    public static class Txt
    {
        public static void SaveItemsToTextFile<T>(IEnumerable<T> items, string path) where T : class
        {
            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(file, System.Text.Encoding.UTF8))
                    {
                        writer.WriteLine($"{typeof(T).Name}s: ");
                        foreach (var item in items)
                        {
                            writer.WriteLine(item.ToString());
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void SaveItemToTxtFile<T>(T item, string path)
        {
            using (FileStream file = new FileStream(path, FileMode.OpenOrCreate))
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(file, System.Text.Encoding.UTF8))
                    {
                        writer.WriteLine(item.ToString());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}