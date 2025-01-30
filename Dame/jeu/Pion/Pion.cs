using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.jeu.Pion
{
    public class Pion : DefaultPion
    {
        public static new Dictionary<PionColor,Image> ImagePion { get; set; }
    }
}
