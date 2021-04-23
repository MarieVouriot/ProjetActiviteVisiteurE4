using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjetActiviteVisiteurWPF
{
    /// <summary>
    /// Logique d'interaction pour frmVisiteur.xaml
    /// </summary>
    public partial class frmVisiteur : Window
    {
        activite_visiteursEntities gst;
        visiteur leVisiteur;
        public frmVisiteur(activite_visiteursEntities unGst, visiteur unVisiteur)
        {
            InitializeComponent();
            gst = unGst;
            leVisiteur = unVisiteur;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lvRapports.ItemsSource = gst.rapport_visite.ToList().FindAll(rap => rap.VIS_MATRICULE == leVisiteur.VIS_MATRICULE);
            lvActivites.ItemsSource = gst.realiser.ToList().FindAll(rea => rea.VIS_MATRICULE == leVisiteur.VIS_MATRICULE);
            cboPraticienRapport.ItemsSource = gst.praticien.ToList();
            cboPraticienActivite.ItemsSource = gst.praticien.ToList();
        }

        private void btnCréer_Click(object sender, RoutedEventArgs e)
        {
            if(cboPraticienRapport.SelectedItem == null)
            {
                MessageBox.Show("Veuillez séléctionner un praticien", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if(txtMotif.Text == null)
                {
                    MessageBox.Show("Veuillez saisir un motif", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if(txtBilan.Text == null)
                    {
                        MessageBox.Show("Veuillez saisir un bilan", "Erreur de saise", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        if(dpDateRapport.SelectedDate == null)
                        {
                            MessageBox.Show("Veuillez séléctionner une date", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
                        }else
                        {
                            rapport_visite unRapport = new rapport_visite()
                            {
                                RAP_NUM = gst.rapport_visite.Max(rap => rap.RAP_NUM),
                                RAP_DATE = dpDateRapport.SelectedDate.Value,
                                RAP_MOTIF = txtMotif.Text,
                                RAP_BILAN = txtBilan.Text,
                                PRA_NUM = (cboPraticienRapport.SelectedItem as praticien).PRA_NUM,
                                VIS_MATRICULE = leVisiteur.VIS_MATRICULE
                            };
                            gst.rapport_visite.Add(unRapport);
                            gst.SaveChanges();
                            lvRapports.ItemsSource = null;
                            lvRapports.ItemsSource = gst.rapport_visite.ToList().FindAll(rap => rap.VIS_MATRICULE == leVisiteur.VIS_MATRICULE);
                        }
                    }
                }
            }
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (lvRapports.SelectedItem == null)
            {
                MessageBox.Show("Veuillez séléctionner un rapport", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

            }
        }

    }
}
