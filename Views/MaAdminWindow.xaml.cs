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
    /// Interaction logic for MaAdminWindow.xaml
    /// </summary>
    public partial class MaAdminWindow : Window
    {
        private MaAdminViewModel maAdminvm;
        public MaAdminWindow()
        {
            InitializeComponent();
            maAdminvm = new MaAdminViewModel(this);
            this.DataContext = maAdminvm;
        }
    }
}
