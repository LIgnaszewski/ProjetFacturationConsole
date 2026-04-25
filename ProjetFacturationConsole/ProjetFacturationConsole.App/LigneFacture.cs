using System;

namespace ProjetFacturationConsole.App
{
    public class LigneFacture
    {
        private string description;
        private int quantite;
        private decimal prixUnitaireHT;
        private decimal tauxTVA;

        public string Description { get { return description; } set { description = value; } }
        public int Quantite { get { return quantite; } set { quantite = value; } }
        public decimal PrixUnitaireHT { get { return prixUnitaireHT; } set { prixUnitaireHT = value; } }
        public decimal TauxTVA { get { return tauxTVA; } set { tauxTVA = value; } }

        public LigneFacture(string description, int quantite, decimal prixUnitaireHT, decimal tauxTVA)
        {
            this.description = description;
            this.quantite = quantite;
            this.prixUnitaireHT = prixUnitaireHT;
            this.tauxTVA = tauxTVA;
        }

        public decimal CalculerTotalHT()
        {
            return Quantite * PrixUnitaireHT;
        }

        public decimal CalculerMontantTVA()
        {
            return CalculerTotalHT() * TauxTVA / 100m;
        }

        public decimal CalculerTotalTTC()
        {
            return CalculerTotalHT() + CalculerMontantTVA();
        }
    }
}
