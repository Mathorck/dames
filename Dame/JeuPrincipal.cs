using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dame
{
    public partial class JeuPrincipal : Form
    {
        public List<PictureBox> Pbx_cases;

        public JeuPrincipal()
        {
            innit();
            InitializeComponent();
        }

        private void innit()
        {
            Pbx_cases = new List<PictureBox>();
        }

        private void pbx_case_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (!(sender is PictureBox))
                throw new Exception("Erreur Fatale, Veuilez contacter un expert Microsoft");

            Pbx_cases.Add(sender as PictureBox);
        }

        private void pbx_case_Click(object sender, EventArgs e)
        {

        }
    }
}
