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
    /// Logique d'interaction pour PageModifierAliment.xaml
    /// </summary>
    public partial class PageModifierAliment : Page
    {

        IDAL dal;
        Aliment aliment;
        public PageModifierAliment(IDAL dal,Aliment pAliment)
        {
            InitializeComponent();

            this.dal = dal;
            this.aliment = pAliment;

            this.txtNom.Text = pAliment.Nom;
            this.txtQuantite.Text = pAliment.Quantite.ToString();

            if(pAliment.Unite != null) 
            {
                this.cboUnite.SelectedValue = pAliment.Unite;
            }

            if (pAliment.ExpireLe != DateTime.MinValue)
            {
                this.txtDate.Text = pAliment.ExpireLe.ToString("yyyy/MM/dd");
            }
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            PageInventaire frmInventaire = new PageInventaire(dal);
            this.NavigationService.Navigate(frmInventaire);
        }

        private void btnConfirmer_Click(object sender, RoutedEventArgs e)
        {
            if (this.txtNom.Text == "" || this.txtQuantite.Text == "")
            {
                MessageBox.Show("Le champ nom et le champ quantité sont obligatoires", "Erreur formulaire",
                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            aliment.Nom = this.txtNom.Text;

            try
            {
                aliment.Quantite = Convert.ToInt32(this.txtQuantite.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Le champ quantité doit être un nombre entier", "Erreur formulaire",
                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (this.cboUnite.Text != "Aucune unité" && this.cboUnite.Text != "")
            {
                aliment.Unite = cboUnite.Text;
            }

            if (this.txtDate.Text != "")
            {
                try
                {
                    aliment.ExpireLe = Convert.ToDateTime(this.txtDate.Text);
                }
                catch (Exception)
                {

                    MessageBox.Show("Le champ date doit respecter le format", "Erreur formulaire",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            dal.ModifierAliment(aliment);

            PageInventaire frmInventaire = new PageInventaire(dal);
            this.NavigationService.Navigate(frmInventaire);
        }
    }
}
