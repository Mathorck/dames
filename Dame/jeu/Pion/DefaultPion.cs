using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Dame.jeu.Pion
{
    public abstract class DefaultPion
    {
        public Vector2 Position { get; private set; }
        public PionColor Couleur { get; private set; }

        public static Dictionary<PionColor, Image> ImagePion { get; protected set; }

    }
}
