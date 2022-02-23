using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Text.Json;
//using System.Text.Json.Serialization;//in case u have .NET core version < 5

namespace IO
{
    public class User
    {
        //[JsonInclude]
        public string login { get; set; }
        //[JsonInclude]
        public string pass { get; set; }
                public string LastLogin { get; set; }
        public string RealName { get; set; }
        public override string ToString()
        {
            return $"{RealName} ({login}) : {LastLogin}";
        }
    }

    class auth
    {
        public static List<User> users;
        static auth()
        {
            users = new List<User>();
        }
        public static void UpdateUsers()
        {
            if (File.Exists("users.json"))
            {
                using (var sr = new StreamReader("users.json"))
                {
                    users = JsonSerializer.Deserialize<List<User>>(sr.ReadToEnd());
                }
            }
        }
        public static void UpdateJson()
        {
            using (var sw = new StreamWriter("users.json"))
            {
                sw.Write(JsonSerializer.Serialize<List<User>>(users));
            }
        }
        public static string EnterPassword()
        {

            var sb = new StringBuilder();

            ConsoleKeyInfo key;

            while (true)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    }


                }
                else
                {
                    Console.Write("*");
                    sb.Append(key.KeyChar);
                }
            }
            return sb.ToString();
        }
        public static void LINQAutentification()
        {
            Console.Write("login: ");
            string login = EnterPassword();
            Console.Write("password: ");
            string password = EnterPassword();


            User user = users.FirstOrDefault(u => u.login == login && u.pass == password);

            if (user == null)
            {
                Console.WriteLine("Auth denied");
            }
            else
            {
                Console.WriteLine($"Welcome {user.login}");
            }




        }
        public static void Auth()
        {
            Console.WriteLine("Authentication");
            Console.Write("login: ");
            string login = Console.ReadLine();
            Console.Write("password: ");
            string password = EnterPassword();

            UpdateUsers();

            bool authenticated = false;

            foreach (var i in users)
            {
                if (login.Equals(i.login) && password.Equals(i.pass))
                {
                    Console.WriteLine($"Welcome {i.login}");
                    i.LastLogin = DateTime.Now.ToString();
                    authenticated = true;
                    UpdateJson();
                }
            }

            if (!authenticated)
            {
                Console.WriteLine("\nauthentication denied");
            }
        }
        public static void Add()
        {

            Console.WriteLine("Registration");

            bool userExists = false;

            string login = String.Empty;
            string password = String.Empty;
            string repeatPassword = String.Empty;
            string RealName = String.Empty;
            
            while(true)
            {
                Console.Write("login: ");
                login = Console.ReadLine();
                //userExists = false;

                if(users.Where(u => u.login == login).Count() == 0)
                {
                    break;
                }
                Console.WriteLine("User with this login already exists");
                
                
                //foreach (var i in users)
                //{
                //    if (i.login.Equals(login))
                //    {
                //        userExists = true;
                //        Console.WriteLine("User with this login already exists");
                //    }
                //}
            };
            

            do
            {
                Console.Write("password: ");
                password = EnterPassword();
                Console.Write("repeat password: ");
                repeatPassword = EnterPassword();

                if (!password.Equals(repeatPassword))
                {
                    Console.WriteLine("passwords are not the same");
                }

            } while (!password.Equals(repeatPassword));

            Console.Write("Real name: ");
            RealName = Console.ReadLine();

            users.Add(new User { login = login, pass = password, RealName = RealName,LastLogin = DateTime.Now.ToString() });

            UpdateJson();
        }
        public static void Print()
        {

            Console.WriteLine("Order");
            Console.WriteLine("d/D - Date");
            Console.WriteLine("l/L - Login");
            Console.WriteLine("n/N - Name");

            var key = Console.ReadKey(true);

            if (key.KeyChar.Equals('l'))
            {
                foreach (var i in users.OrderBy((user) => { return user.login; }))
                {
                    Console.WriteLine(i);
                }
            }
            else if (key.KeyChar.Equals('d'))
            {
                foreach (var i in users.OrderBy((user) => { return user.LastLogin; }))
                {
                    Console.WriteLine(i);
                }
            }
            else if (key.KeyChar.Equals('n'))
            {
                foreach (var i in users.OrderBy((user) => { return user.RealName; }))
                {
                    Console.WriteLine(i);
                }
            }
            else if (key.KeyChar.Equals('L'))
            {
                foreach (var i in users.OrderBy((user) => { return user.login; }).Reverse())
                {
                    Console.WriteLine(i);
                }
            }
            else if (key.KeyChar.Equals('D'))
            {
                foreach (var i in users.OrderBy((user) => { return user.LastLogin; }).Reverse())
                {
                    Console.WriteLine(i);
                }
            }
            else if (key.KeyChar.Equals('N'))
            {
                foreach (var i in users.OrderBy((user) => { return user.RealName; }).Reverse())
                {
                    Console.WriteLine(i);
                }
            }


        }
        public static void Main()
        {
            try
            {
                ConsoleKeyInfo option;

                    UpdateUsers();

                do
                {
                    Console.WriteLine("\n1 - Sign in");
                    Console.WriteLine("2 - Sign up");
                    Console.WriteLine("3 - All Users");
                    Console.WriteLine("Esc -  exit");

                    option = Console.ReadKey(true);
                    Console.Clear();
                    if (option.Key == ConsoleKey.D1)
                    {
                        LINQAutentification();
                    }
                    else if (option.Key == ConsoleKey.D2)
                    {
                        Add();
                    }
                    else if (option.Key == ConsoleKey.D3)
                    {
                        Print();
                    }

                } while (option.Key != ConsoleKey.Escape);
            }
            catch (IOException ex)
            {
                Console.WriteLine("IO Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
