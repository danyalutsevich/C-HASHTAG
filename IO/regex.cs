using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace IO
{
    class regex
    {
        public static void Main()
        {
            string str;
            do
            {
                Console.WriteLine("Enter string");
                str = Console.ReadLine();

                Password(str);
                //regDemo();
                //if (Password(str))
                {
                    //Console.WriteLine("contains");
                }
                //else
                {
                    //Console.WriteLine("not contains");
                }

            } while (str != String.Empty);
        }

        public static void Password(string str)
        {

            //Regex regex = new Regex(@"([\d\w])");

            if(!new Regex(@"\d").IsMatch(str))
            {
                Console.WriteLine("password should contain digits");
            }
            if (!new Regex(@"[A-Z]").IsMatch(str))
            {
                Console.WriteLine("password should contain Uppercase letters");
            }
            if (!new Regex(@"[a-z]").IsMatch(str))
            {
                Console.WriteLine("password should contain lowercase letters");
            }
            if (!new Regex(@"[!@#$%^&*()/.,<_>';{}-]").IsMatch(str))
            {
                Console.WriteLine("password should contain at least one of these symbols !@#$%^&*()/.,<>';{}-");
            }
            if (str.Length < 8)
            {
                Console.WriteLine("password length should be 8 symbols or more");
            }
            
        
        }

        public static bool Phone(string str)
        {

            Regex phone = new Regex(@"^(\+\d{0,3})?[(]?\d{0,3}[)]?\d{2,3}([- ]?)\d{2,3}\2\d{2}$");

            Console.WriteLine(phone);
            return phone.IsMatch(str);

        }

        public static void Name()
        {


            //Regex reg = new Regex(@"^\d+(\.?\d+)?$");

            
            //Regex reg = new Regex(@"^[A-ZА-Я][a-zа-я]+$");
            Regex reg = new Regex(@"^([A-ZА-Я]?[a-zа-я]*['-]?)*[A-ZА-Я][a-zа-я]+$");


            Console.WriteLine(reg);



            string str;
            do
            {
                Console.Write("Enter string : ");
                str = Console.ReadLine();

                if (reg.IsMatch(str))
                {
                    Console.WriteLine("contains");
                }
                else
                {
                    Console.WriteLine("not contains");
                }

            } while (str != String.Empty);



        }

        public static void regDemo()
        {
            string str;

            Regex Digit = new Regex(@"\d");
            Regex NonDigit = new Regex(@"\D");
            Regex Space = new Regex(@"\s");
            Regex NonSpace = new Regex(@"\S");
            Regex Word = new Regex(@"\w");
            Regex NonWord = new Regex(@"\W");
            Regex abc = new Regex(@"[abc]");
            Regex nonabc = new Regex(@"[^abc]");
            List<Regex> regList = new List<Regex>
            {
                Digit,NonDigit,Space,NonSpace,Word,NonSpace,abc,nonabc
            };


            do
            {
                Console.Write("Enter str: ");
                str = Console.ReadLine();

                for(int i=0;i<regList.Count;i++)
                {
                    if (regList[i].IsMatch(str))
                    {
                        Console.WriteLine($"+contains {regList[i]}");
                    }
                    else
                    {
                        Console.WriteLine($"-there is no {regList[i]}");
                    }

                }


                //if (Digit.IsMatch(str))
                //{
                //    Console.WriteLine("contains digit");
                //}
                //else
                //{
                //    Console.WriteLine("there is no digits");
                //}
                //if (NonDigit.IsMatch(str))
                //{
                //    Console.WriteLine("contains non digit");
                //}
                //else
                //{
                //    Console.WriteLine("there is no non digit");
                //}
                //if (Space.IsMatch(str))
                //{
                //    Console.WriteLine("contains space");
                //}
                //else
                //{
                //    Console.WriteLine("there is no spaces");
                //}
                //if (NonSpace.IsMatch(str))
                //{
                //    Console.WriteLine("contains non space");
                //}
                //else
                //{
                //    Console.WriteLine("there is no non spaces");
                //}
                //if (Word.IsMatch(str))
                //{
                //    Console.WriteLine("contains word");
                //}
                //else
                //{
                //    Console.WriteLine("there is no word");
                //}
                //if (NonWord.IsMatch(str))
                //{
                //    Console.WriteLine("contains non word");
                //}
                //else
                //{
                //    Console.WriteLine("threre is no non word");
                //}
                //if (abc.IsMatch(str))
                //{
                //    Console.WriteLine("contains a,b or c");
                //}
                //else
                //{
                //    Console.WriteLine("there is no a,b or c");
                //}
                //if (nonabc.IsMatch(str))
                //{
                //    Console.WriteLine("contains non a,b or c");
                //}
                //else
                //{
                //    Console.WriteLine("there is no non a,b or c");
                //}


            } while (str != String.Empty);


        }



    }
}
