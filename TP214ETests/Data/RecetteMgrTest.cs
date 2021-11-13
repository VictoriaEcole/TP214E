using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP214E.Data;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using Moq;
using TP214E.Pages;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class RecetteMgrTest
    {
        [TestMethod()]
        public void TestTrouverSiRecettePossibleExactementBonneQuatite()
        {

            Recette recette = CreerRecette();

            Aliment alimentInventairePatate = new Aliment();
            alimentInventairePatate.Nom = "Patate";
            alimentInventairePatate.Quantite = 10;

            Aliment alimentInventaireSel = new Aliment();
            alimentInventaireSel.Nom = "Sel";
            alimentInventaireSel.Quantite = 10;


            List<Aliment> lstAlimentsSel = new List<Aliment>();
            lstAlimentsSel.Add(alimentInventaireSel);

            List<Aliment> lstAlimentsPatate = new List<Aliment>();
            lstAlimentsPatate.Add(alimentInventairePatate);

            var mockDal = Mock.Of<IDAL>();
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Patate")).Returns(lstAlimentsSel);
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Sel")).Returns(lstAlimentsPatate);

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();

            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            Assert.IsTrue(recetteMgr.TrouverSiRecettePossible(recette));

        }
        [TestMethod()]
        public void TestTrouverSiRecettePossibleAvecPlusQueLaBonneQuatite()
        {
            
            Recette recette = CreerRecette();

            Aliment alimentInventairePatate = new Aliment();
            alimentInventairePatate.Nom = "Patate";
            alimentInventairePatate.Quantite = 12;

            Aliment alimentInventaireSel = new Aliment();
            alimentInventaireSel.Nom = "Sel";
            alimentInventaireSel.Quantite = 12;


            List<Aliment> lstAlimentsSel = new List<Aliment>();
            lstAlimentsSel.Add(alimentInventaireSel);

            List<Aliment> lstAlimentsPatate = new List<Aliment>();
            lstAlimentsPatate.Add(alimentInventairePatate);

            var mockDal = Mock.Of<IDAL>();
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Patate")).Returns(lstAlimentsSel);
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Sel")).Returns(lstAlimentsPatate);

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();

            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            Assert.IsTrue(recetteMgr.TrouverSiRecettePossible(recette));

        }

        [TestMethod()]
        public void TestTrouverSiRecettePossibleAvecDeuxItemDansInventaire()
        {
            Recette recette = CreerRecette();

            Aliment alimentInventairePatate = new Aliment();
            alimentInventairePatate.Nom = "Patate";
            alimentInventairePatate.Quantite = 5;

            Aliment alimentInventaireSel = new Aliment();
            alimentInventaireSel.Nom = "Sel";
            alimentInventaireSel.Quantite = 12;


            List<Aliment> lstAlimentsSel = new List<Aliment>();
            lstAlimentsSel.Add(alimentInventaireSel);

            List<Aliment> lstAlimentsPatate = new List<Aliment>();
            lstAlimentsPatate.Add(alimentInventairePatate);
            lstAlimentsPatate.Add(alimentInventairePatate);

            var mockDal = Mock.Of<IDAL>();
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Patate")).Returns(lstAlimentsSel);
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Sel")).Returns(lstAlimentsPatate);

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();

            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            Assert.IsTrue(recetteMgr.TrouverSiRecettePossible(recette));

        }

        [TestMethod()]
        public void TestTrouverSiRecettePossibleAvecAlimentAvecDate()
        {
            Recette recette = CreerRecette();

            Aliment alimentInventairePatate = new Aliment();
            alimentInventairePatate.Nom = "Patate";
            alimentInventairePatate.Quantite = 10;
            alimentInventairePatate.ExpireLe = new DateTime(2022, 10, 10);

            Aliment alimentInventaireSel = new Aliment();
            alimentInventaireSel.Nom = "Sel";
            alimentInventaireSel.Quantite = 12;
            alimentInventaireSel.ExpireLe = new DateTime(2022, 10, 10);


            List<Aliment> lstAlimentsSel = new List<Aliment>();
            lstAlimentsSel.Add(alimentInventaireSel);

            List<Aliment> lstAlimentsPatate = new List<Aliment>();
            lstAlimentsPatate.Add(alimentInventairePatate);
            

            var mockDal = Mock.Of<IDAL>();
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Patate")).Returns(lstAlimentsSel);
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Sel")).Returns(lstAlimentsPatate);

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();

            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            Assert.IsTrue(recetteMgr.TrouverSiRecettePossible(recette));

        }

        [TestMethod()]
        public void TestTrouverSiRecettePossibleSAvecQuatiteDejaReserver()
        {
            Recette recette = CreerRecette();

            Aliment alimentInventairePatate = new Aliment();
            alimentInventairePatate.Nom = "Patate";
            alimentInventairePatate.Quantite = 15;
            alimentInventairePatate.ExpireLe = new DateTime(2022, 10, 10);

            Aliment alimentInventaireSel = new Aliment();
            alimentInventaireSel.Nom = "Sel";
            alimentInventaireSel.Quantite = 12;
            alimentInventaireSel.ExpireLe = new DateTime(2022, 10, 10);


            List<Aliment> lstAlimentsSel = new List<Aliment>();
            lstAlimentsSel.Add(alimentInventaireSel);

            List<Aliment> lstAlimentsPatate = new List<Aliment>();
            lstAlimentsPatate.Add(alimentInventairePatate);


            var mockDal = Mock.Of<IDAL>();
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Patate")).Returns(lstAlimentsSel);
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Sel")).Returns(lstAlimentsPatate);

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();
            alimentReserves.Add("Patate", 2);
            alimentReserves.Add("Sel", 2);


            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            Assert.IsTrue(recetteMgr.TrouverSiRecettePossible(recette));

        }

        [TestMethod()]
        public void TestTrouverSiRecettePossibleAvecAlimentAvecDateExpirer()
        {
            Recette recette = CreerRecette();

            Aliment alimentInventairePatate = new Aliment();
            alimentInventairePatate.Nom = "Patate";
            alimentInventairePatate.Quantite = 10;
            alimentInventairePatate.ExpireLe = new DateTime(2020, 10, 10);

            Aliment alimentInventaireSel = new Aliment();
            alimentInventaireSel.Nom = "Sel";
            alimentInventaireSel.Quantite = 12;
            alimentInventaireSel.ExpireLe = new DateTime(2020, 10, 10);


            List<Aliment> lstAlimentsSel = new List<Aliment>();
            lstAlimentsSel.Add(alimentInventaireSel);

            List<Aliment> lstAlimentsPatate = new List<Aliment>();
            lstAlimentsPatate.Add(alimentInventairePatate);


            var mockDal = Mock.Of<IDAL>();
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Patate")).Returns(lstAlimentsSel);
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Sel")).Returns(lstAlimentsPatate);

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();

            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            Assert.IsTrue(!recetteMgr.TrouverSiRecettePossible(recette));

        }

        [TestMethod()]
        public void TestTrouverSiRecettePossibleAvecAlimentAvecInventaireVide()
        {
            Recette recette = CreerRecette();

            List<Aliment> lstAlimentsSel = new List<Aliment>();
            
            List<Aliment> lstAlimentsPatate = new List<Aliment>();

            var mockDal = Mock.Of<IDAL>();
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Patate")).Returns(lstAlimentsSel);
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Sel")).Returns(lstAlimentsPatate);

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();

            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            Assert.IsTrue(!recetteMgr.TrouverSiRecettePossible(recette));

        }

        [TestMethod()]
        public void TestTrouverSiRecettePossibleAvecUnAlimentAvecPasEnBonneQuatite()
        {
            Recette recette = CreerRecette();

            Aliment alimentInventairePatate = new Aliment();
            alimentInventairePatate.Nom = "Patate";
            alimentInventairePatate.Quantite = 5;
            

            Aliment alimentInventaireSel = new Aliment();
            alimentInventaireSel.Nom = "Sel";
            alimentInventaireSel.Quantite = 12;
          


            List<Aliment> lstAlimentsSel = new List<Aliment>();
            lstAlimentsSel.Add(alimentInventaireSel);

            List<Aliment> lstAlimentsPatate = new List<Aliment>();
            lstAlimentsPatate.Add(alimentInventairePatate);


            var mockDal = Mock.Of<IDAL>();
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Patate")).Returns(lstAlimentsSel);
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Sel")).Returns(lstAlimentsPatate);

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();

            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            Assert.IsTrue(!recetteMgr.TrouverSiRecettePossible(recette));

        }

        [TestMethod()]
        public void TestTrouverSiRecettePossibleAvecUnAlimentAvecPasEnBonneQuatiteAvecPlusieursItem()
        {
            Recette recette = CreerRecette();

            Aliment alimentInventairePatate = new Aliment();
            alimentInventairePatate.Nom = "Patate";
            alimentInventairePatate.Quantite = 4;


            Aliment alimentInventaireSel = new Aliment();
            alimentInventaireSel.Nom = "Sel";
            alimentInventaireSel.Quantite = 12;



            List<Aliment> lstAlimentsSel = new List<Aliment>();
            lstAlimentsSel.Add(alimentInventaireSel);

            List<Aliment> lstAlimentsPatate = new List<Aliment>();
            lstAlimentsPatate.Add(alimentInventairePatate);
            lstAlimentsPatate.Add(alimentInventairePatate);


            var mockDal = Mock.Of<IDAL>();
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Patate")).Returns(lstAlimentsSel);
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Sel")).Returns(lstAlimentsPatate);

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();

            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            Assert.IsTrue(!recetteMgr.TrouverSiRecettePossible(recette));

        }

        [TestMethod()]
        public void TestTrouverSiRecettePossibleSiManqueQuatiteApresReservation()
        {
            Recette recette = CreerRecette();

            Aliment alimentInventairePatate = new Aliment();
            alimentInventairePatate.Nom = "Patate";
            alimentInventairePatate.Quantite = 15;
           

            Aliment alimentInventaireSel = new Aliment();
            alimentInventaireSel.Nom = "Sel";
            alimentInventaireSel.Quantite = 12;
           


            List<Aliment> lstAlimentsSel = new List<Aliment>();
            lstAlimentsSel.Add(alimentInventaireSel);

            List<Aliment> lstAlimentsPatate = new List<Aliment>();
            lstAlimentsPatate.Add(alimentInventairePatate);


            var mockDal = Mock.Of<IDAL>();
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Patate")).Returns(lstAlimentsSel);
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Sel")).Returns(lstAlimentsPatate);

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();
            alimentReserves.Add("Patate", 7);
            alimentReserves.Add("Sel", 7);


            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            Assert.IsTrue(!recetteMgr.TrouverSiRecettePossible(recette));

        }

        [TestMethod()]
        public void TestReserverAlimentsRecetteAvecAucunAlimentDejaReserve()
        {
            Recette recette = CreerRecette();

            var mockDal = Mock.Of<IDAL>();

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();

            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            recetteMgr.ReserverAlimentsRecette(recette);

            int quantitePatate = recetteMgr.alimentsReserves["Patate"];
            int quantiteSel = recetteMgr.alimentsReserves["Sel"];

            Assert.IsTrue(10 == quantitePatate && 10 == quantiteSel);

        }

        [TestMethod()]
        public void TestReserverAlimentsRecetteAvecUnAlimentDejaReserve()
        {
            Recette recette = CreerRecette();

            var mockDal = Mock.Of<IDAL>();

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();
            alimentReserves.Add("Patate", 20);

            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            recetteMgr.ReserverAlimentsRecette(recette);

            int quantitePatate = recetteMgr.alimentsReserves["Patate"];
            int quantiteSel = recetteMgr.alimentsReserves["Sel"];

            Assert.IsTrue(30 == quantitePatate && 10 == quantiteSel);

        }
        [TestMethod()]
        public void TestReserverAlimentsRecetteAvecAlimentsDejaReserves()
        {
            Recette recette = CreerRecette();

            var mockDal = Mock.Of<IDAL>();

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();
            alimentReserves.Add("Patate", 20);
            alimentReserves.Add("Sel", 20);

            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            recetteMgr.ReserverAlimentsRecette(recette);

            int quantitePatate = recetteMgr.alimentsReserves["Patate"];
            int quantiteSel = recetteMgr.alimentsReserves["Sel"];

            Assert.IsTrue(30 == quantitePatate && 30 == quantiteSel);

        }

        [TestMethod]
        public void TestSupprimerReservationAliment()
        {
            Recette recette = CreerRecette();

            var mockDal = Mock.Of<IDAL>();

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();
            alimentReserves.Add("Patate", 20);
            alimentReserves.Add("Sel", 20);

            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            recetteMgr.SupprimerReservationAlimentsRecette(recette);

            int quantitePatate = recetteMgr.alimentsReserves["Patate"];
            int quantiteSel = recetteMgr.alimentsReserves["Sel"];

            Assert.IsTrue(10 == quantitePatate && 10 == quantiteSel);
        }
        [TestMethod]
        public void TestSupprimerReservationAlimentAvecQuatiteJuste()
        {
            Recette recette = CreerRecette();

            var mockDal = Mock.Of<IDAL>();

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();
            alimentReserves.Add("Patate", 10);
            alimentReserves.Add("Sel", 10);

            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            recetteMgr.SupprimerReservationAlimentsRecette(recette);

            Assert.IsTrue(!recetteMgr.alimentsReserves.ContainsKey("Patate") && !recetteMgr.alimentsReserves.ContainsKey("Sel"));
        }

        [TestMethod]
        public void TestSupprimerReservationAlimentSansAliment()
        {
            Recette recette = CreerRecette();

            var mockDal = Mock.Of<IDAL>();

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();
            
            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            recetteMgr.SupprimerReservationAlimentsRecette(recette);

            Assert.IsTrue(!recetteMgr.alimentsReserves.ContainsKey("Patate") && !recetteMgr.alimentsReserves.ContainsKey("Sel"));
        }

        [TestMethod()]
        public void TestConfirmerLaReservationInventaireEnPlusGrosseQuatite()
        {

            Aliment alimentInventairePatate = new Aliment();
            alimentInventairePatate.Nom = "Patate";
            alimentInventairePatate.Quantite = 100;

            Aliment alimentInventaireSel = new Aliment();
            alimentInventaireSel.Nom = "Sel";
            alimentInventaireSel.Quantite = 100;

            Aliment aliment = new Aliment();

            List<Aliment> lstAlimentsSel = new List<Aliment>();
            lstAlimentsSel.Add(alimentInventaireSel);

            List<Aliment> lstAlimentsPatate = new List<Aliment>();
            lstAlimentsPatate.Add(alimentInventairePatate);

            var mockDal = Mock.Of<IDAL>();
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Patate")).Returns(lstAlimentsSel);
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Sel")).Returns(lstAlimentsPatate);
            Mock.Get(mockDal).Setup(m => m.ModifierAliment(alimentInventairePatate)).Returns(aliment);
            Mock.Get(mockDal).Setup(m => m.ModifierAliment(alimentInventaireSel)).Returns(aliment);

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();
            alimentReserves.Add("Patate", 10);
            alimentReserves.Add("Sel", 10);

            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            Assert.IsTrue(recetteMgr.ConfirmerLaReservation());

        }
        [TestMethod()]
        public void TestConfirmerLaReservationInventaireEnQuatiteEgal ()
        {

            Aliment alimentInventairePatate = new Aliment();
            alimentInventairePatate.Nom = "Patate";
            alimentInventairePatate.Quantite = 10;

            Aliment alimentInventaireSel = new Aliment();
            alimentInventaireSel.Nom = "Sel";
            alimentInventaireSel.Quantite = 10;

            Aliment aliment = new Aliment();

            List<Aliment> lstAlimentsSel = new List<Aliment>();
            lstAlimentsSel.Add(alimentInventaireSel);

            List<Aliment> lstAlimentsPatate = new List<Aliment>();
            lstAlimentsPatate.Add(alimentInventairePatate);

            var mockDal = Mock.Of<IDAL>();
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Patate")).Returns(lstAlimentsSel);
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Sel")).Returns(lstAlimentsPatate);
            Mock.Get(mockDal).Setup(m => m.SupprimerAliment(alimentInventairePatate)).Returns(aliment);
            Mock.Get(mockDal).Setup(m => m.SupprimerAliment(alimentInventaireSel)).Returns(aliment);

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();
            alimentReserves.Add("Patate", 10);
            alimentReserves.Add("Sel", 10);

            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            Assert.IsTrue(recetteMgr.ConfirmerLaReservation());

        }

        [TestMethod()]
        public void TestConfirmerLaReservationInventaireAvecDeuxItemEnQuatiteEgal()
        {

            Aliment alimentInventairePatate = new Aliment();
            alimentInventairePatate.Nom = "Patate";
            alimentInventairePatate.Quantite = 10;

            Aliment alimentInventaireSel = new Aliment();
            alimentInventaireSel.Nom = "Sel";
            alimentInventaireSel.Quantite = 5;

            Aliment alimentInventaireSel1 = new Aliment();
            alimentInventaireSel1.Nom = "Sel";
            alimentInventaireSel1.Quantite = 5;

            Aliment aliment = new Aliment();

            List<Aliment> lstAlimentsSel = new List<Aliment>();
            lstAlimentsSel.Add(alimentInventaireSel);
            lstAlimentsSel.Add(alimentInventaireSel1);

            List<Aliment> lstAlimentsPatate = new List<Aliment>();
            lstAlimentsPatate.Add(alimentInventairePatate);

            var mockDal = Mock.Of<IDAL>();
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Patate")).Returns(lstAlimentsSel);
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Sel")).Returns(lstAlimentsPatate);
            Mock.Get(mockDal).Setup(m => m.SupprimerAliment(alimentInventairePatate)).Returns(aliment);
            Mock.Get(mockDal).Setup(m => m.ModifierAliment(alimentInventaireSel)).Returns(aliment);
            Mock.Get(mockDal).Setup(m => m.ModifierAliment(alimentInventaireSel1)).Returns(aliment);
            Mock.Get(mockDal).Setup(m => m.SupprimerAliment(alimentInventaireSel)).Returns(aliment);
            Mock.Get(mockDal).Setup(m => m.SupprimerAliment(alimentInventaireSel1)).Returns(aliment);

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();
            alimentReserves.Add("Patate", 10);
            alimentReserves.Add("Sel", 10);

            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            Assert.IsTrue(recetteMgr.ConfirmerLaReservation());

        }

        [TestMethod()]
        public void TestConfirmerLaReservationInventaireAvecDeuxItemEnQuatiteSuperieur()
        {

            Aliment alimentInventairePatate = new Aliment();
            alimentInventairePatate.Nom = "Patate";
            alimentInventairePatate.Quantite = 10;

            Aliment alimentInventaireSel = new Aliment();
            alimentInventaireSel.Nom = "Sel";
            alimentInventaireSel.Quantite = 5;

            Aliment alimentInventaireSel1 = new Aliment();
            alimentInventaireSel1.Nom = "Sel";
            alimentInventaireSel1.Quantite = 15;

            Aliment aliment = new Aliment();

            List<Aliment> lstAlimentsSel = new List<Aliment>();
            lstAlimentsSel.Add(alimentInventaireSel);
            lstAlimentsSel.Add(alimentInventaireSel1);

            List<Aliment> lstAlimentsPatate = new List<Aliment>();
            lstAlimentsPatate.Add(alimentInventairePatate);

            var mockDal = Mock.Of<IDAL>();
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Patate")).Returns(lstAlimentsSel);
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Sel")).Returns(lstAlimentsPatate);
            Mock.Get(mockDal).Setup(m => m.SupprimerAliment(alimentInventairePatate)).Returns(aliment);
            Mock.Get(mockDal).Setup(m => m.ModifierAliment(alimentInventaireSel)).Returns(aliment);
            Mock.Get(mockDal).Setup(m => m.ModifierAliment(alimentInventaireSel1)).Returns(aliment);
            Mock.Get(mockDal).Setup(m => m.SupprimerAliment(alimentInventaireSel)).Returns(aliment);
            Mock.Get(mockDal).Setup(m => m.SupprimerAliment(alimentInventaireSel1)).Returns(aliment);

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();
            alimentReserves.Add("Patate", 10);
            alimentReserves.Add("Sel", 10);

            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            Assert.IsTrue(recetteMgr.ConfirmerLaReservation());

        }

        [TestMethod()]
        public void TestConfirmerLaReservationInventaireAvecDeuxItemEnQuatiteInferieur()
        {

            Aliment alimentInventairePatate = new Aliment();
            alimentInventairePatate.Nom = "Patate";
            alimentInventairePatate.Quantite = 10;

            Aliment alimentInventaireSel = new Aliment();
            alimentInventaireSel.Nom = "Sel";
            alimentInventaireSel.Quantite = 5;

            Aliment alimentInventaireSel1 = new Aliment();
            alimentInventaireSel1.Nom = "Sel";
            alimentInventaireSel1.Quantite = 2;

            Aliment aliment = new Aliment();

            List<Aliment> lstAlimentsSel = new List<Aliment>();
            lstAlimentsSel.Add(alimentInventaireSel);
            lstAlimentsSel.Add(alimentInventaireSel1);

            List<Aliment> lstAlimentsPatate = new List<Aliment>();
            lstAlimentsPatate.Add(alimentInventairePatate);

            var mockDal = Mock.Of<IDAL>();
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Patate")).Returns(lstAlimentsSel);
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Sel")).Returns(lstAlimentsPatate);
            Mock.Get(mockDal).Setup(m => m.SupprimerAliment(alimentInventairePatate)).Returns(aliment);
            Mock.Get(mockDal).Setup(m => m.ModifierAliment(alimentInventaireSel)).Returns(aliment);
            Mock.Get(mockDal).Setup(m => m.ModifierAliment(alimentInventaireSel1)).Returns(aliment);
            Mock.Get(mockDal).Setup(m => m.SupprimerAliment(alimentInventaireSel)).Returns(aliment);
            Mock.Get(mockDal).Setup(m => m.SupprimerAliment(alimentInventaireSel1)).Returns(aliment);

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();
            alimentReserves.Add("Patate", 10);
            alimentReserves.Add("Sel", 10);

            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            Assert.IsTrue(!recetteMgr.ConfirmerLaReservation());

        }

        [TestMethod()]
        public void TestConfirmerLaReservationInventaireAvecUnItemEnQuatiteInferieur()
        {

            Aliment alimentInventairePatate = new Aliment();
            alimentInventairePatate.Nom = "Patate";
            alimentInventairePatate.Quantite = 10;

            Aliment alimentInventaireSel = new Aliment();
            alimentInventaireSel.Nom = "Sel";
            alimentInventaireSel.Quantite = 5;

            Aliment aliment = new Aliment();

            List<Aliment> lstAlimentsSel = new List<Aliment>();
            lstAlimentsSel.Add(alimentInventaireSel);
          

            List<Aliment> lstAlimentsPatate = new List<Aliment>();
            lstAlimentsPatate.Add(alimentInventairePatate);

            var mockDal = Mock.Of<IDAL>();
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Patate")).Returns(lstAlimentsSel);
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Sel")).Returns(lstAlimentsPatate);
            Mock.Get(mockDal).Setup(m => m.SupprimerAliment(alimentInventairePatate)).Returns(aliment);
            Mock.Get(mockDal).Setup(m => m.ModifierAliment(alimentInventaireSel)).Returns(aliment);
            Mock.Get(mockDal).Setup(m => m.SupprimerAliment(alimentInventaireSel)).Returns(aliment);
            

            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();
            alimentReserves.Add("Patate", 10);
            alimentReserves.Add("Sel", 10);

            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            Assert.IsTrue(!recetteMgr.ConfirmerLaReservation());

        }

        [TestMethod()]
        public void TestConfirmerLaReservationInventaireAvecUnItemAvecUnDateExpire()
        {

            Aliment alimentInventairePatate = new Aliment();
            alimentInventairePatate.Nom = "Patate";
            alimentInventairePatate.Quantite = 10;

            Aliment alimentInventaireSel = new Aliment();
            alimentInventaireSel.Nom = "Sel";
            alimentInventaireSel.Quantite = 50;
            alimentInventaireSel.ExpireLe = new DateTime(2020, 10, 10);

            Aliment aliment = new Aliment();

            List<Aliment> lstAlimentsSel = new List<Aliment>();
            lstAlimentsSel.Add(alimentInventaireSel);


            List<Aliment> lstAlimentsPatate = new List<Aliment>();
            lstAlimentsPatate.Add(alimentInventairePatate);

            var mockDal = Mock.Of<IDAL>();
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Patate")).Returns(lstAlimentsSel);
            Mock.Get(mockDal).Setup(m => m.VoirUnAliment("Sel")).Returns(lstAlimentsPatate);
            Mock.Get(mockDal).Setup(m => m.SupprimerAliment(alimentInventairePatate)).Returns(aliment);
            Mock.Get(mockDal).Setup(m => m.ModifierAliment(alimentInventaireSel)).Returns(aliment);
            Mock.Get(mockDal).Setup(m => m.SupprimerAliment(alimentInventaireSel)).Returns(aliment);


            Dictionary<string, int> alimentReserves = new Dictionary<string, int>();
            alimentReserves.Add("Patate", 10);
            alimentReserves.Add("Sel", 10);

            RecetteMgr recetteMgr = new RecetteMgr(mockDal, alimentReserves);

            Assert.IsTrue(!recetteMgr.ConfirmerLaReservation());

        }

        private Recette CreerRecette()
        {
            Aliment alimentRecettePatate = new Aliment();
            alimentRecettePatate.Nom = "Patate";
            alimentRecettePatate.Quantite = 10;

            Aliment alimentRecetteSel = new Aliment();
            alimentRecetteSel.Nom = "Sel";
            alimentRecetteSel.Quantite = 10;

            List<Aliment> lstAlimentsRecette = new List<Aliment>();
            lstAlimentsRecette.Add(alimentRecetteSel);
            lstAlimentsRecette.Add(alimentRecettePatate);


            Recette recette = new Recette();
            recette.Nom = "Frite";
            recette.Prix = 10;
            recette.Ingredients = lstAlimentsRecette;

            return recette;
        }



    }
}