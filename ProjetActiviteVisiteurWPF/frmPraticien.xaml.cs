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
    /// Logique d'interaction pour frmPraticien.xaml
    /// </summary>
    public partial class frmPraticien : Window
    {
        activite_visiteursEntities gst;
        praticien lePraticien;
        public frmPraticien(activite_visiteursEntities unGst, praticien unPraticien)
        {
            InitializeComponent();
            gst = unGst;
            lePraticien = unPraticien;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Affichage des ListView en fonction du praticien connecté
            lvRapports.ItemsSource = gst.rapport_visite.ToList();
            lvInvitations.ItemsSource = gst.inviter.ToList().FindAll(inv => inv.PRA_NUM == lePraticien.PRA_NUM && inv.INVITATION == true);
        }
    }
}
