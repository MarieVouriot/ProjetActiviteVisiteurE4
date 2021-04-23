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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetActiviteVisiteurWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        activite_visiteursEntities gst;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new activite_visiteursEntities();
        }

        private void btnConnexion_Click(object sender, RoutedEventArgs e)
        {
            if(txtNom.Text == "")
            {
                txtMessageErreur.Text = "Veuillez saisir votre nom";
            }
            else
            {
                if(txtPrenom.Text == "")
                {
                    txtMessageErreur.Text = "Veuillez saisir votre prénom";
                }
                else
                {
                    visiteur unVisiteur = gst.visiteur.ToList().Find(vis => vis.VIS_NOM == txtNom.Text && vis.VIS_PRENOM == txtPrenom.Text);
                    praticien unPraticien = gst.praticien.ToList().Find(pra => pra.PRA_NOM == txtNom.Text && pra.PRA_PRENOM == txtPrenom.Text);                    
                    
                    if(unVisiteur == null && unPraticien == null) // véréfication des identifiants
                    {
                        txtMessageErreur.Text = "Vos identifiants sont incorrects";                        
                    }
                    else
                    {
                        if (txtNom.Text == "admin" && txtPrenom.Text == "1234") // fenêtre admin
                        {
                            frmAdmin frm = new frmAdmin(gst);
                            frm.Show();
                        }
                        else
                        {
                            if(unVisiteur != null ){ //fenêtre visiteur
                                frmVisiteur frm = new frmVisiteur(gst, unVisiteur);
                                frm.Show();
                            }
                            else //fenêtre praticien
                            {
                                frmPraticien frm = new frmPraticien(gst);
                                frm.Show();
                            }
                        }
                    
                    }
                }
            }
        }
    }
}
