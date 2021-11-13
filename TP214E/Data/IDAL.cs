using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public interface IDAL
    {
        public List<Aliment> VoirAliments();

        public List<Aliment> VoirUnAliment(string nom);

        public Aliment AjouterAliment(Aliment pAliment);

        public Aliment SupprimerAliment(Aliment pAliment);

        public Aliment ModifierAliment(Aliment pAliment0);

        public List<Recette> Recettes();

        public Commande AjouterCommande(Commande commande);

        public List<Commande> VoirCommandes();
       
    }
}
