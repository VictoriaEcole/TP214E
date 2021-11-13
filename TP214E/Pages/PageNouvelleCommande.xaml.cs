using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TP214E.Data;

namespace TP214E.Pages
{
    /// <summary>
    /// Logique d'interaction pour PageNouvelleCommande.xaml
    /// </summary>
    public partial class PageNouvelleCommande : Page
    {
        private IDAL dal;
        private Dictionary<string, int> alimentsReserves;
        private Decimal totalDeLaFacture;
        private RecetteMgr recetteMgr;

        public PageNouvelleCommande(IDAL dal)
        {
            InitializeComponent();
            this.dal = dal;
            this.alimentsReserves = new Dictionary<string, int>();
            this.totalDeLaFacture = 0;
            this.recetteMgr = new RecetteMgr(dal, alimentsReserves);

        }

        public PageNouvelleCommande(IDAL dal, List<Recette> recettes, Dictionary<string, int> alimentsReserves)
        {
            InitializeComponent();
            this.dal = dal;
            this.alimentsReserves = alimentsReserves;
            this.recetteMgr = new RecetteMgr(dal, alimentsReserves);

            this.totalDeLaFacture = 0;
            if (recettes != null)
            {
                foreach (Recette recette in recettes)
                {
                    lstRepas.Items.Add(recette);
                    totalDeLaFacture += recette.Prix;
                }

                lblTotal.Content = "Total: " + totalDeLaFacture.ToString("0.00") + " $";
            }
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            PageCommandes frmCommandes = new PageCommandes(dal);
            this.NavigationService.Navigate(frmCommandes);
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            List<Recette> recettes = new List<Recette>();

            foreach (var recette in lstRepas.Items)
            {
                recettes.Add((Recette)recette);
            }

            PageAjouterRecette frmAjouterRecette = new PageAjouterRecette(dal, recettes, this.alimentsReserves);
            this.NavigationService.Navigate(frmAjouterRecette);
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (lstRepas.SelectedIndex != -1)
            {
                Recette recette = (Recette)lstRepas.SelectedItem;

                recetteMgr.SupprimerReservationAlimentsRecette(recette);

                lstRepas.Items.Remove(lstRepas.SelectedItem);

                this.totalDeLaFacture -= recette.Prix;
                lblTotal.Content = "Total: " + totalDeLaFacture.ToString("0.00") + " $";
            }

        }


        private void btnTerminer_Click(object sender, RoutedEventArgs e)
        {
            if (lstRepas.Items.Count != 0)
            {
                if (!recetteMgr.ConfirmerLaReservation())
                {
                    MessageBox.Show("L'inventaire ne contient pas assez d'aliments pour terminer la commande", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }


                List<Recette> recettes = new List<Recette>();

                foreach (var recette in lstRepas.Items)
                {
                    recettes.Add((Recette)recette);
                }

                Commande nouvelleCommande = new Commande();
                nouvelleCommande.recettes = recettes;
                nouvelleCommande.Creation = DateTime.Now;

                this.dal.AjouterCommande(nouvelleCommande);

                PageCommandes frmCommandes = new PageCommandes(dal);
                this.NavigationService.Navigate(frmCommandes);
            }
        }
        
    }
}
