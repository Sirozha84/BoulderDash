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
        public static int[,,] M;

        public static void Load()
        {
            Width = 100;
            Height = 100;
            M = new int[2, Width, Height];

            for (int i = 0; i < 100; i++) { M[0, 0, i] = 1; M[0, 99, i] = 1; M[0, i, 0] = 1; M[0, i, 99] = 1; };
            for (int i = 0; i < 100; i++) { M[1, 0, i] = 1; M[1, 99, i] = 1; M[1, i, 0] = 1; M[1, i, 99] = 1; };
            Random RND = new Random();
            /*for (int i = 0; i < 2000; i++) M[RND.Next(1, 99), RND.Next(1, 99)] = 1;
            for (int i = 0; i < 500; i++) M[RND.Next(1, 99), RND.Next(1, 99)] = 2;
            for (int i = 0; i < 500; i++) M[RND.Next(1, 99), RND.Next(1, 99)] = 3;*/
            M[0, 3, 1] = 2;
            M[1, 3, 1] = 2;
            M[0, 3, 5] = 1;
            M[1, 3, 5] = 1;
            World.player1 = new Player(1, 1);
            Camera.Init();
        }
    }
}
