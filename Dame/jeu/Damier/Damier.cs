using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Dame.jeu.Damier
{
    public static class Damier
    {
        const int NOMBRE_CASES_X = 10;
        const int NOMBRE_CASES_Y = 10;

        public static Case[,] cases;

        public static void Innit()
        {
            cases = new Case[NOMBRE_CASES_X, NOMBRE_CASES_Y];
            for (int x = 0; x < cases.GetLength(0); x++)
            {
                for (int y = 0; y < cases.GetLength(1); y++)
                {
                    //cases[x, y];
                }
            }
        }
    }
}
