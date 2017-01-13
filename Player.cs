﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BoulderDash
{
    static class Player
    {
        public static int X;
        public static int Y;
        public static int Xi;
        public static int Yi;

        public static Vector2 Pos
        {
            get
            {
                return new Vector2(X * Graphics.SpriteSize + Xi, Y * Graphics.SpriteSize + Yi);
            }

        }
    }
}
