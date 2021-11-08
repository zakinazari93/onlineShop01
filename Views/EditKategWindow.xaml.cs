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
    /// Interaction logic for EditKategWindow.xaml
    /// </summary>
    public partial class EditKategWindow : Window
    {
        private EditKategViewModel editkategvm;
        public EditKategWindow()
        {
            InitializeComponent();
            editkategvm = new EditKategViewModel(this);
            this.DataContext = editkategvm;
        }
    }
}
