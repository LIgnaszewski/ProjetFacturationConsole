using System;

namespace ProjetFacturationConsole.App
{
    public class Entreprise : Personne
    {
        private string siret;

        public string Siret { get { return siret; } set { siret = value; } }

        public Entreprise(int id, string nom, string email, string telephone, string adresse, string ville, string codePostal, string siret) 
            : base(id, nom, email, telephone, adresse, ville, codePostal)
        {
            this.siret = siret;
        }
    }
}
