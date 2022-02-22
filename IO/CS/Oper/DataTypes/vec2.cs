using System;
using System.Collections.Generic;
using System.Text;

namespace Oper.DataTypes
{

    internal class vec2
    {
        public double x { get; set; }
        public double y { get; set; }

        public vec2()
        {

        }
        public vec2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"x:{x}, y:{y}";
        }

        public static double Dot(vec2 v1, vec2 v2)
        {

            return v1.x * v2.x + v1.y * v2.y;

        }

        public double Len()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y);
        }

        public static double operator ^(vec2 v1, vec2 v2)
        {
            if (v1.Len() == 0 || v2.Len() == 0)
            {
                throw new Exceptions.Vec2Exceptions("Unable to calculate angle, vector's len is 0");
            }

            return Math.Acos(vec2.Dot(v1, v2) / (v1.Len() * v2.Len())) / Math.PI * 180;
        }

        public static vec2 operator +(vec2 v1, vec2 v2)
        {
            return new vec2
            {
                x = v1.x + v2.x,
                y = v1.y + v2.y
            };
        }

        public static vec2 operator -(vec2 v1, vec2 v2)
        {

            return new vec2
            {
                x = v1.x - v2.x,
                y = v1.y - v2.y

            };

        }

        public static vec2 operator *(vec2 v, double n)
        {
            return new vec2 { x = v.x * n, y = v.y * n };
        }

        public double this[int i]
        {
            get
            {

                if (i == 0)
                {
                    return x;
                }
                else if (i == 1)
                {
                    return y;
                }
                else
                {
                    throw new Exceptions.Vec2Exceptions("Wrong index. Index must be 0 or 1");

                }

            }
        }




    }
}
