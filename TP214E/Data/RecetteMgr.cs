using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class RecetteMgr
    {
        private IDAL dal;
        public Dictionary<string, int> alimentsReserves;

        public RecetteMgr(IDAL dal, Dictionary<string, int> alimentsReserves)
        {
            this.dal = dal;
            this.alimentsReserves = alimentsReserves;
        }

        public bool TrouverSiRecettePossible(Recette recette)
        {

            foreach (Aliment aliment in recette.Ingredients)
            {
                List<Aliment> alimentsDisponibles = dal.VoirUnAliment(aliment.Nom);

                if (alimentsDisponibles.Count == 0)
                {
                    return false;

                }

                int quantite = 0;
                int quantiteReservee = 0;

                foreach (Aliment alimentDansInventaire in alimentsDisponibles)
                {
                    if (EstPerime(alimentDansInventaire.ExpireLe))
                    {
                        quantite += alimentDansInventaire.Quantite;
                    }
                }

                if (this.alimentsReserves.ContainsKey(aliment.Nom))
                {
                    quantiteReservee = this.alimentsReserves[aliment.Nom];
                }

                if (quantite < (aliment.Quantite + quantiteReservee))
                {
                    return false;
                }


            }
            return true;
        }
        private bool EstPerime(DateTime date)
        {
            return (date > DateTime.Now || date == DateTime.MinValue);
        }

        public void ReserverAlimentsRecette(Recette recette)
        {
            foreach (Aliment aliment in recette.Ingredients)
            {

                ReserverAliment(aliment);

            }
        }

        private void ReserverAliment(Aliment aliment)
        {
            if (this.alimentsReserves.ContainsKey(aliment.Nom))
            {
                this.alimentsReserves[aliment.Nom] += aliment.Quantite;
            }
            else
            {
                this.alimentsReserves.Add(aliment.Nom, aliment.Quantite);
            }
            return;
        }

        private void SupprimerReservationAliment(Aliment aliment)
        {
            if (this.alimentsReserves[aliment.Nom] == aliment.Quantite)
            {
                this.alimentsReserves.Remove(aliment.Nom);
            }
            else
            {
                this.alimentsReserves[aliment.Nom] -= aliment.Quantite;
            }
            return;
        }

        public void SupprimerReservationAlimentsRecette(Recette recette)
        {
            foreach (Aliment aliment in recette.Ingredients)
            {
                if (this.alimentsReserves.ContainsKey(aliment.Nom))
                {
                    SupprimerReservationAliment(aliment);
                }
            }
        }

        public bool ConfirmerLaReservation()
        {
            foreach (KeyValuePair<string, int> aliment in this.alimentsReserves)
            {

                List<Aliment> alimentsDisponible = dal.VoirUnAliment(aliment.Key);

                alimentsDisponible.Sort((x, y) => x.ExpireLe.CompareTo(y.ExpireLe));

                bool alimentUtilise = false;
                int incrementation = 0;
                int quantiteASupprimer = aliment.Value;

                while (!alimentUtilise)
                {
                    if (EstPerime(alimentsDisponible[incrementation].ExpireLe))
                    {

                        if (alimentsDisponible[incrementation].Quantite > quantiteASupprimer)
                        {
                            alimentsDisponible[incrementation].Quantite -= quantiteASupprimer;
                            dal.ModifierAliment(alimentsDisponible[incrementation]);
                            alimentUtilise = true;
                        }
                        else if (alimentsDisponible[incrementation].Quantite == quantiteASupprimer)
                        {
                            dal.SupprimerAliment(alimentsDisponible[incrementation]);
                            alimentUtilise = true;
                        }
                        else if (alimentsDisponible[incrementation].Quantite < quantiteASupprimer)
                        {
                            dal.SupprimerAliment(alimentsDisponible[incrementation]);
                            quantiteASupprimer -= alimentsDisponible[incrementation].Quantite;
                        }
                    }

                    incrementation++;

                    if (incrementation >= alimentsDisponible.Count && alimentUtilise == false)
                    {
                        return false;
                    }
                }

            }
            return true;

        }
    }
}
