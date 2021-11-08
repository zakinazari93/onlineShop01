using KVwWPF.ViewModels;
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
    /// Interaction logic for MaAnmeldungWindow.xaml
    /// </summary>
    public partial class MaAnmeldungWindow : Window
    {
        private MaAnmeldungViewModel maAnmelungvm;
        public string Nachname { get; set; }
        public MaAnmeldungWindow()
        {
            InitializeComponent();
            maAnmelungvm = new MaAnmeldungViewModel(this);
            this.DataContext = maAnmelungvm;
        }

    }
}
