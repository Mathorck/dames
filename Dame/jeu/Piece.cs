using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dames.jeu
{
    public abstract class Piece
    {
        private bool appartientJ1;
        public bool AppartientJ1 { get { return appartientJ1; } private set { appartientJ1 = value; } }

        /// <summary>
        /// Constructeur d'une pièce
        /// </summary>
        /// <param name="appartientJ1">à quel équipe il appartient</param>
        public Piece(bool appartientJ1)
        {
            AppartientJ1 = appartientJ1;
        }


        /// <summary>
        /// Vérifie le déplacement d'une piece
        /// </summary>
        /// <param name="x">Position de cette piece</param>
        /// <param name="y">Position de cette piece</param>
        /// <param name="destX">Position de la case destination</param>
        /// <param name="destY">Position de la case destination</param>
        /// <param name="pcss">Tableau de pieces</param>
        /// <param name="elimine">Piece eliminé (pas toujour instancié)</param>
        /// <returns>si le déplacement est valide</returns>
        public abstract bool CheckDeplacement(int x, int y, int destX, int destY, Piece[,] pcss, out Piece elimine);



        public Dictionary<(int, int), Piece> DeplacementsPossibles(Piece[,] pieces)
        {
            int xthis = -1;
            int ythis = -1;
            Dictionary<(int, int), Piece> output = new Dictionary<(int, int), Piece>();
            Dictionary<(int, int), Piece> prises = new Dictionary<(int, int), Piece>();

            for (int x = 0; x < pieces.GetLength(0); x++)
                for (int y = 0; y < pieces.GetLength(1); y++)
                    if (pieces[x, y] == this)
                    {
                        xthis = x;
                        ythis = y;
                        break;
                    }

            if (xthis == -1 || ythis == -1)
                throw new Exception("Cette pièce n'existe pas dans la liste");

            for (int x = 0; x < pieces.GetLength(0); x++)
                for (int y = 0; y < pieces.GetLength(1); y++)
                {
                    if (x == xthis && y == ythis) continue;

                    if (pieces[xthis,ythis].CheckDeplacement(xthis, ythis, x, y, pieces, out Piece elimine))
                    {
                        if (elimine != null)
                        {
                            prises.Add((x, y), elimine);
                        }
                        else
                        {
                            output.Add((x, y), elimine);
                        }
                    }
                }

            if (prises.Count > 0)
                return prises;
            return output;
        }
    }
}
