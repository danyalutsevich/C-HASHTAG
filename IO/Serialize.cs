using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IO
{
    //[Serializable]
    public class Data
    {

        public int Field;
        public float Prop { get; set; }
        public List<string> Strings;


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Field = {Field},");
            sb.Append($"Prop = {Prop},");

            for (int i = 0; i < Strings.Count; i++)
            {

                sb.Append($"str[{i}] = {Strings[i]} ");
            }

            return String.Format(sb.ToString());

        }

    }
    class Serialize
    {


        public static void Main()
        {
            Data data = new Data
            {
                Field = 123,
                Prop = 321,
                Strings = new List<string>
                {
                "abc",
                "acab",
                "acdc"
                }
            };

            Console.WriteLine(data);

            //BinaryDemo(data);
            XmlDemo(data);


        }
        public static void BinaryDemo(Data data)
        {

            //Binary serializer
            BinaryFormatter bin = new BinaryFormatter();


            using (var binFile = new FileStream("ser.bin", FileMode.OpenOrCreate))
            {
                bin.Serialize(binFile, data);
            }

            //Deserializer

            using (var binFile = new FileStream("ser.bin", FileMode.Open))
            {

                var des = (Data)bin.Deserialize(binFile);

                Console.WriteLine(des);

            }



        }

        public static void XmlDemo(Data data)
        {

            XmlSerializer xml = new XmlSerializer(data.GetType());

            using (var xmlFile = new StreamWriter("ser.xml"))
            {
                xml.Serialize(xmlFile, data);

            }


            using (var xmlFile = new StreamReader("ser.xml"))
            {
                var des = (Data)xml.Deserialize(xmlFile);

                Console.WriteLine(des);

            }



        }



    }
}
