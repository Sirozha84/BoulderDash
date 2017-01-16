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
        public static Vector2 Pos;  //Позиция камеры
        static Vector2 To;          //Точка стремления
        public static int Right;    //Крайние положения для камеры (правое
        public static int Bottom;   //..и нижнее

        /// <summary>
        /// Инициализация камеры
        /// </summary>
        public static void Init()
        {
            Right = Map.Width * Graphics.SpriteSize - Graphics.Width;
            Bottom = Map.Height * Graphics.SpriteSize - Graphics.Height;
            Update();
            Pos = To;
        }

        /// <summary>
        /// Наведение камеры на игрока
        /// </summary>
        public static void Update()
        {
            To.X = World.player1.Pos.X + Graphics.SpriteSize / 2 - Graphics.Width / 2;
            To.Y = World.player1.Pos.Y + Graphics.SpriteSize / 2 - Graphics.Height / 2;
            Pos.X += (To.X - Pos.X) / 10;
            Pos.Y += (To.Y - Pos.Y) / 10;
            if (Pos.X < 0) Pos.X = 0;
            if (Pos.Y < 0) Pos.Y = 0;
            if (Pos.X > Right) Pos.X = Right;
            if (Pos.Y > Bottom) Pos.Y = Bottom;
        }
    }
}
