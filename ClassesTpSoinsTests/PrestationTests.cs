using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassesMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesMetier.Tests
{
    [TestClass()]
    public class PrestationTests
    {

        [TestMethod()]
        public void CompareToTest()
        {
            Prestation unePrestation = new Prestation("AA", new DateTime(2015, 9, 10, 12, 0, 0), new Intervenant("Durand", "Annie"));
            Prestation uneAutrePrestation = new Prestation("AB", new DateTime(2015, 9, 11, 12, 0, 0), new Intervenant("Sainz", "Olivier"));
            Assert.AreEqual(1, uneAutrePrestation.CompareTo(unePrestation), "Le chiffre attendu est 1");
        } 

        public void CompareToTestV2()
        {
            Prestation unePrestation = new Prestation("BB", new DateTime(2015, 9, 11, 12, 0, 0), new Intervenant("Durand", "Annie"));
            Prestation uneAutrePrestation = new Prestation("BC", new DateTime(2015, 9, 11, 12, 0, 0), new Intervenant("Sainz", "Olivier"));
            Assert.AreEqual(0, uneAutrePrestation.CompareTo(unePrestation), "Le chiffre attendu est 0");
        }

        public void CompareToTestV3()
        {
            Prestation unePrestation = new Prestation("CC", new DateTime(2015, 9, 11, 12, 0, 0), new Intervenant("Durand", "Annie"));
            Prestation uneAutrePrestation = new Prestation("CD", new DateTime(2015, 9, 10, 12, 0, 0), new Intervenant("Sainz", "Olivier"));
            Assert.AreEqual(-1, uneAutrePrestation.CompareTo(unePrestation), "Le chiffre attendu est -1");
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Prestation unePrestation = new Prestation("CC", new DateTime(2015, 9, 11, 12, 0, 0), new Intervenant("Durand", "Annie"));
            Assert.AreEqual(unePrestation.Libelle + " - " + unePrestation.DateHeureSoin.ToString(), "CC - 11/09/2015 12:00:00");
        }

        [TestMethod()]
        public void SommePourRienTest()
        {
            int a = 3;
            int b = 5;
            Prestation unePrestation = new Prestation("XX", new DateTime(2015, 9, 10, 12, 0, 0), new Intervenant("Dupont", "Jean"));
            Assert.AreEqual(8, unePrestation.SommePourRien(a, b), "La somme doit être égale à 8");
        }
    }
}