using Dame.jeu.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.jeu
{
    public class Damier
    {
        const int NOMBRE_CASES_X = 10;
        const int NOMBRE_CASES_Y = 10;

        private Piece[,] pieces;
        private bool tourJ1;

        public Piece[,] Pieces
        {
            get
            {
                return (Piece[,])pieces.Clone();
            }
            private set 
            {
                pieces = value;
            }
        }
        public bool TourJ1
        {
            get
            {
                return tourJ1;
            }
            private set
            {
                tourJ1 = value;
            }
        }

        public void Init()
        {
            Pieces = new Piece[NOMBRE_CASES_X,NOMBRE_CASES_X];

            for (int x = 0; x < Pieces.GetLength(0); x++) 
                for (int y = 0; y < Pieces.GetLength(1); y++)
                {
                    if (CaseValide(x,y) && y<=2 && y>=NOMBRE_CASES_Y-3)
                        pieces[x,y] = new Pion(y <= 2);
                }
            
        }

        public bool Deplacement(int x,int y,int xDest,int yDest)
        {

            return false;
        }

        private bool CaseValide(int x, int y) => (x % 2 == 0 && y % 2 == 0);
    }
}
