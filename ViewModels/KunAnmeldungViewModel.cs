using KVwWPF.Commands;
using KVwWPF.Models;
using KVwWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace KVwWPF.ViewModels
{
    class KunAnmeldungViewModel: BaseViewModel
    {
        // Properties
        public string Nachname { get; set; }
        public string Passwort { get; set; }

        // Attribute
        private KundenAnmeldungWindow window;
        // Commands
        public ICommand Login { get; set; }

        // Konstruktor
        public KunAnmeldungViewModel(KundenAnmeldungWindow kunLogin)
        {
            // Command
            Login = new RelayCommand(checkKundeLogin);
            // Daten initialisieren
            window = kunLogin;
        }
        private void checkKundeLogin()
        {
            using (KVwProDBContext context = new KVwProDBContext()) // Abruf der Daten von DB
            {
                // Vergleich der Daten von DB und Property 
                var kunZugang = context.Kunde.Where(p => p.KundeNachname == Nachname && p.Passwort == Passwort).FirstOrDefault();
                if (kunZugang != null)
                {
                    KundeAuswahlWindow(kunZugang.KundePk);
                }

                if (kunZugang == null)
                {
                    MessageBox.Show("Ihr Nachname oder Passwort ist falsche. Bitte noch einmal probieren", "Falsche Eingabe", MessageBoxButton.OK);
                    return;
                }
            }

            window.Nachname = Nachname;
            window.Close();
        }
        private void KundeAuswahlWindow(int KundePK)  // Initialisierung von neuen Fenster
        {
            ProduktWahlWindow kundeWahl = new ProduktWahlWindow(KundePK);
            // Öffnen des Fensters
            kundeWahl.ShowDialog();
        }
    }
}
