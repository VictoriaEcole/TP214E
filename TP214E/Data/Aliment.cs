using MongoDB.Bson;
using System;

namespace TP214E.Data
{
    public class Aliment
    {
        public ObjectId Id { get; set; }
        public string Nom { get; set; }
        public int Quantite { get; set; }
        public string Unite { get; set; }
        public DateTime ExpireLe { get; set; }

        public override string ToString()
        {

            if (this.ExpireLe == DateTime.MinValue)
            {
                return this.Nom.PadRight(20) +  " " + this.Quantite.ToString() + this.Unite;
            }
            else 
            {
                return this.Nom.PadRight(20) + " " + (this.Quantite.ToString() + this.Unite).PadRight(8) + (this.ExpireLe.ToString("yyyy/MM/dd"));
            }

        }

    }
}
