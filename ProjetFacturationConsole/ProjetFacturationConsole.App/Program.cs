using System;

namespace ProjetFacturationConsole.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client(1, "Paul Durand", "paul@mail.fr", "0606060606", "1 rue A", "Paris", "75000", DateTime.Now);
            Entreprise e = new Entreprise(2, "TechNova", "tech@nova.fr", "0303030303", "2 rue B", "Lyon", "69000", "12345678900011");
            
            c.AfficherInfos();
            e.AfficherInfos();

            LigneFacture lf1 = new LigneFacture("Dev", 2, 150m, 20m);
            LigneFacture lf2 = new LigneFacture("Maintenance", 1, 80m, 10m);

            Facture f = new Facture("F001", DateTime.Now, c, e, DateTime.Now.AddDays(30), "Brouillon");
            f.AjouterLigne(lf1);
            f.AjouterLigne(lf2);

            f.AfficherFacture();
        }
    }
}
