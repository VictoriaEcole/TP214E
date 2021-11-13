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
    /// Logique d'interaction pour PageAjouterRecette.xaml
    /// </summary>
    public partial class PageAjouterRecette : Page
    {
        private List<Recette> recettesDisponibles;
        private IDAL dal;
        private Dictionary<string, int> alimentsReserves;
        private RecetteMgr recetteMgr;
        public PageAjouterRecette(IDAL dal, List<Recette> recettes, Dictionary<string, int> alimentsReserves)
        {
            InitializeComponent();
            this.recettesDisponibles = recettes;
            this.alimentsReserves = alimentsReserves;
            this.dal = dal;
            this.recetteMgr = new RecetteMgr(dal, alimentsReserves);

            List<Recette> CatalogeDeRecettes = dal.Recettes();

            

            foreach (Recette recette in CatalogeDeRecettes)
            {
                bool recettePossible = recetteMgr.TrouverSiRecettePossible(recette);

                if (recettePossible)
                {
                    lstRecette.Items.Add(recette);
                }
            }
        }
        

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            PageNouvelleCommande frmNouvelleCommande = new PageNouvelleCommande(dal, recettesDisponibles, this.alimentsReserves);
            this.NavigationService.Navigate(frmNouvelleCommande);
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {

            if (lstRecette.SelectedIndex != -1)
            {
                Recette recette = (Recette)lstRecette.SelectedItem;

                recetteMgr.ReserverAlimentsRecette(recette);

                this.recettesDisponibles.Add(recette);

                PageNouvelleCommande frmNouvelleCommande = new PageNouvelleCommande(dal, recettesDisponibles, this.alimentsReserves);
                this.NavigationService.Navigate(frmNouvelleCommande);
            }
        }

        


    }
}
