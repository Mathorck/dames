﻿using System;

namespace Dames.jeu.Pieces
{
    public class Dame : Piece
    {
        public Dame(bool appartientJ1) : base(appartientJ1)
        {

        }

        public override bool CheckDeplacement(int x, int y, int destX, int destY, Piece[,] pcss, out Piece elimine)
        {
            int deltaX = destX - x;
            int deltaY = destY - y;
            elimine = null;

            if ((deltaX == deltaY || deltaX == deltaY * -1 || deltaX * -1 == deltaY || deltaX * -1 == deltaY * -1) && pcss[destX, destY] == null)
            {
                int directionX = destX > x ? 1 : -1;
                int directionY = destY > y ? 1 : -1;
                int nbrElim = 0;

                for (int i = 1; i < Math.Abs(destX - x); i++)
                {
                    int xx = x + i * directionX;
                    int yy = y + i * directionY;

                    if (pcss[xx, yy] != null)
                    {
                        if (pcss[xx, yy].AppartientJ1 == this.AppartientJ1)
                            return false;
                        nbrElim++;
                        elimine = pcss[xx, yy];
                    }
                }

                if (nbrElim > 1)
                {
                    elimine = null;
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
