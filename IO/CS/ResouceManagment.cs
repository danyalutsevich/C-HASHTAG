using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO
{
    internal class ResouceManagment
    {
        public static void Main()
        {
            Disposable disposable = null;
            try
            {
                disposable = new Disposable();
                disposable.Dispose();
            }
            catch
            {
                Console.WriteLine("Create err");
            }
            finally
            {
                disposable?.Dispose();
            }

            using (var dc = new Disposable())
            {
                Console.WriteLine("using");
            }


        }

        public static void GCDemo()
        {
            for(int i = 0; i < 1000000; i++)
            {
                new Name();
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }

    }

    class Name
    {

        public string[] names { get; set; }
        public Name()
        {
            Console.WriteLine("ctor");
            names = new string[10000000];
        }

        ~Name()
        {
            Console.WriteLine("finalizer");
            GC.SuppressFinalize(this);
        }

    }

    class Disposable : IDisposable
    {
        public bool disposed { get; set; }
        public Disposable()
        {
            Console.WriteLine("Disposable class created");
            disposed = false;
        }

        public void Dispose()
        {
            if (!disposed)
            {
                Console.WriteLine("Disposable class disposed");
                disposed=true;
            }
        }

        ~Disposable()
        {
            Console.WriteLine("Disposable class finalizer");
            if (!disposed)
            {
                Console.WriteLine("Disposable class disposed");
                disposed = true;
            }
        }

    }

}
