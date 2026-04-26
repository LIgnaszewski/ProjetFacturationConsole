using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetFacturationConsole.App;

namespace ProjetFacturationConsole.Tests
{
    [TestClass]
    public class LigneFactureTests
    {
        [TestMethod]
        public void CalculerTotalHT_DevraitRetournerLeBonMontant()
        {
            LigneFacture ligne = new LigneFacture("Test", 2, 100m, 20m);
            decimal totalHT = ligne.CalculerTotalHT();
            Assert.AreEqual(200m, totalHT);
        }

        [TestMethod]
        public void CalculerMontantTVA_DevraitRetournerLeBonMontant()
        {
            LigneFacture ligne = new LigneFacture("Test", 2, 100m, 20m);
            decimal tva = ligne.CalculerMontantTVA();
            Assert.AreEqual(40m, tva);
        }

        [TestMethod]
        public void CalculerTotalTTC_DevraitRetournerLeBonMontant()
        {
            LigneFacture ligne = new LigneFacture("Test", 2, 100m, 20m);
            decimal totalTTC = ligne.CalculerTotalTTC();
            Assert.AreEqual(240m, totalTTC);
        }
    }
}
