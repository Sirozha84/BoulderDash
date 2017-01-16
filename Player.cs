using System;
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
        public static int Xm;
        public static int Ym;
        static int MoveTo;
        static int AnF;
        static int AnTimer;

        /// <summary>
        /// Инициализация игрока
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void Init(int x, int y)
        {
            X = x;
            Y = y;
            Xi = 0;
            Yi = 0;
            MoveTo = 0;
            AnF = 0;
            AnTimer = 0;
        }

        /// <summary>
        /// Позиция игрока
        /// </summary>
        public static Vector2 Pos
        {
            get
            {
                return new Vector2(X * Graphics.SpriteSize + Xi, Y * Graphics.SpriteSize + Yi);
            }
        }

        /// <summary>
        /// Кадр анимации
        /// </summary>
        public static int Frame
        {
            get
            {
                AnTimer++;
                if (AnTimer > 4)
                {
                    AnTimer = 0;
                    AnF++;
                    if (AnF > 3) AnF = 0;
                }
                return AnF;
            }
        }

        /// <summary>
        /// Движение персонажа
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void Move(int x, int y)
        {
            if (MoveTo > 0) return;
            if (Map.M[X + x, Y + y] != 0) return;
            Xm = x;
            Ym = y;
            MoveTo = 64;
        }

        /// <summary>
        /// Обновление игрока
        /// </summary>
        public static void Update()
        {
            if (MoveTo <= 0) return;
            Xi += Xm * Global.Speed;
            Yi += Ym * Global.Speed;
            MoveTo -= Global.Speed;
            if (MoveTo <= 0)
            {
                X += Xm;
                Y += Ym;
                Xi = 0;
                Yi = 0;
            }
            
        }
    }
}
