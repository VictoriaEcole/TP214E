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
    /// Logique d'interaction pour PageHistoriqueCommandes.xaml
    /// </summary>
    public partial class PageHistoriqueCommandes : Page
    {
        private IDAL dal;
        public PageHistoriqueCommandes(IDAL dal)
        {
            InitializeComponent();
            this.dal = dal;

            foreach (Commande  commandes in dal.VoirCommandes())
            {
                lstCommandes.Items.Add(commandes);
            }

        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            PageCommandes frmCommandes = new PageCommandes(dal);
            this.NavigationService.Navigate(frmCommandes);
        }

        private void lstCommandes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstCommandes.SelectedIndex != -1)
            {
                Commande commandes = (Commande)lstCommandes.SelectedItem;

                lstRepas.Items.Clear();

                lblId.Content = "Id: " + commandes.Id.ToString();
                lblDate.Content = "Date: " + commandes.Creation.ToString("dd'/'MM'/'yyyy HH':'mm");

                Decimal total = 0;
                foreach  (Recette recette in commandes.recettes)
                {
                    total += recette.Prix;
                    lstRepas.Items.Add(recette);
                }

                lblTotal.Content = "Total: " + total.ToString("0.00") + " $";
            }
        }
    }
}
