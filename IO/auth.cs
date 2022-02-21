using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace IO
{

    public class User
    {
        public string login { get; set; }
        public string pass { get; set; }

        public override string ToString()
        {
            return $"{login} : {pass}";
        }

    }
    public class Users
    {

        public List<User> users;

        public void Add(string login, string pass)
        {
            users.Add(new User { login = login, pass = pass });
        }
        public void Add(User user)
        {
            users.Add(user);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < users.Count; i++)
            {
                sb.Append(users[i] + "\n");
            }

            return sb.ToString();
        }

    }



    class auth
    {

        public static List<User> users;

        static auth()
        {

            users = new List<User>();

        }

        public static void Auth()
        {



        }

        public static void Add()
        {

            Console.WriteLine("Registration");
            Console.Write("login: ");
            string login = Console.ReadLine();
            Console.Write("password: ");
            string password = Console.ReadLine();

            users.Add(new User { login = login, pass = password });


        }


        public static void Main()
        {

            while (true)
            {

                Console.WriteLine("1 - Sign in");
                Console.WriteLine("2 - Sign up");

                string option = Console.ReadLine();
                Console.Clear();
                if (option.Equals("1"))
                {
                    Auth();

                }
                else if (option.Equals("2"))
                {
                    Add();

                }

                foreach (var i in users)
                {
                    Console.WriteLine(i);
                }
            }
        }


    }
}
