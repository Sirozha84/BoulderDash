using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash
{
    static class World
    {
        /*Кодировка карты
        1 - стена
        2 - камень
        3 - алмаз
        */
        public static Player player1;
        public static List<Rock> Rocks;

        /// <summary>
        /// Инициализация игрового мира
        /// </summary>
        public static void Init()
        {
            Rocks = new List<Rock>();
        }

        /// <summary>
        /// Обработка мира (обработка игровых объектов, проверка на висячие камни и статус игры)
        /// </summary>
        public static void Update()
        {
            for (int j = Map.Height - 2; j > 0; j--)
                for (int i = 1; i < Map.Width; i++)
                    if (Map.M[0, i, j] == 2 && Map.M[0, i, j + 1] == 0)
                    {
                        Rocks.Add(new Rock(i, j, 0, 1));
                        Map.M[0, i, j] = 0;
                        Map.M[1, i, j] = 0;
                        //Map.M[0, i, j] = 0; Map.M[0, i, j + 1] = 2;
                    }
        }

    }
}
