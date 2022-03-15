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
            if (n1.Value is int && n2.Value is int)
            {
                return new Number<T> { Value = (T)(object)(Convert.ToInt32(n1.Value) + Convert.ToInt32(n2.Value)) };
            }

            if (n1.Value is float && n2.Value is float)
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


    class Instance
    {

        public Instance()
        {
            if (Genegic.random.Next(20) > 10)
            {
                throw new Exception("Invalid Argument");
            }
        }

        public static T MakeInstance<T>() where T : class, new()
        {

            try
            {
                return new T();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public static T MakeRandom<T>()
        {
            var type = typeof(T);

            if (type.Name == "Int32")
            {
                return (T)(object)Genegic.random.Next();
            }
            
            if (type.Name == "Double")
            {
                return (T)(object)Genegic.random.NextDouble();
            }
            throw new Exception("Invalid T argument");

        }

        public static T MakeRandom<T>(T min, T max)where T:struct
        {
            var type = typeof(T);

            if (type.Name == "Int32")
            {
                return (T)(object)Genegic.random.Next((int)(object)min,(int)(object)max);
            }

            if (type.Name == "Double")
            {
                double val = (Genegic.random.NextDouble() * ((double)(object)max - (double)(object)min) + (double)(object)min);
                return (T)(object)val;
            }
            throw new Exception("Invalid T argument");

        }


    }

    class Element
    {
        public override string ToString()
        {
            return nameof(Element);
        }
    }

    class ElementOne:Element
    {
        public override string ToString()
        {
            return nameof(ElementOne);
        }
    }

    class ElementTwo:Element
    {
        public override string ToString()
        {
            return nameof(ElementTwo);
        }
    }

    class ElementThree : Element
    {
        public override string ToString()
        {
            return nameof(ElementThree);
        }
    }


    class Set<T>
    {
        private static List<T> list = new List<T>();

        public bool Add<T2>()where T2 : T, new()
        {
            foreach(var item in list)
            {
                if(item is T2)
                {
                    return false;
                }
            }
            list.Add(new T2());
            return true;
        }

        public T2 Get<T2>() where T2:class
        {
            foreach(var obj in list)
            {
                if(obj is T2)
                {
                    return (T2)(object)obj;
                }
            }
            return null;
        }

        public void Print()
        {
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
        }

        public T this[int i]
        {
            get
            {
                return list[i];
            }
            set
            {
                list[i] = value;
            }
        }

    }

    internal class Genegic
    {

        public static Random random = new Random();

        static void Main()
        {

            Set<Element> set = new Set<Element>();

            Console.WriteLine(set.Add<ElementOne>());
            Console.WriteLine(set.Add<ElementOne>());
            Console.WriteLine(set.Add<ElementTwo>());
            Console.WriteLine(set.Add<ElementThree>());

            var element = set.Get<Number<bool>>();
            Console.WriteLine(element==null?"null":"not null");
            set.Print();

        }


        static void NumberDemo()
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
            Console.WriteLine((i1 + i2).Value);

            var f1 = new Number<float> { Value = 3.14f };
            var f2 = new Number<float> { Value = 3.14f };
            Console.WriteLine((f1 + f2).Value);

            //С днем числа Пи
        }

    }
}
