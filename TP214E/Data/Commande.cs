using System;
using System.Collections.Generic;
using MongoDB.Bson;
namespace TP214E.Data
{
    public class Commande
    {
        public ObjectId Id { get; set; }
        public List<Recette> recettes { get; set; }
        public DateTime Creation { get; set; }

        public override string ToString()
        {
            return this.Id.ToString();
        }
    }
}
