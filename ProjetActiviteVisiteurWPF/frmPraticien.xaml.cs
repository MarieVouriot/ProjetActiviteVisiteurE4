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
        public frmPraticien(activite_visiteursEntities unGst)
        {
            InitializeComponent();
            gst = unGst;
        }
    }
}
