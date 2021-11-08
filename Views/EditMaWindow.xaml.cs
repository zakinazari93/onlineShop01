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
    /// Interaction logic for EditMaWindow.xaml
    /// </summary>
    public partial class EditMaWindow : Window
    {
        private EditMaViewModel editMAvm;
        public EditMaWindow()
        {
            InitializeComponent();
            editMAvm = new EditMaViewModel(this);
            this.DataContext = editMAvm;
        }
    }
}
