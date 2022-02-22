using System;
using System.Collections.Generic;
using System.Text;

namespace Oper.Extentions
{
    internal static class vec2Extentions
    {

        public static void Inverse(this DataTypes.vec2 vec2)
        {

            vec2.x = vec2.x + vec2.y;
            vec2.y = vec2.x - vec2.y;
            vec2.x = vec2.x - vec2.y;
        }
        public static void Abs(this DataTypes.vec2 vec2)
        {
            vec2.x = Math.Abs(vec2.x);
            vec2.y = Math.Abs(vec2.y);

        }
    }
}
