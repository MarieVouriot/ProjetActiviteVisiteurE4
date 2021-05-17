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
            // Remplissage des ListView et comboBox
            lvRapports.ItemsSource = gst.rapport_visite.ToList().FindAll(rap => rap.VIS_MATRICULE == leVisiteur.VIS_MATRICULE);
            lvActivites.ItemsSource = gst.realiser.ToList().FindAll(rea => rea.VIS_MATRICULE == leVisiteur.VIS_MATRICULE);
            cboPraticienRapport.ItemsSource = gst.praticien.ToList();
            cboPraticienActivite.ItemsSource = gst.praticien.ToList();

            // Calcul du total des frais 
            double total = 0;
            List<realiser> lesVisitesRealisees = gst.realiser.ToList().FindAll(rea => rea.VIS_MATRICULE == leVisiteur.VIS_MATRICULE);            
            foreach(realiser r in lesVisitesRealisees)
            {
                total += r.REA_MTTFRAIS;
            }
            txtTotal.Text = total.ToString();
        }

        private void btnCréer_Click(object sender, RoutedEventArgs e)
        {
            // Vérification que les données soient bien entrées dans les comboBox et textBox
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
                            // Création d'un rapport
                            rapport_visite unRapport = new rapport_visite()
                            {
                                RAP_NUM = gst.rapport_visite.Max(rap => rap.RAP_NUM) + 1,
                                RAP_DATE = dpDateRapport.SelectedDate.Value,
                                RAP_MOTIF = txtMotif.Text,
                                RAP_BILAN = txtBilan.Text,
                                praticien = cboPraticienRapport.SelectedItem as praticien,
                                visiteur = leVisiteur
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
                // Suppression du rapport sélectionné
                rapport_visite leRapport = lvRapports.SelectedItem as rapport_visite;
                gst.rapport_visite.Remove(leRapport);
                gst.SaveChanges();
                lvRapports.ItemsSource = null;
                lvRapports.ItemsSource = gst.rapport_visite.ToList().FindAll(rap => rap.VIS_MATRICULE == leVisiteur.VIS_MATRICULE);
            }
        }

        private void btninviter_Click(object sender, RoutedEventArgs e)
        {
            if (lvActivites.SelectedItem == null)
            {
                MessageBox.Show("Veuillez séléctionner une activité", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if(cboPraticienActivite.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez séléctionner un praticien", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    // Vérification que le praticien n'est pas déjà invité à l'activité sélectionnée
                    List<inviter> invationExiste = gst.inviter.ToList().FindAll(inv => inv.AC_NUM == (lvActivites.SelectedItem as realiser).AC_NUM && (cboPraticienActivite.SelectedItem as praticien).PRA_NUM == inv.PRA_NUM);
                    if(invationExiste.Count != 0)
                    {
                        MessageBox.Show("Déjà invité", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        // invitation créée
                        inviter uneInvitation = new inviter()
                        {
                            AC_NUM = (lvActivites.SelectedItem as realiser).AC_NUM,
                            praticien = cboPraticienActivite.SelectedItem as praticien,
                            INVITATION = false,
                            SPECIALISTEON = false
                        };
                        gst.inviter.Add(uneInvitation);
                        gst.SaveChanges();
                        MessageBox.Show("Invitation envoyée", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                }
            }
        }
    }
}
