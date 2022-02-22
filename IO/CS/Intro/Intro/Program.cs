using System;

namespace Intro
{

    class Tasks
    {
        public void task1()
        {

            char sym;
            int count = 0;

            do
            {

                sym = Console.ReadKey().KeyChar;
                if (sym == ' ')
                {
                    count++;
                }

            } while (sym != '.');
            Console.WriteLine("\nYou've entered " + count + " spaces");
        }

        public void task2()
        {
            char[] ticket;

            ticket = Console.ReadLine().ToCharArray();

            int[] num = new int[6];

            try
            {

                num[0] = Int32.Parse(ticket[0].ToString());
                num[1] = Int32.Parse(ticket[1].ToString());
                num[2] = Int32.Parse(ticket[2].ToString());
                num[3] = Int32.Parse(ticket[3].ToString());
                num[4] = Int32.Parse(ticket[4].ToString());
                num[5] = Int32.Parse(ticket[5].ToString());

                if (num[0] + num[1] + num[2] == num[3] + num[4] + num[5])
                {
                    Console.WriteLine("That ticket is lucky");
                }
                else
                {
                    Console.WriteLine("That ticket is not lucky");
                }
            }
            catch
            {

                Console.WriteLine("You've entered incorrect ticket number");
            }




        }

        public void task3()
        {
            string line;

            line = Console.ReadLine();

            char[] letters = line.ToCharArray();

            for (int i = 0; i < letters.Length; i++)
            {
                if (Char.IsUpper(letters[i]))
                {
                    letters[i] = Char.ToLower(letters[i]);
                }
                else
                {
                    letters[i] = Char.ToUpper(letters[i]);
                }
            }

            Console.WriteLine(letters);

        }

        public void task4()
        {

            uint A = 0;
            uint B = 0;
            Console.WriteLine("Enter first number: ");
            A = UInt32.Parse(Console.ReadLine());

            Console.WriteLine("Enter second number: ");
            B = UInt32.Parse(Console.ReadLine());


            for (; A <= B; A++)
            {

                for (uint i = 0; i < A; i++)
                {

                    Console.Write(A.ToString() + " ");
                }

                Console.WriteLine();

            }
        }

        public void task5()
        {

            char[] num = Console.ReadLine().ToCharArray();
            Array.Reverse(num);
            Console.WriteLine(num);

        }
    }


    partial class Car
    {
        private int horsePower;
        private float gasTankVolume;
        private uint maxSpeed;
        private string title;
        private double LitersPer100km;

        public static uint objectsCount { get; private set; }
        public static int wheels { get; private set; }

        public Car()
        {
            horsePower = 0;
            gasTankVolume = 0;
            maxSpeed = 0;
            title = String.Empty;
            LitersPer100km = 0;

            objectsCount++;
            wheels = 4;
        }

        public Car(int horsePower)
        {
            this.horsePower=horsePower;
            objectsCount++;
            wheels = 4;
        }
        public Car(int horsePower,float gasTankVolume)
        {
            this.horsePower = horsePower;
            this.gasTankVolume = gasTankVolume;
            objectsCount++;
            wheels = 4;
        }
        public Car(int horsePower, float gasTankVolume,uint maxSpeed)
        {
            this.horsePower = horsePower;
            this.gasTankVolume = gasTankVolume;
            this.maxSpeed = maxSpeed;
            objectsCount++;
            wheels = 4;
        }
        public Car(int horsePower, float gasTankVolume, uint maxSpeed,string title)
        {
            this.horsePower = horsePower;
            this.gasTankVolume = gasTankVolume;
            this.maxSpeed = maxSpeed;
            this.title = title;
            objectsCount++;
            wheels = 4;
        }
        public Car(int horsePower, float gasTankVolume, uint maxSpeed, string title,double LitersPer100km)
        { 
            this.horsePower = horsePower;
            this.gasTankVolume = gasTankVolume;
            this.maxSpeed = maxSpeed;
            this.title = title;
            this.LitersPer100km = LitersPer100km;
            objectsCount++;
            wheels = 4;
        }
        static Car()
        {
            objectsCount = 0;
            wheels = 4;

        }

        public int getHorsePower()
        {
            return horsePower;
        }
        public float getTankVolume()
        {
            return gasTankVolume; 
        }
        public uint getMaxSpeed()
        {
            return maxSpeed; 
        }
        public string getTitle()
        {
            return title;
        }
        public double getLitersPer100km()
        {
            return LitersPer100km;
        }

        public Car setHorsePower(int horsePower)
        {
            this.horsePower = horsePower;
            return this;
        
        }
        public Car setTankVolume(float gasTankVolume)
        {
           this.gasTankVolume = gasTankVolume;
            return this;
        }
        public Car setMaxSpeed(uint maxSpeed)
        {
           this.maxSpeed = maxSpeed;
            return this;
        }
        public Car setTitle(string title)
        {
           this.title = title;
            return this;
        }
        public Car setLitersPer100km(double LitersPer100km)
        {
           this.LitersPer100km = LitersPer100km;
            return this;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Tasks tasks = new Tasks();
            //tasks.task5();

            
            Car[] cars=new Car[10];

            for(int i = 0; i < cars.Length; i++)
            {
                cars[i] = new Car();
                
            }

            double distance = 1001;
            cars[0].setLitersPer100km(6).setTankVolume(60);
            Console.WriteLine(cars[0].canGoThisFarOnFullTank(ref distance));
            


        }
    }
}
