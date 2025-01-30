using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dame.jeu.Pion;

namespace Dame.jeu.Damier
{
    public class Case
    {
        private PictureBox maison;
        private DefaultPion pion;

        public Case(PictureBox pbx)
        {
            maison = pbx;
            pion = null;
        }
        public Case(PictureBox pbx, DefaultPion pion) 
        {
            maison = pbx;
            this.pion = pion;
        }

        public void SetImage()
        {
            
        }
    }
}
