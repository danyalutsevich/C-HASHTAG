using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO
{

    class Number<T> where T : struct // T- value Type
    {

        public T Value { get; set; }

        public Number()
        {

        }

        public Number<T> Plus(Number<T> n)
        {
            var TypeName = typeof(T).Name;
            if (TypeName == "Int32" )
            {
                Number<T> sum = new Number<T>();
                sum.Value =(T)(object)(Convert.ToInt32(n.Value)+Convert.ToInt32(this.Value));
                return sum;

            }
            if (TypeName == "Single")
            {
                Number<T> sum = new Number<T>();
                sum.Value = (T)(object)(Convert.ToSingle(n.Value) + Convert.ToSingle(this.Value));
                return sum;

            }
            throw new Exception("Unsupprorted type");

        }

    }

    class NumberArray<T> where T : struct
    {
        private List<Number<T>> numbers;

        public NumberArray()
        {
            numbers = new List<Number<T>>();
        }

        public void Add(Number<T> num)
        {
            numbers.Add(num);
        }

        public Number<T> Mean()
        {
            Number<T> sum = new Number<T>();

            foreach(var i in numbers)
            {
                sum = sum.Plus(i);
            }
            return sum;
        }

    }

    internal class Genegic
    {

        static void Main()
        {

            var arrInt = new NumberArray<int>();
            arrInt.Add(new Number<int> { Value = 10 });
            arrInt.Add(new Number<int> { Value = 20 });
            arrInt.Add(new Number<int> { Value = 30 });
            Console.WriteLine(arrInt.Mean().Value);

            var arrSingle = new NumberArray<float>();
            arrSingle.Add(new Number<float> { Value = .1f });
            arrSingle.Add(new Number<float> { Value = .2f });
            arrSingle.Add(new Number<float> { Value = .3f });
            Console.WriteLine(arrSingle.Mean().Value);

        }

    }
}
