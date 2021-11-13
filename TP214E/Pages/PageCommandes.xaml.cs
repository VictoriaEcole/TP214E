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
using System.Windows.Shapes;
using TP214E.Data;

namespace TP214E.Pages
{
    /// <summary>
    /// Logique d'interaction pour PageCommandes.xaml
    /// </summary>
    public partial class PageCommandes : Page
    {

        private IDAL dal;
        public PageCommandes(IDAL dal)
        {
            InitializeComponent();
            this.dal = dal;

        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            PageAccueil frmAccueil = new PageAccueil();
            this.NavigationService.Navigate(frmAccueil);
        }

        private void btnNouvelleCommande_Click(object sender, RoutedEventArgs e)
        {
            PageNouvelleCommande frmNouvelleCommande = new PageNouvelleCommande(dal);
            this.NavigationService.Navigate(frmNouvelleCommande);

        }

        private void btnHistorique_Click(object sender, RoutedEventArgs e)
        {
            PageHistoriqueCommandes frmHistoriqueCommande = new PageHistoriqueCommandes(dal);
            this.NavigationService.Navigate(frmHistoriqueCommande);
        }
    }
}
