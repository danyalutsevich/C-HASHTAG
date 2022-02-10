using System;
using System.Collections.Generic;
using System.Text;

namespace Oper.DataTypes
{
    internal class Complex : ICloneable
    {
        public double Re { get; set; }
        public double Im { get; set; }

        public double Abs
        {

            //get
            //{
            //    return Math.Sqrt(this.Re*this.Re+this.Im*this.Im);
            //}
            get => Math.Sqrt(this.Re * this.Re + this.Im * this.Im);
        }

        public override string ToString()
        {
            return $"{this.Re}" + (this.Im < 0 ? "-" : "+") + $"{Math.Abs(this.Im)}i";
        }

        public object Clone()
        {
            return new Complex { Im = this.Im, Re = this.Re};
        }

        public Complex Conjugate
        {
            get => new Complex { Re = this.Re, Im = this.Im };
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex
            {
                Re = c1.Re + c2.Re,
                Im = c1.Im + c2.Im
            };
        }

        public static Complex operator -(Complex c1, Complex c2)
        { 
            return new Complex
            {
                Re = c1.Re - c2.Re,
                Im = c1.Im - c2.Im
            };
        }

        public static Complex operator *(Complex c1, Complex c2)
        { 
            return new Complex
            {
                Re = c1.Re * c2.Re + c1.Im * c2.Im,
                Im = c1.Im * c2.Re + c1.Re * c2.Im
            };

        }

        public static Complex operator /(Complex c1, Complex c2)
        {

            if (c2.Abs == 0)
            {
                throw new Exceptions.ComplexExceptions("Can't be divided by 0");
            }

            var c = c1 * c2.Conjugate;
            var d = c2.Abs * c2.Abs;

            return new Complex
            {

                Im = c.Im / d,
                Re = c.Re / d
                //Re = ((c1.Re * c2.Re) + (c1.Im * c2.Im)) / (c2.Re * c2.Re + c2.Im * c2.Im),
                //Im = ((c1.Im * c2.Re) - (c1.Re * c2.Im)) / (c2.Re * c2.Re + c2.Im * c2.Im)



            };


        }

        public static Complex operator +(Complex c, double r)
        {

            return new Complex
            {
                Re = c.Re + r,
                Im = c.Im
            };
        }

        public static Complex operator -(Complex c, double r)
        {
            return new Complex
            {
                Re = c.Re - r,
                Im = c.Im 
            };
        }

        public static Complex operator *(Complex c, double r)
        {

            return new Complex
            {
                Re = c.Re * r,
                Im = c.Im * r
            };
        }

        public static Complex operator /(Complex c, double r)
        {

            if (r == 0)
            {
                throw new Exceptions.ComplexExceptions("Complex number can't be divided by 0");
            }
            return new Complex
            {
                Re = c.Re / r,
                Im = c.Im / r
            };
        }


    }
}
