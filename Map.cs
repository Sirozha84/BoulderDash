using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash
{
    static class Map
    {
        public static int Width, Height;
        public static int[,] M;

        public static void Load()
        {
            Width = 100;
            Height = 100;
            M = new int[Width, Height];

            for (int i = 0; i < 100; i++) { M[0, i] = 1; M[99, i] = 1; M[i, 0] = 1; M[i, 99] = 1; };
            Random RND = new Random();
            for (int i = 0; i < 100; i++) M[RND.Next(100), RND.Next(100)] = 1;

            Player.X = 64;
            Player.Y = 64;
        }
    }
}
