using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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

        public void ImporterClientsDepuisCsv()
        {
            if (File.Exists("clients.csv"))
            {
                var lines = File.ReadAllLines("clients.csv");
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    if (line.StartsWith("id", StringComparison.OrdinalIgnoreCase)) continue;

                    try
                    {
                        var parts = line.Split(';');
                        if (parts.Length >= 8)
                        {
                            int id = int.Parse(parts[0]);
                            string nom = parts[1];
                            string email = parts[2];
                            string telephone = parts[3];
                            string adresse = parts[4];
                            string ville = parts[5];
                            string codePostal = parts[6];
                            DateTime dateInscription = DateTime.Parse(parts[7]);

                            Client c = new Client(id, nom, email, telephone, adresse, ville, codePostal, dateInscription);
                            Clients.Add(c);
                            DictionnaireClients[id] = c;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erreur lors de l'importation d'un client : {ex.Message}");
                    }
                }
                string json = JsonSerializer.Serialize(Clients, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("clients.json", json);
            }
        }

        public void ImporterEntreprisesDepuisCsv()
        {
            if (File.Exists("entreprises.csv"))
            {
                var lines = File.ReadAllLines("entreprises.csv");
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    if (line.StartsWith("id", StringComparison.OrdinalIgnoreCase)) continue;

                    try
                    {
                        var parts = line.Split(';');
                        if (parts.Length >= 8)
                        {
                            int id = int.Parse(parts[0]);
                            string nom = parts[1];
                            string email = parts[2];
                            string telephone = parts[3];
                            string adresse = parts[4];
                            string ville = parts[5];
                            string codePostal = parts[6];
                            string siret = parts[7];

                            Entreprise e = new Entreprise(id, nom, email, telephone, adresse, ville, codePostal, siret);
                            Entreprises.Add(e);
                            DictionnaireEntreprises[id] = e;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erreur lors de l'importation d'une entreprise : {ex.Message}");
                    }
                }
                string json = JsonSerializer.Serialize(Entreprises, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("entreprises.json", json);
            }
        }

        public void ChargerClientsDepuisJson()
        {
            if (File.Exists("clients.json"))
            {
                string json = File.ReadAllText("clients.json");
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                Clients = JsonSerializer.Deserialize<List<Client>>(json, options) ?? new List<Client>();
                DictionnaireClients.Clear();
                foreach (var c in Clients)
                {
                    DictionnaireClients[c.Id] = c;
                }
            }
        }

        public void ChargerEntreprisesDepuisJson()
        {
            if (File.Exists("entreprises.json"))
            {
                string json = File.ReadAllText("entreprises.json");
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                Entreprises = JsonSerializer.Deserialize<List<Entreprise>>(json, options) ?? new List<Entreprise>();
                DictionnaireEntreprises.Clear();
                foreach (var e in Entreprises)
                {
                    DictionnaireEntreprises[e.Id] = e;
                }
            }
        }

        public void AfficherClients()
        {
            if (Clients == null || Clients.Count == 0)
            {
                ChargerClientsDepuisJson();
            }
            
            foreach (var c in Clients)
            {
                Console.WriteLine($"{c.Id} - {c.Nom}");
            }
        }

        public void AfficherEntreprises()
        {
            if (Entreprises == null || Entreprises.Count == 0)
            {
                ChargerEntreprisesDepuisJson();
            }
            
            foreach (var e in Entreprises)
            {
                Console.WriteLine($"{e.Id} - {e.Nom}");
            }
        }

        public void CreerFacture()
        {
            if (Clients == null || Clients.Count == 0) ChargerClientsDepuisJson();
            if (Entreprises == null || Entreprises.Count == 0) ChargerEntreprisesDepuisJson();

            AfficherEntreprises();
            Entreprise entreprise = null;
            while (entreprise == null)
            {
                try
                {
                    Console.Write("Saisir l'identifiant de l'entreprise : ");
                    int idEntreprise = int.Parse(Console.ReadLine());
                    entreprise = DictionnaireEntreprises[idEntreprise];
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur : {ex.Message}");
                }
            }

            AfficherClients();
            Client client = null;
            while (client == null)
            {
                try
                {
                    Console.Write("Saisir l'identifiant du client : ");
                    int idClient = int.Parse(Console.ReadLine());
                    client = DictionnaireClients[idClient];
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur : {ex.Message}");
                }
            }

            Console.Write("Saisir le numéro de la facture : ");
            string numero = Console.ReadLine();

            DateTime dateEmission = DateTime.Now;
            bool dateValide = false;
            while (!dateValide)
            {
                try
                {
                    Console.Write("Saisir la date d'émission (jj/mm/aaaa) : ");
                    dateEmission = DateTime.Parse(Console.ReadLine());
                    dateValide = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erreur : La date saisie est invalide.");
                }
            }
            DateTime dateEcheance = dateEmission.AddDays(30);

            Facture facture = new Facture(numero, dateEmission, client, entreprise, dateEcheance, "Brouillon");

            bool continuer = true;
            while (continuer)
            {
                try
                {
                    Console.Write("Saisir la description : ");
                    string description = Console.ReadLine();

                    Console.Write("Saisir la quantité : ");
                    int quantite = int.Parse(Console.ReadLine());

                    Console.Write("Saisir le prix unitaire HT : ");
                    decimal prixUnitaireHT = decimal.Parse(Console.ReadLine());

                    Console.Write("Saisir le taux de TVA : ");
                    decimal tauxTVA = decimal.Parse(Console.ReadLine());

                    LigneFacture ligne = new LigneFacture(description, quantite, prixUnitaireHT, tauxTVA);
                    facture.AjouterLigne(ligne);

                    Console.Write("Voulez-vous ajouter une autre ligne ? (oui/non) ");
                    string rep = Console.ReadLine();
                    if (rep == null || rep.ToLower() != "oui")
                    {
                        continuer = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erreur : Format de donnée invalide (quantité, prix ou taux).");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Erreur : {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur inattendue : {ex.Message}");
                }
            }

            facture.AfficherFacture();

            Console.Write("Confirmer la génération du fichier texte ? (oui/non) ");
            string repConfirmation = Console.ReadLine();
            if (repConfirmation != null && repConfirmation.ToLower() == "oui")
            {
                GenererFichierTexteFacture(facture);
                Console.WriteLine("Fichier généré avec succès.");
            }
        }

        public void GenererFichierTexteFacture(Facture facture)
        {
            string nomFichier = $"facture_{facture.Numero}.txt";
            File.WriteAllText(nomFichier, facture.ConstruireTexteFacture());
        }
    }
}
