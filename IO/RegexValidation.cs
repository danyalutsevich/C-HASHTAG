using System;
using System.Text.RegularExpressions;

namespace IO
{
    internal class RegexValidation
    {
        public static void Main()
        {
            string str;
            do
            {
                Console.Write("Enter string: ");
                str = Console.ReadLine();
                Console.WriteLine($"{nameof(IsLogin)} : {IsLogin(str)}");
                Console.WriteLine($"{nameof(IsPassword)} : {IsPassword(str)}");
                Console.WriteLine($"{nameof(IsName)} : {IsName(str)}");
                Console.WriteLine($"{nameof(IsEmail)} : {IsEmail(str)}");
                Console.WriteLine($"{nameof(IsPhone)} : {IsPhone(str)}");

            } while (str != String.Empty);

        }
        public static bool IsLogin(string str)
        {
            return new Regex(@"^[A-Za-z\d]+$").IsMatch(str);
        }
        public static bool IsPassword(string str)
        {
            return new Regex(@"^[A-Za-z\d!@#$%^&*()/*-<>/';:]{6,}$").IsMatch(str);
        }
        public static bool IsName(string str)
        {
            return new Regex(@"^(([A-ZА-Я]?[a-zа-я]*['-]?)*[A-ZА-Я][a-zа-я]+) \1$").IsMatch(str);
        } 
        public static bool IsEmail(string str)
        {
            return new Regex(@"^[\dA-Za-z]+@[a-z]+.[a-z]+$").IsMatch(str);
        }
        public static bool IsPhone(string str)
        {
            return new Regex(@"^(\+\d{0,3})?[(]?\d{0,3}[)]?\d{2,3}([- ]?)\d{2,3}\2\d{2}$").IsMatch(str);
        }

    }
}
