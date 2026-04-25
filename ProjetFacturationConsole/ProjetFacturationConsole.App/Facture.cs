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

        public string ConstruireTexteFacture()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("FACTURE");
            sb.AppendLine($"Numéro : {Numero}");
            sb.AppendLine($"Date d'émission : {DateEmission:dd/MM/yyyy}");
            sb.AppendLine($"Date d'échéance : {DateEcheance:dd/MM/yyyy}");
            sb.AppendLine($"Statut : {Statut}");
            sb.AppendLine($"Entreprise : {Entreprise.Id} - {Entreprise.Nom} - {Entreprise.Email} - {Entreprise.Telephone} - {Entreprise.Adresse} - {Entreprise.Ville} - {Entreprise.CodePostal} - {Entreprise.Siret}");
            sb.AppendLine($"Client : {Client.Id} - {Client.Nom} - {Client.Email} - {Client.Telephone} - {Client.Adresse} - {Client.Ville} - {Client.CodePostal} - {Client.DateInscription:dd/MM/yyyy}");
            sb.AppendLine("Lignes :");
            for (int i = 0; i < Lignes.Count; i++)
            {
                var l = Lignes[i];
                sb.AppendLine($"{i + 1}. {l.Description} - Qté : {l.Quantite} - PU HT : {l.PrixUnitaireHT} - TVA : {l.TauxTVA} - Total HT : {l.CalculerTotalHT()} - Total TTC : {l.CalculerTotalTTC()}");
            }
            sb.AppendLine($"Total HT : {CalculerTotalHT()}");
            sb.AppendLine($"Total TVA : {CalculerTotalTVA()}");
            sb.AppendLine($"Total TTC : {CalculerTotalTTC()}");
            return sb.ToString();
        }

        public override void AfficherFacture()
        {
            Console.WriteLine(ConstruireTexteFacture());
        }
    }
}
