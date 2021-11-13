using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP214E.Data;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using Moq;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class AlimentTest
    {
        [TestMethod()]
        public void ToStringSansDateTest()
        {
            Aliment aliment = new Aliment();
            aliment.Nom = "Patate";
            aliment.Quantite = 10;

            Assert.IsTrue(aliment.ToString() == "Patate               10");
        }

        [TestMethod()]
        public void ToStringAvecDateTest()
        {
            Aliment aliment = new Aliment();
            aliment.Nom = "Patate";
            aliment.Quantite = 10;
            aliment.ExpireLe = DateTime.Now;
            Assert.IsTrue(aliment.ToString() == "Patate               10      " + aliment.ExpireLe.ToString("yyyy/MM/dd"));
        }



    }
}