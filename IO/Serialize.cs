using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace IO
{
    //[Serializable]
    public class Data
    {

        [JsonInclude]
        public int Field;
        public float Prop { get; set; }
        [JsonInclude]
        public List<string> Strings;

        public Dictionary<string, string> Dict { get; set; }

        public Data()
        {
            Dict = new Dictionary<string, string>();
            Dict.Add("a", "all");
            Dict.Add("12", "cops");

        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Field = {Field},");
            sb.Append($"Prop = {Prop},");

            for (int i = 0; i < Strings.Count; i++)
            {

                sb.Append($"str[{i}] = {Strings[i]} ");
            }


            foreach(var i in Dict)
            {

                sb.Append($" {i.Key} {i.Value} ");


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
            //XmlDemo(data);
            JsonDemo(data);


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
        public static void JsonDemo(Data data)
        {

            using (var jsonFile = new StreamWriter("ser.json"))
            {

                jsonFile.Write(JsonSerializer.Serialize<Data>(data));
                //JsonSerializer.Serialize(data,data.GetType());

            }
            using (var jsonFile = new StreamReader("ser.json"))
            {
                var res = JsonSerializer.Deserialize<Data>(jsonFile.ReadToEnd());

                Console.WriteLine(res);
            }



        }


    }
}
