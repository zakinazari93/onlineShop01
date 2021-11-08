using KVwWPF.ViewModels;
using KVwWPF.Models;
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

namespace KVwWPF.Views
{
    /// <summary>
    /// Interaction logic for ProduktWahlWindow.xaml
    /// </summary>
    public partial class ProduktWahlWindow : Window
    {
        private ProdWahlViewModel prodwahlvm;
        public ProduktWahlWindow(int KundePK)
        {
            InitializeComponent();
            prodwahlvm = new ProdWahlViewModel(this, KundePK);
            this.DataContext = prodwahlvm;
        }
    }
}
