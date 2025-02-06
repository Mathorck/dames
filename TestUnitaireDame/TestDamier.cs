using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dames;
using System;
using Dames.jeu;
using Dames.jeu.Pieces;

namespace TestUnitaireDame
{
    [TestClass]
    public class TestDamier
    {
        #region CaseValide
        [TestMethod]
        public void TestCaseInvalide()
        {
            // Préparation
            Damier damier = new Damier();

            // Assertion
            Assert.IsFalse(damier.CaseValide(0,0));
            Assert.IsFalse(damier.CaseValide(-1,-1));
            Assert.IsFalse(damier.CaseValide(8, 8));
        }

        [TestMethod]
        public void TestCaseValide()
        {
            // Préparation
            Damier damier = new Damier();

            // Assertion
            Assert.IsTrue(damier.CaseValide(1, 0));
            Assert.IsTrue(damier.CaseValide(7, 6));
        }
        #endregion

        #region Load
        [TestMethod]
        public void TestPiecesEstPasNullOnLoad()
        {
            // Préparation
            Damier damier = new Damier();
            damier.Load("test.json");

            // Assertion
            Assert.IsNotNull(damier.Pieces);
            Assert.IsTrue(damier.Pieces.Length > 0);
        }

        [TestMethod]
        public void TestTourJEstPasNullOnLoad()
        {
            // Préparation
            Damier damier = new Damier();
            damier.Load("test.json");

            // Assertion
            Assert.IsNotNull(damier.TourJ1);
        }
        #endregion

        #region Init
        [TestMethod]
        public void TestPiecesEstPasNullOnInit()
        {
            // Préparation
            Damier damier = new Damier();
            damier.Init();

            // Assertion
            Assert.IsNotNull(damier.Pieces);
        }

        [TestMethod]
        public void TestTourJEstPasNullOnInit()
        {
            // Préparation
            Damier damier = new Damier();
            damier.Init();

            // Assertion
            Assert.IsNotNull(damier.TourJ1);
        }

        [TestMethod]
        public void TestInitPositionPions()
        {
            // Préparation
            Damier damier = new Damier();
            damier.Init();

            // Assertion
            Assert.IsInstanceOfType(damier.Pieces[0, 1], typeof(Pion));
            Assert.IsInstanceOfType(damier.Pieces[7, 6], typeof(Pion));
        }

        #endregion

        #region Deplacements

        #region Pion
        [TestMethod]
        public void TestPionCheckDeplacementArriere()
        {
            // Préparation
            Damier damier = new Damier();
            damier.Load("test.json");

            // Assertion
            Assert.IsFalse(damier.Pieces[0, 1].CheckDeplacement(0, 1, 1, 0, damier.Pieces, out Piece elimine));
            Assert.IsNull(elimine);
        }        
        
        [TestMethod]
        public void TestPionCheckDeplacementAvancer()
        {
            // Préparation
            Damier damier = new Damier();
            damier.Load("test.json");

            // Assertion
            Assert.IsTrue(damier.Pieces[0, 1].CheckDeplacement(0, 1, 1, 2, damier.Pieces, out Piece elimine));
            Assert.IsNull(elimine);
        }

        [TestMethod]
        public void TestPionCheckDeplacementMangerAvant()
        {
            // Préparation
            Damier damier = new Damier();
            damier.Load("test.json");
            damier.Pieces[0, 3] = new Pion(true);
            damier.Pieces[1, 4] = new Pion(false);

            // Assertion
            Assert.IsTrue(damier.Pieces[0, 3].CheckDeplacement(0, 3, 2, 5, damier.Pieces, out Piece elimine));
            Assert.IsNotNull(elimine, "Le pion adverse aurait dû être éliminé.");
            Assert.IsTrue(damier.Deplacement(0, 3, 2, 5));
            Assert.IsNull(damier.Pieces[1, 4], "La case (1,4) doit être vide après la capture.");
        }

        #endregion
        #endregion
    }
}
