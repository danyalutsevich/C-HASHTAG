using System;

namespace Events
{

    delegate void EventListener(string str);

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorTop = 1;
            var editModule = new EditModule();
            var changeModule = new ChangeModule();
            var lengthModule = new LengthModule();

            editModule.NewChar += changeModule.OnNewChar;
            editModule.NewChar += lengthModule.OnNewChar;

            editModule.Type();

        }

    }

    class EditModule
    {

        public event EventListener NewChar;


        public void Type()
        {
            ConsoleKeyInfo key;
            int ch = 0;
            //Console.BackgroundColor = ConsoleColor.Green;

            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(key.KeyChar);

                }
                ch++;
                NewChar?.Invoke(key.KeyChar.ToString());

            } while (key.Key != ConsoleKey.Escape);


        }

    }

    class ChangeModule
    {
        public void OnNewChar(string str)
        {
            int CursorX = Console.CursorLeft;
            int CursorY = Console.CursorTop;

            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            if (str != "s")
            {
                Console.Write("*");

            }
            else
            {
                Console.WriteLine(" ");
            }
            Console.CursorLeft = CursorX;
            Console.CursorTop = CursorY;


        }

    }

    class LengthModule
    {
        public static int ch;

        static LengthModule()
        {
            ch = 0;
        }

        public void OnNewChar(string str)
        {


            int CursorX = Console.CursorLeft;
            int CursorY = Console.CursorTop;
            ch++;
            Console.CursorLeft = 1;
            Console.CursorTop = 0;
            Console.Write($"CH: {ch}");
            Console.CursorLeft = CursorX;
            Console.CursorTop = CursorY;
        }


    }

}
