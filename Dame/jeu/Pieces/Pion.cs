using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dames.jeu.Pieces
{
    public class Pion : Piece
    {
        public Pion(bool appartientJ1) : base(appartientJ1)
        {

        }

        public Dame Evolution()
        {
            return new Dame(AppartientJ1);
        }

        public override bool CheckDeplacement(int x, int y, int destX, int destY, Piece[,] pcss, out Piece elimine)
        {
            int deltaX = destX - x;
            int deltaY = destY - y;
            elimine = null;

            int direction = AppartientJ1 ? 1 : -1;

            if ((deltaX == 1 || deltaX == -1) && deltaY == direction && pcss[destX, destY] == null)
            {
                return true;
            }

            if ((deltaX == 2 || deltaX == -2) && (deltaY == 2 || deltaY == -2))
            {
                int midX = x + deltaX / 2;
                int midY = y + deltaY / 2;

                if (pcss[midX, midY] != null && pcss[midX, midY].AppartientJ1 != AppartientJ1 && pcss[destX, destY] == null)
                {
                    elimine = pcss[midX, midY];
                    return true;
                }
            }

            return false;

        }
    }
}
