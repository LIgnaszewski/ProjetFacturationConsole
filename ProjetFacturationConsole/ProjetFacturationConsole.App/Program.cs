using System;

namespace ProjetFacturationConsole.App
{
    class Program
    {
        static void Main(string[] args)
        {
            GestionFacturation gestion = new GestionFacturation();
            
            gestion.ImporterClientsDepuisCsv();
            Console.WriteLine($"Clients importés : {gestion.Clients.Count}");
            
            gestion.ImporterEntreprisesDepuisCsv();
            Console.WriteLine($"Entreprises importées : {gestion.Entreprises.Count}");
            
            if (System.IO.File.Exists("clients.json") && System.IO.File.Exists("entreprises.json"))
            {
                Console.WriteLine("Les fichiers JSON ont été générés avec succès.");
            }
        }
    }
}
