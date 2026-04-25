using System;
using System.Collections.Generic;

namespace ProjetFacturationConsole.App
{
    public class GestionFacturation
    {
        private List<Client> clients;
        private List<Entreprise> entreprises;
        private Dictionary<int, Client> dictionnaireClients;
        private Dictionary<int, Entreprise> dictionnaireEntreprises;

        public List<Client> Clients { get { return clients; } set { clients = value; } }
        public List<Entreprise> Entreprises { get { return entreprises; } set { entreprises = value; } }
        public Dictionary<int, Client> DictionnaireClients { get { return dictionnaireClients; } set { dictionnaireClients = value; } }
        public Dictionary<int, Entreprise> DictionnaireEntreprises { get { return dictionnaireEntreprises; } set { dictionnaireEntreprises = value; } }

        public GestionFacturation()
        {
            this.clients = new List<Client>();
            this.entreprises = new List<Entreprise>();
            this.dictionnaireClients = new Dictionary<int, Client>();
            this.dictionnaireEntreprises = new Dictionary<int, Entreprise>();
        }
    }
}
