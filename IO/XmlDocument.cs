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

            XmlElement xmlElement = xmlDoc.DocumentElement;

            PrintXml(xmlDoc.DocumentElement.ChildNodes);
            Console.WriteLine();
            CreateNewProduct(xmlDoc);
            PrintXml(xmlDoc.DocumentElement.ChildNodes);



        }


    }
}
