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
using TP214E.Pages;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour Inventaire.xaml
    /// </summary>
    public partial class PageInventaire : Page
    {
       
        private IDAL dal;

        public PageInventaire(IDAL dal)
        {
            InitializeComponent();

            this.dal = dal;
            List<Aliment> aliments = dal.VoirAliments();

            foreach (var aliment in aliments)
            {
                lstAliments.Items.Add(aliment);
            }
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            PageAjouterAliment frmAjouterAliment = new PageAjouterAliment(dal);
            this.NavigationService.Navigate(frmAjouterAliment);
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (lstAliments.SelectedIndex != -1)
            {
                Aliment aliment = (Aliment)lstAliments.SelectedItem;

                if (MessageBox.Show("Êtes-vous sûr de vouloir suprimmer l'aliment : " + aliment.Nom, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    dal.SupprimerAliment(aliment);
                    lstAliments.Items.Remove(lstAliments.SelectedItem);
                }
            }

        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            PageAccueil frmAccueil = new PageAccueil();
            this.NavigationService.Navigate(frmAccueil);
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (lstAliments.SelectedIndex != -1)
            {
                PageModifierAliment frmModifierAliment = new PageModifierAliment(dal, (Aliment)lstAliments.SelectedItem);
                this.NavigationService.Navigate(frmModifierAliment);
            }
        }
    }
}
