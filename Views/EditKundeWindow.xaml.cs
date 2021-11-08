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
    /// Interaction logic for EditKundeWindow.xaml
    /// </summary>
    public partial class EditKundeWindow : Window
    {
        private EditKundeViewModel editkundevm;
        public EditKundeWindow()
        {
            InitializeComponent();
            editkundevm = new EditKundeViewModel(this);
            this.DataContext = editkundevm;
        }
    }
}
