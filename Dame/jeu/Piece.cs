using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.jeu
{
    public abstract class Piece
    {
        private bool appartientJ1;
        public bool AppartientJ1 { get; private set; }

        public Piece(bool appartientJ1)
        {
            AppartientJ1 = appartientJ1;
        }

        public abstract bool CheckDeplacement(int x, int y, int destX, int destY, Piece[,] pcss, out Piece elimine);
    }
}
