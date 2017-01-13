using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BoulderDash
{
    static class Camera
    {
        static int X;
        static int Y;

        public static Vector2 Pos
        {
            get
            {
                //тут подвинем камеру к центру игрока
                return new Vector2(X, Y);
            }
        }
    }
}
