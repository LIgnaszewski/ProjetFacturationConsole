using System;

namespace ProjetFacturationConsole.App
{
    class Program
    {
        static void Main(string[] args)
        {
            GestionFacturation gestion = new GestionFacturation();
            Client c = new Client(1, "Paul Durand", "paul@mail.fr", "0606060606", "1 rue A", "Paris", "75000", DateTime.Now);
            Entreprise e = new Entreprise(2, "TechNova", "tech@nova.fr", "0303030303", "2 rue B", "Lyon", "69000", "12345678900011");
            LigneFacture lf = new LigneFacture("Dev", 2, 150m, 20m);
            Facture f = new Facture("F001", DateTime.Now, c, e, DateTime.Now.AddDays(30), "Brouillon");
            f.Lignes.Add(lf);

            Console.WriteLine("Toutes les classes sont reconnues et compilent !");
        }
    }
}
