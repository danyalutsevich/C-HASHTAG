using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace IO
{
    public class Item
    {
        public string Title { get; set; }
        public float Price { get; set; }
        public float Sale { get; set; }

    }

    internal class XML
    {

        public static void Main()
        {
            Random random = new Random();

            Item[] items = new Item[5];
            items[0] = new Item() { Title = "title", Price = random.Next(1000), Sale = (float)random.NextDouble() * 10 };
            items[1] = new Item() { Title = "title", Price = random.Next(1000), Sale = (float)random.NextDouble() * 10 };
            items[2] = new Item() { Title = "title", Price = random.Next(1000), Sale = (float)random.NextDouble() * 10 };
            items[3] = new Item() { Title = "title", Price = random.Next(1000), Sale = (float)random.NextDouble() * 10 };
            items[4] = new Item() { Title = "title", Price = random.Next(1000), Sale = (float)random.NextDouble() * 10 };

            XmlSerializer serializer = new XmlSerializer(typeof(Item[]));

            using (var sr = new StreamWriter("xml.xml"))
            {
                serializer.Serialize(sr, items);
            }

        }



    }
}
