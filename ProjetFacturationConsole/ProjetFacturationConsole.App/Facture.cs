using System;

namespace ProjetFacturationConsole.App
{
    public class Facture : DocumentCommercial
    {
        private DateTime dateEcheance;
        private string statut;

        public DateTime DateEcheance { get { return dateEcheance; } set { dateEcheance = value; } }
        public string Statut { get { return statut; } set { statut = value; } }

        public Facture(string numero, DateTime dateEmission, Client client, Entreprise entreprise, DateTime dateEcheance, string statut) 
            : base(numero, dateEmission, client, entreprise)
        {
            this.dateEcheance = dateEcheance;
            this.statut = statut;
        }
    }
}
