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
    public class RecetteTest
    {
        [TestMethod()]
        public void ToStringTest()
        {
            Recette recette = new Recette();
            recette.Nom = "Poutine";
            recette.Prix = 10;
            Assert.IsTrue(recette.ToString() == "Poutine                   10,00$");
        }

    }
}