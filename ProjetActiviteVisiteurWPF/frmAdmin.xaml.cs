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
    /// Logique d'interaction pour frmAdmin.xaml
    /// </summary>
    public partial class frmAdmin : Window
    {
        activite_visiteursEntities gst;
        public frmAdmin(activite_visiteursEntities unGst)
        {
            InitializeComponent();
            gst = unGst;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lvVisiteurs.ItemsSource = gst.visiteur.ToList();
            lvPraticiens.ItemsSource = gst.praticien.ToList();
        }

        private void lvVisiteurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvVisiteurs.SelectedItem != null)
            {
                lvRapports.ItemsSource = gst.rapport_visite.ToList().FindAll(rap => rap.VIS_MATRICULE == (lvVisiteurs.SelectedItem as visiteur).VIS_MATRICULE);
                lvActivites.ItemsSource = gst.realiser.ToList().FindAll(rea => rea.VIS_MATRICULE == (lvVisiteurs.SelectedItem as visiteur).VIS_MATRICULE);
            }
        }

        private void lvPraticiens_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvPraticiens.SelectedItem != null)
            {
                lvInvitations.ItemsSource = gst.inviter.ToList().FindAll(inv => inv.PRA_NUM == (lvPraticiens.SelectedItem as praticien).PRA_NUM);
            }
        }

        private void btnAccepter_Click(object sender, RoutedEventArgs e)
        {
            if(lvPraticiens.SelectedItem == null)
            {
                MessageBox.Show("Veuillez séléctionner un praticien", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                gst.SaveChanges();
            }
        }
    }
}
