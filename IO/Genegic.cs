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

        public Number<T> Plus(Number<T> n)
        {
            var TypeName = typeof(T).Name;
            if (TypeName == "Int32")
            {
                Number<T> sum = new Number<T>();
                sum.Value = (T)(object)(Convert.ToInt32(n.Value) + Convert.ToInt32(this.Value));
                return sum;
            }
            if (TypeName == "Single")
            {
                Number<T> sum = new Number<T>();
                sum.Value = (T)(object)(Convert.ToSingle(n.Value) + Convert.ToSingle(this.Value));
                return sum;
            }
            throw new Exception("Unsupported type");
        }

        public static Number<T> operator +(Number<T> n1, Number<T> n2)
        {
            if (n1.Value is int)
            {
                return new Number<T> { Value = (T)(object)(Convert.ToInt32(n1.Value) + Convert.ToInt32(n2.Value)) };
            }

            if (n1.Value is float)
            {
                return new Number<T> { Value = (T)(object)(Convert.ToSingle(n1.Value) + Convert.ToSingle(n2.Value)) };
            }

            throw new Exception("Unsupported type");
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

            foreach (var i in numbers)
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

            var i1 = new Number<int> { Value = 3 };
            var i2 = new Number<int> { Value = 14 };
            Console.WriteLine((i1+i2).Value);

            var f1 = new Number<float> { Value = 3.14f };
            var f2 = new Number<float> { Value = 3.14f };
            Console.WriteLine((f1 + f2).Value);

            //С днем числа Пи
        }

    }
}
