using KVwWPF.Commands;
using KVwWPF.Views;
using KVwWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KVwWPF.ViewModels
{
    class ZugangsViewModel: BaseViewModel
    {
        public ICommand KundeCmd { get; set; }
        public ICommand MitarbeiterCmd { get; set; }
        public ZugangsViewModel()
        {
            KundeCmd = new RelayCommand(KundeFenster);
            MitarbeiterCmd = new RelayCommand(MaFenster);
        }
        private void MaFenster()
        {
            MaAnmeldungWindow maWindow = new MaAnmeldungWindow();
            // Öffnen des Fensters
            maWindow.ShowDialog();
        }
        private void KundeFenster ()
        {
            KundenAnmeldungWindow kundeWindow = new KundenAnmeldungWindow();
            kundeWindow.ShowDialog();
        }
       
    }
}
