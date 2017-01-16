using Microsoft.Xna.Framework;

namespace BoulderDash
{
    abstract class Box
    {
        public int X, Y, Xi, Yi, Xm, Ym;    //Координаты на карте, инкремент, сторона движения
        protected int MoveTo;               //Кадры движения (сколько осталось, если 0 - то стоим)
        protected int AnF;                  //Кадр анимации
        protected int AnTimer;              //Время канимации
        public bool Destroyed;              //Метка на удаление объекта
        public abstract void Update();

        public Box(int x, int y)
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
        /// Позиция объекта
        /// </summary>
        public Vector2 Pos
        {
            get
            {
                return new Vector2(X * Graphics.SpriteSize + Xi, Y * Graphics.SpriteSize + Yi);
            }
        }


    }
}
