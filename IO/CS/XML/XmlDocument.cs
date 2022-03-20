using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IO
{
    internal class XmlDocumentDemo
    {
        public static void Main()
        {
            XmlDoc();
        }

        public static void XmlDoc()
        {
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load("Products.xml");
                Console.WriteLine("Load");
            }
            catch
            {
                Console.WriteLine("Load err");
            }

            RecursivePrint(xmlDoc.DocumentElement.ChildNodes);

            //Console.WriteLine();
            //CreateNewProduct(xmlDoc);

            //PrintXml(xmlDoc.DocumentElement.ChildNodes);
        }

        public static void PrintXml(XmlNodeList chidNodes)
        {
            if (chidNodes.Count.Equals(0))
            {
                Console.WriteLine("Xml is empty");
            }
            else
            {
                foreach (XmlNode child in chidNodes)
                {
                    Console.Write($"Title:{child["Title"].InnerText} ");
                    Console.Write($"Price:{Convert.ToSingle(child["Price"].InnerText)} ");
                    Console.WriteLine($"Discount:{Convert.ToSingle(child["Discount"].InnerText)}");
                }
            }
        }

        public static void RecursivePrint(XmlNodeList chidNodes)
        {
            for (int i = 0; i < chidNodes.Count; i++)
            {
                for (int j = 0; j < chidNodes[i].ChildNodes.Count; j++)
                {
                    if (chidNodes[i].ChildNodes[j].HasChildNodes)
                    {
                        Console.Write($"{chidNodes[i].ChildNodes[j].Name}:");
                        Console.WriteLine(chidNodes[i].ChildNodes[j].InnerText);
                    }
                }

                if (chidNodes[i].HasChildNodes)
                {
                    RecursivePrint(chidNodes[i].ChildNodes);
                }
            }
            //Console.WriteLine();
        }

        public static void CreateNewProduct(XmlDocument xmlDocument)
        {
            XmlElement Product = xmlDocument.CreateElement("Product");
            XmlElement Title = xmlDocument.CreateElement("Title");
            XmlElement Price = xmlDocument.CreateElement("Price");
            XmlElement Discount = xmlDocument.CreateElement("Discount");

            Console.Write("Title for new product: ");
            Title.AppendChild(xmlDocument.CreateTextNode(Console.ReadLine()));
            Product.AppendChild(Title);

            Console.Write("Price for new product: ");
            Price.AppendChild(xmlDocument.CreateTextNode(Console.ReadLine()));
            Product.AppendChild(Price);

            Console.Write("Discount for new product: ");
            Discount.AppendChild(xmlDocument.CreateTextNode(Console.ReadLine()));
            Product.AppendChild(Discount);

            xmlDocument.DocumentElement.AppendChild(Product);
            xmlDocument.Save("Products.xml");
        }
    }
}
