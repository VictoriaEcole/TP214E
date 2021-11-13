using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace TP214E.Data
{
    public class Recette
    {
        public ObjectId Id { get; set; }
        public string Nom { get; set; }
        public List<Aliment> Ingredients { get; set; }
        public Decimal Prix { get; set; }

        public override string ToString()
        {
            return this.Nom.PadRight(25) + " " + Prix.ToString("0.00") + "$";
        }

    }
}
