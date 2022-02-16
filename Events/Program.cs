using System;
using System.Text;

namespace Events
{

    delegate void EventListener(string str);

    delegate void WordListener(string str);

    internal class Program
    {
        public static SaveModule saveModule;

        public static void notepad()
        {
            Console.CursorTop = 1;
            Console.Title = "notepad";

            var editModule = new EditModule();
            var changeModule = new ChangeModule();
            var lengthModule = new LengthModule();
            var saveTimeModule = new SavedTimeModule();

            saveModule = new SaveModule();

            editModule.NewChar += changeModule.OnNewChar;
            editModule.NewChar += lengthModule.OnNewChar;
            saveModule.SaveText += changeModule.OnSave;
            saveModule.SaveText += saveTimeModule.OnSave;

            editModule.Type();


        }


        static void Main(string[] args)
        {

            var monitor = new TypingMonitor();
            var wordDetector = new WordDetector();

            monitor.wordListener += wordDetector.WordChecker;



            monitor.Start();

        }

    }


    class TypingMonitor
    {

        public event WordListener wordListener;
        public void Start()
        {

            ConsoleKeyInfo key;
            string str = String.Empty;
            var sb = new StringBuilder();

            do
            {

                key = Console.ReadKey();
                //sb.Append(key.KeyChar);
                wordListener?.Invoke(key.KeyChar.ToString());

            } while (key.Key != ConsoleKey.Escape);

        }


    }

    class WordDetector
    {

        public static StringBuilder AllText;
        public static int BannedWords;
        public string[] words = { "bomb", "apple", "cat", "terrorist" };
        static WordDetector()
        {
            AllText = new StringBuilder();
            BannedWords = 0;
        }

        public void WordChecker(string str)
        {
            AllText.Append(str);
            foreach (var i in words)
            {

                if (AllText.ToString().Contains(i))
                {
                    var newText = AllText.ToString();
                    AllText.Clear();
                    newText = newText.Replace(i, "");
                    AllText.Append(newText);
                    BannedWords++;
                    Console.Title = $"BannedWords:{BannedWords}";
                }
            }


        }


    }



    class ConsoleSettings
    {
        public static string title;
        public static char saved;



    }

    class EditModule
    {

        public event EventListener NewChar;


        public void Type()
        {
            ConsoleKeyInfo key;


            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                }
                else if (key.Key == ConsoleKey.F2)
                {

                    Program.saveModule?.OnSave("save");
                    continue;
                }
                else
                {
                    Console.Write(key.KeyChar);

                }
                NewChar?.Invoke(key.KeyChar.ToString());

            } while (key.Key != ConsoleKey.Escape);


        }

    }

    class ChangeModule
    {
        public void OnNewChar(string str)
        {
            if (!str.Equals("save"))
            {
                Console.Title = "*notepad";
            }

        }

        public void OnSave(string str)
        {

            if (str.Equals("save"))
            {
                Console.Title = "notepad";

            }

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

    class SaveModule
    {
        public event EventListener SaveText;

        public void OnSave(string str)
        {
            if (str == "save")
            {
                SaveText?.Invoke(str);
            }

        }

    }

    class SavedTimeModule
    {

        public static int saveCount;
        static SavedTimeModule()
        {
            saveCount = 0;

        }
        public void OnSave(string str)
        {
            if (str.Equals("save"))
            {
                Console.Title = Console.Title + " " + DateTime.Now + " Saved: " + saveCount + " times";
                saveCount++;
            }

        }


    }

}
