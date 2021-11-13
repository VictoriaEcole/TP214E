using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace TP214E.Data
{
    public class DAL :IDAL
    {
        private MongoClient mongoDBClient;
        private IMongoDatabase db;
        private const string erreurConnectionBd = "Impossible de se connecter à la base de données ";

        public DAL()
        {
            mongoDBClient = OuvrirConnexion();
            db = mongoDBClient.GetDatabase("TP2DB");
        }

      

        public List<Aliment> VoirAliments()
        {
            List<Aliment> aliments = new List<Aliment>();
            try
            {
                 
                aliments = db.GetCollection<Aliment>("Aliments").Aggregate().ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(erreurConnectionBd + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return aliments;
        }
        public List<Aliment> VoirUnAliment(string nom)
        {
            List<Aliment> aliments = new List<Aliment>();
            try
            {
               

                aliments = db.GetCollection<Aliment>("Aliments").Find(x => x.Nom == nom).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(erreurConnectionBd + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return aliments;
        }
        public Aliment AjouterAliment(Aliment pAliment)
        {
            try
            {
               
                db.GetCollection<Aliment>("Aliments").InsertOne(pAliment);

            }
            catch (Exception ex)
            {
                MessageBox.Show(erreurConnectionBd + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return pAliment;

        }
        public Aliment SupprimerAliment(Aliment pAliment)
        {
            try
            {
                
                db.GetCollection<Aliment>("Aliments").DeleteOne(a => a.Id == pAliment.Id);

            }
            catch (Exception ex)
            {
                MessageBox.Show(erreurConnectionBd + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return pAliment;

        }
        public Aliment ModifierAliment(Aliment pAliment)
        {
            try
            {

                db.GetCollection<Aliment>("Aliments").ReplaceOne(a => a.Id == pAliment.Id, pAliment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(erreurConnectionBd + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return pAliment;

        }
        public List<Recette> Recettes()
        {
            var recettes = new List<Recette>();
            try
            {
                recettes = db.GetCollection<Recette>("Recettes").Aggregate().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(erreurConnectionBd + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return recettes;
        }
        public Commande AjouterCommande(Commande commande)
        {
            try
            {

                db.GetCollection<Commande>("Commandes").InsertOne(commande);

            }
            catch (Exception ex)
            {
                MessageBox.Show(erreurConnectionBd + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return commande;

        }
        public List<Commande> VoirCommandes()
        {
            var commande = new List<Commande>();
            try
            {

                commande = db.GetCollection<Commande>("Commandes").Aggregate().ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(erreurConnectionBd + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return commande;
        }
        private MongoClient OuvrirConnexion()
        {
            MongoClient dbClient = null;
            try
            {
                dbClient = new MongoClient("mongodb://localhost:27017/TP2DB");
            }
            catch (Exception ex)
            {
                MessageBox.Show(erreurConnectionBd + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dbClient;
        }
    }
}
