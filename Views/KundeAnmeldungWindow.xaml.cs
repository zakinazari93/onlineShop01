﻿using KVwWPF.ViewModels;
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
    /// Interaction logic for KundenAnmeldung.xaml
    /// </summary>
    public partial class KundenAnmeldungWindow : Window
    {
        private KunAnmeldungViewModel kunAnmelungvm;
        public string Nachname { get; set; }
        public KundenAnmeldungWindow()
        {
            InitializeComponent();
            kunAnmelungvm = new KunAnmeldungViewModel(this);
            this.DataContext = kunAnmelungvm;
        }
    }
}
