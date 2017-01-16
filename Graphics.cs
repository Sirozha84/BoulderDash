using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoulderDash
{
    static class Graphics
    {
        public const int Width = 800;
        public const int Height = 480;
        public const int SpriteSize = 64;
        public static Rectangle Full;
        public static Texture2D Player;
        public static Texture2D Walls;
        public static Texture2D Back;
        public static Texture2D Light;

        public static void Init()
        {
            Full = new Rectangle(0, 0, Width, Height);
        }

        /// <summary>
        /// Фрагмент текстуры по номеру спрайта
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static Rectangle RectByNum(Texture2D texture, int num)
        {
            int count = texture.Width / SpriteSize;
            return new Rectangle(
                (num % count) * SpriteSize,
                (num / count) * SpriteSize, SpriteSize, SpriteSize);
        }
    }
}
