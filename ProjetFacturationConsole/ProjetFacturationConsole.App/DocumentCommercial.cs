using System;
using System.Collections.Generic;

namespace ProjetFacturationConsole.App
{
    public abstract class DocumentCommercial
    {
        protected string numero;
        protected DateTime dateEmission;
        protected Client client;
        protected Entreprise entreprise;
        protected List<LigneFacture> lignes;

        public string Numero { get { return numero; } set { numero = value; } }
        public DateTime DateEmission { get { return dateEmission; } set { dateEmission = value; } }
        public Client Client { get { return client; } set { client = value; } }
        public Entreprise Entreprise { get { return entreprise; } set { entreprise = value; } }
        public List<LigneFacture> Lignes { get { return lignes; } set { lignes = value; } }

        protected DocumentCommercial(string numero, DateTime dateEmission, Client client, Entreprise entreprise)
        {
            this.numero = numero;
            this.dateEmission = dateEmission;
            this.client = client;
            this.entreprise = entreprise;
            this.lignes = new List<LigneFacture>();
        }

        public void AjouterLigne(LigneFacture ligne)
        {
            Lignes.Add(ligne);
        }

        public decimal CalculerTotalHT()
        {
            decimal total = 0;
            foreach (var ligne in Lignes)
            {
                total += ligne.CalculerTotalHT();
            }
            return total;
        }

        public decimal CalculerTotalTVA()
        {
            decimal total = 0;
            foreach (var ligne in Lignes)
            {
                total += ligne.CalculerMontantTVA();
            }
            return total;
        }

        public decimal CalculerTotalTTC()
        {
            decimal total = 0;
            foreach (var ligne in Lignes)
            {
                total += ligne.CalculerTotalTTC();
            }
            return total;
        }

        public abstract void AfficherFacture();
    }
}
