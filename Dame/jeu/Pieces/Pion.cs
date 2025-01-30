using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.jeu.Pieces
{
    public class Pion : Piece
    {
        public Pion(bool appartientJ1) : base(appartientJ1)
        {

        }

        public override bool CheckDeplacement(int x, int y, int destX, int destY, Piece[,] pcss, out Piece elimine)
        {
            int deltaX = destX - x;
            int deltaY = destY - y;
            elimine = null;

            int direction = AppartientJ1 ? 1 : -1;

            if (deltaX == 1 && deltaY == direction)
            {
                return true;
            }

            if (deltaX == 2 && deltaY == 2 * direction)
            {
                int midX = x + deltaX / 2;
                int midY = y + deltaY / 2;

                if (pcss[midX,midY] is Piece pcsCool && pcsCool.AppartientJ1 != AppartientJ1)
                    return true;
            }

            return false;

        }
    }
}
