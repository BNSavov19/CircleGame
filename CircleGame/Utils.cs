using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleGame
{
    internal class Utils
    {
        static public float toRadian(float angle)
        {
            return (float)(System.Math.PI / 180) * angle;
        }

    }
}
