using System;

namespace ProjetFacturationConsole.App
{
    public class Client : Personne
    {
        private DateTime dateInscription;

        public DateTime DateInscription { get { return dateInscription; } set { dateInscription = value; } }

        public Client(int id, string nom, string email, string telephone, string adresse, string ville, string codePostal, DateTime dateInscription) 
            : base(id, nom, email, telephone, adresse, ville, codePostal)
        {
            this.dateInscription = dateInscription;
        }

        public override void AfficherInfos()
        {
            Console.WriteLine($"{Id} - {Nom} - {Email} - {Telephone} - {Adresse} - {Ville} - {CodePostal} - {DateInscription:dd/MM/yyyy}");
        }
    }
}
