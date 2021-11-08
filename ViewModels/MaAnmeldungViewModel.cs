using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KVwWPF.Commands;
using System.Windows.Input;
using KVwWPF.Views;
using KVwWPF.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace KVwWPF.ViewModels
{
    class MaAnmeldungViewModel: BaseViewModel
    {
        // Properties
        public string Nachname { get; set; }
        public string Passwort { get; set; }

        // Attribute
        private MaAnmeldungWindow window;

        // Commands
        public ICommand Login { get; set; }
        public MaAnmeldungViewModel(MaAnmeldungWindow mALogin)
        {
            // Command
            Login = new RelayCommand(checkMaLogin);
            // Daten initialisieren
            window = mALogin;
        }
        private void checkMaLogin()
        {
            using (KVwProDBContext context = new KVwProDBContext())  // Zugriff auf DB
            {
                // Vergleich der Zugangsdaten von DB und Properties
                var maZugang = context.Mitarbeiter.Where(p => p.MaNachname == Nachname && p.MaPasswort == Passwort).FirstOrDefault();
                if (maZugang != null)
                {
                    HauptMaWindow();
                }

                if (maZugang == null)
                {
                    MessageBox.Show("Ihr Nachname oder Passwort ist falsche. Bitte noch einmal probieren", "Falsche Eingabe", MessageBoxButton.OK);
                    return;
                }
            }

           
             window.Nachname = Nachname;
             window.Close(); 
        }
        private void HauptMaWindow()
        {
            MaAdminWindow maAdminWindow = new MaAdminWindow();
            // Öffnen des Fensters
            maAdminWindow.ShowDialog();
        }
    }
}
