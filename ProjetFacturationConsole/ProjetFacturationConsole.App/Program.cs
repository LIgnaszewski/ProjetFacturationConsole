using System;

namespace ProjetFacturationConsole.App
{
    class Program
    {
        static void Main(string[] args)
        {
            GestionFacturation gestion = new GestionFacturation();
            
            Console.WriteLine("--- Affichage des Clients ---");
            gestion.AfficherClients();
            
            Console.WriteLine("\n--- Affichage des Entreprises ---");
            gestion.AfficherEntreprises();
        }
    }
}
