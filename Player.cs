using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BoulderDash
{
    class Player:Box
    {
        /// <summary>
        /// Инициализация игрока
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Player(int x, int y) : base(x, y)
        {
        }

        /// <summary>
        /// Позиция игрока
        /// </summary>
        public Vector2 Pos
        {
            get
            {
                return new Vector2(X * Graphics.SpriteSize + Xi, Y * Graphics.SpriteSize + Yi);
            }
        }

        /// <summary>
        /// Кадр анимации
        /// </summary>
        public int Frame
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
        public void Move(int x, int y)
        {
            if (MoveTo > 0) return;
            if (Map.M[0, X + x, Y + y] != 0) return;
            Xm = x;
            Ym = y;
            MoveTo = 64;
        }

        /// <summary>
        /// Обновление игрока
        /// </summary>
        public override void Update()
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
