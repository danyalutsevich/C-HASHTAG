using System;
using System.Collections.Generic;
using System.Text;
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

        public override string ToString()
        {
            return $"{login} : {pass}";
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
            using (var sr = new StreamReader("users.json"))
            {
                users = JsonSerializer.Deserialize<List<User>>(sr.ReadToEnd());
            }
        }

        public static string EnterPassword()
        {

            var sb = new StringBuilder();

            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Enter)
                {
                    Console.Write("*");
                    sb.Append(key.KeyChar);
                }
            } while (key.Key != ConsoleKey.Enter);

            return sb.ToString();

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
                    authenticated = true;
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

            do
            {
                Console.Write("login: ");
                login = Console.ReadLine();
                userExists = false;
                foreach (var i in users)
                {
                    if (i.login.Equals(login))
                    {
                        userExists = true;
                        Console.WriteLine("User with this login already exists");
                    }
                }
            } while (userExists);

            do
            {
                Console.Write("password: ");
                password = EnterPassword();
                Console.Write("\nrepeat password: ");
                repeatPassword = EnterPassword();

                if (!password.Equals(repeatPassword))
                {
                    Console.WriteLine("\npasswords are not the same");
                }

            } while (!password.Equals(repeatPassword));

            users.Add(new User { login = login, pass = password });

            using (var sw = new StreamWriter("users.json"))
            {
                sw.Write(JsonSerializer.Serialize<List<User>>(users));
            }
        }


        public static void Main()
        {
            try
            {
                ConsoleKeyInfo option;
                if (File.Exists("users.json"))
                {
                    UpdateUsers();

                }
                do
                {
                    Console.WriteLine("\n1 - Sign in");
                    Console.WriteLine("2 - Sign up");
                    Console.WriteLine("3 - All Users");

                    option = Console.ReadKey();
                    Console.Clear();
                    if (option.Key == ConsoleKey.D1)
                    {
                        Auth();

                    }
                    else if (option.Key == ConsoleKey.D2)
                    {
                        Add();

                    }
                    else if (option.Key == ConsoleKey.D3)
                    {
                        foreach (var i in users)
                        {
                            Console.WriteLine(i);
                        }
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
