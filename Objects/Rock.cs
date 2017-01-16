using Microsoft.Xna.Framework.Graphics;

namespace BoulderDash
{
    class Rock : Box
    {
        public static Texture2D Texture;

        public Rock(int x, int y, int xm, int ym) : base(x, y)
        {
            Xm = xm;
            Ym = ym;
            MoveTo = Graphics.SpriteSize;
            Map.M[0, X + xm, Y + ym] = 2;
        }

        public override void Update()
        {
            Xi += Xm;
            Yi += Ym;
            MoveTo -= 1;
            if (MoveTo <= 0)
            {
                X += Xm;
                Y += Ym;
                Destroyed = true;
                //Map.M[0, X, Y] = 2;
            }
        }
    }
}
