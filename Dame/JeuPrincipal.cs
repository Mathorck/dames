using Dames.jeu;
using Dames.jeu.Pieces;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dames
{
    public partial class JeuPrincipal : Form
    {
        private Damier damier = new Damier();
        private Button premierBtn = null;
        private List<Button> buttons;

        private Image caseN;
        private Image caseB;
        private Image pionN;
        private Image pionB;        
        private Image dameN;
        private Image dameB;

        public JeuPrincipal()
        {
            InitializeComponent();
            Init();
            UpdateBtn();
        }

        public void CasePressee(object sender, EventArgs args)
        {
            Button btn = (Button)sender;
            string[] coo = btn.Tag.ToString().Replace("{","").Replace("}","").Split(';');
            int x = int.Parse(coo[0]);
            int y = int.Parse(coo[1]);
            int gagnant = damier.CheckWin();

            
            if (gagnant != 0) 
            {
                if (gagnant == 1) 
                    MessageBox.Show("Le joueur Noir à Gagné");
                else if (gagnant == 2) 
                    MessageBox.Show("Le joueur Blanc à Gagné");
                damier.Init();
                return;
            }
            

            if (btn == premierBtn)
            {
                premierBtn = null;
                UpdateBtn();
                return;
            }
            

            if (premierBtn == null)
            {
                Piece p = GetPieceFromBtn(damier.Pieces,btn);
                if (p == null || p.AppartientJ1 != damier.TourJ1)
                    return;

                premierBtn = btn;
                UpdateBtn();
                return;
            }

            int[] xyDest = GetCooFromBtn(damier.Pieces, premierBtn);

            if (damier.Deplacement(xyDest[0], xyDest[1],x,y))
                premierBtn = null;

            UpdateBtn();
                    
            //MessageBox.Show($"{btn.Tag} a été pressé il possède {(damier.Pieces[x, y] == null?"Pas de pion":"Un pion")}");
        }

        private int[] GetCooFromBtn(Piece[,] tbl, Button btn)
        {
            string[] coo = btn.Tag.ToString().Replace("{", "").Replace("}", "").Split(';');
            return new int[] { int.Parse(coo[0]), int.Parse(coo[1]) };
        }

        private Piece GetPieceFromBtn(Piece[,] tbl, Button btn)
        {
            int[] xy = GetCooFromBtn(tbl, btn);
            return tbl[xy[0],xy[1]];
        }

        private void UpdateBtn()
        {
            Piece[,] Pieces = damier.Pieces;

            foreach (Button btn in buttons)
            {
                int[] xy = GetCooFromBtn(Pieces, btn);
                int x = xy[0];
                int y = xy[1];

                if (Pieces[x, y] == null)
                {
                    btn.BackgroundImage = damier.CaseValide(x, y) ? caseN : caseB;
                }
                else
                {
                    if (Pieces[x,y] is Pion)
                        btn.BackgroundImage = Pieces[x, y].AppartientJ1 ? pionN : pionB;
                    else 
                        btn.BackgroundImage = Pieces[x, y].AppartientJ1 ? dameN : dameB;
                }

                if (btn == premierBtn)
                {
                    btn.FlatAppearance.BorderColor = Color.Red;
                    btn.FlatAppearance.BorderSize = 3;
                }
                else
                {
                    btn.FlatAppearance.BorderColor = Color.FromArgb(30, 30, 40);
                    btn.FlatAppearance.BorderSize = 1;
                }
            }
            lbl_Tour.Text = $"Au tour de {(damier.TourJ1 ? "noir" : "blanc")}";
            damier.Save();
        }

        private void Init()
        {
            Piece[,] Pieces;
            buttons = new List<Button>();
            caseN = Image.FromFile("./images/CaseN.png");
            caseB = Image.FromFile("./images/CaseB.png");
            pionN = Image.FromFile("./images/PionN.png");
            pionB = Image.FromFile("./images/PionB.png");            
            dameN = Image.FromFile("./images/DameN.png");
            dameB = Image.FromFile("./images/DameB.png");

            if (File.Exists(Damier.SAVE_PATH))
            {
                if (MessageBox.Show("Une sauvegarde a été détectée voulez vous la charger ?", "Sauvegarde", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    damier.Load();
                else
                    damier.Init();
            }
            else
                damier.Init();

            Pieces = damier.Pieces;

            for (int x = 0;  x < Pieces.GetLength(0); x++)
                for (int y = 0;  y < Pieces.GetLength(1); y++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(50, 50);
                    btn.Location = new Point(x*50, y*50);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize=1;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.Tag = $"{{{x};{y}}}";
                    btn.Click += CasePressee;
                    

                    if (Pieces[x,y] == null)
                    {
                        btn.BackgroundImage = damier.CaseValide(x, y) ? caseN : caseB;
                    }
                    else
                    {
                        btn.BackgroundImage = Pieces[x, y].AppartientJ1? pionN : pionB;
                    }
                    
                    buttons.Add(btn);
                    pnlDamier.Controls.Add(btn);
                }
        }
    }
}
