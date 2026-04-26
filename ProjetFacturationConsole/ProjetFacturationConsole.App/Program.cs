using System;

namespace ProjetFacturationConsole.App
{
    class Program
    {
        static void Main(string[] args)
        {
            GestionFacturation gestion = new GestionFacturation();
            
            Console.WriteLine("--- Test de l'affichage du carnet de contacts ---");
            // Appelle la méthode qui charge et affiche tout le carnet
            gestion.AfficherCarnetContacts();
        }
    }
}
