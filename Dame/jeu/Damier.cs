using Dames.jeu.Pieces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Dames.jeu
{
    public class Damier
    {
        const int NOMBRE_CASES_X = 10;
        const int NOMBRE_CASES_Y = 10;
        public const string SAVE_PATH = "./save.json";

        private Piece[,] pieces;
        private bool tourJ1;

        public Piece[,] Pieces
        {
            get
            {
                return pieces;
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

        /// <summary>
        /// Méthode qui permet d'initialiser le damier avec tout les pions etc...
        /// </summary>
        public void Init()
        {
            pieces = new Piece[NOMBRE_CASES_X, NOMBRE_CASES_Y];
            tourJ1 = true;
            for (int x = 0; x < Pieces.GetLength(0); x++)
                for (int y = 0; y < Pieces.GetLength(1); y++)
                {
                    if (CaseValide(x, y) && (y <= 3 || y >= NOMBRE_CASES_Y - 4))
                        pieces[x, y] = new Pion(y <= 3);
                    else
                        pieces[x, y] = null;
                }
        }

        /// <summary>
        /// Méthode qui permet le déplacement d'un pion sur le damier
        /// </summary>
        /// <param name="x">Position X du pion</param>
        /// <param name="y">Position Y du pion</param>
        /// <param name="xDest">Position X de la destination</param>
        /// <param name="yDest">Position Y de la destination</param>
        /// <returns>Retourne si le déplacement a été fait</returns>
        public bool Deplacement(int x, int y, int xDest, int yDest)
        {
            if (Pieces[x, y] == null)
                return false;

            Piece pieceDepart = Pieces[x, y];

            if (pieceDepart.AppartientJ1 != tourJ1)
                return false;

            Piece pieceEliminee = null;
            if (!pieceDepart.CheckDeplacement(x, y, xDest, yDest, Pieces, out pieceEliminee))
                return false;

            if (pieceEliminee != null)
            {
                for (int i = 0; i < pieces.GetLength(0); i++)
                {
                    for (int j = 0; j < pieces.GetLength(1); j++)
                    {
                        if (pieces[i, j] == pieceEliminee)
                        {
                            pieces[i, j] = null;
                            tourJ1 = !tourJ1; // truc de neuille
                            break;
                        }
                    }
                }
            }

            pieces[xDest, yDest] = pieceDepart;
            pieces[x, y] = null;

            if ((pieceDepart.AppartientJ1 && yDest == NOMBRE_CASES_Y - 1) || (!pieceDepart.AppartientJ1 && yDest == 0) && pieces[xDest, yDest] is Pion)
            {
                pieces[xDest, yDest] = ((Pion)pieces[xDest, yDest]).Evolution();
            }

            tourJ1 = !tourJ1;

            return true;
        }

        /// <summary>
        /// méthode qui vérifie si quelqu'un a gagné
        /// </summary>
        /// <returns>0 si personne n'a gagné, 1 si J1 à gagné et si J2 à gagné</returns>
        public int CheckWin()
        {
            int nbPionJ1 = 0;
            int nbPionJ2 = 0;

            foreach (Piece piece in pieces) 
            {
                if (piece == null)
                    continue;

                if (piece.AppartientJ1)
                    nbPionJ1++;                
                else if (!piece.AppartientJ1)
                    nbPionJ2++;
            }

            if (nbPionJ1 == 0)
                return 1;
            else if (nbPionJ2 == 0)
                return 2;

            return 0;
        }

        /// <summary>
        /// Méthode qui permet de calculer si la case saisie est valide
        /// </summary>
        /// <param name="x">Composante en X</param>
        /// <param name="y">Composante en Y</param>
        /// <returns>Si la case est valide</returns>
        public bool CaseValide(int x, int y) => (x + y) % 2 != 0;

        /// <summary>
        /// Sauvegarde la partie dans un fichier Json
        /// </summary>
        public void Save()
        {
            if (!File.Exists(SAVE_PATH))
                File.Create(SAVE_PATH).Close();

            JArray piecesArray = new JArray();

            for (int i = 0; i < Pieces.GetLength(0); i++)
            {
                JArray rowArray = new JArray();
                for (int j = 0; j < Pieces.GetLength(1); j++)
                {
                    if (Pieces[i, j] == null)
                    {
                        rowArray.Add(null);
                    }
                    else
                    {
                        JObject pieceObject = JObject.FromObject(Pieces[i, j]);
                        pieceObject.Add("Type", Pieces[i, j].GetType().Name);
                        rowArray.Add(pieceObject);
                    }
                }
                piecesArray.Add(rowArray);
            }

            var jsonObject = new JObject
            {
                ["TourJ1"] = tourJ1,
                ["Pieces"] = piecesArray
            };

            File.WriteAllText(SAVE_PATH, jsonObject.ToString(Formatting.Indented));
        }

        /// <summary>
        /// Méthode qui permet d'initialiser une partie a l'aide d'un fichier sauvegarde (Json)
        /// </summary>
        /// <param name="path">Chemin</param>
        public void Load(string path)
        {
            if (!File.Exists(path))
                return;
            try
            {
                string txt = File.ReadAllText(path);
                var jsonObject = JsonConvert.DeserializeObject<JObject>(txt);

                this.tourJ1 = jsonObject["TourJ1"].ToObject<bool>();

                var piecesArray = jsonObject["Pieces"].ToObject<JArray>(); // Tableau 2D sous forme de JArray
                int rows = piecesArray.Count;
                int cols = piecesArray[0].Count();

                this.Pieces = new Piece[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        JToken pieceToken = piecesArray[i][j];
                        if (pieceToken.Type == JTokenType.Null)
                        {
                            Pieces[i, j] = null;
                        }
                        else
                        {
                            string type = pieceToken["Type"].ToString();
                            bool appartientJ1 = pieceToken["AppartientJ1"].ToObject<bool>();
                            if (type == "Pion")
                                Pieces[i, j] = new Pion(appartientJ1);
                            else if (type == "Dame")
                                Pieces[i, j] = new Dame(appartientJ1);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("le Fichier de sauvegarde est corompu création d'une nouvelle partie");
                File.Delete(path);
                this.Init();
            }
        }

        /// <summary>
        /// Méthode qui permet d'initialiser une partie a l'aide d'un fichier sauvegarde (Json)
        /// </summary>
        public void Load()
        {
            Load(SAVE_PATH);
        }

    }
}
