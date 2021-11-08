using KVwWPF.Commands;
using KVwWPF.Models;
using KVwWPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KVwWPF.ViewModels
{
    class EditKundeViewModel: BaseViewModel
    {
        public ObservableCollection<Kunde> EditKunde { get; set; } // Anlegen der Liste mit Collection vom DB
        public Kunde EditSelektedKunde { get; set; }

        // Attribute
        private EditKundeWindow m_window;

        // Commands
        public ICommand SpeichernCmd { get; set; }
        public ICommand VerlassenCmd { get; set; }
        public ICommand DelCmd { get; set; }

        // Konstruktor
        public EditKundeViewModel(EditKundeWindow window)
        {
            // Commands
            SpeichernCmd = new RelayCommand(Speichern);
            VerlassenCmd = new RelayCommand(Verlassen);
            DelCmd = new RelayCommand(DelKunde);
            // Daten initialisieren
            m_window = window;
            // Initialisierung der ObservableCollection 
            EditKunde = new ObservableCollection<Kunde>();
            using (KVwProDBContext context= new KVwProDBContext()) // Füllen der Kunde-Tabelle Daten von DB
            {
                var callEditKunde = context.Kunde;
                foreach(var item in callEditKunde)
                {
                    EditKunde.Add(item);
                }
            }
        }
        private void Listefullen()
        {
            EditKunde.Clear(); // Löschen der Liste nach jede Änderung
            using (KVwProDBContext context= new KVwProDBContext()) // Zugriff auf DB
            {
                var fillKun = context.Kunde;
                foreach(Kunde item in fillKun)
                {
                    EditKunde.Add(item);
                }
            }
        }
        private void Speichern()
        {
            if(EditSelektedKunde==null)
            {
                // MessageBox
                MessageBox.Show("Es wurde nichts hinzugefügt!", "Fehler", MessageBoxButton.OK);
                Listefullen();
                return;
            }
            if(EditSelektedKunde.Kundenummer==0 ||EditSelektedKunde.KundeNachname==""|| EditSelektedKunde.Passwort=="")
            {
                // MessageBox
                MessageBox.Show("Unvollständige Daten wurden eingegeben!", "Fehler", MessageBoxButton.OK);
                Listefullen();
                return;
            }
            using (KVwProDBContext context= new KVwProDBContext())
            {
                Kunde client = context.Kunde.Where(p => p.KundePk == EditSelektedKunde.KundePk).FirstOrDefault();
                if(client!=null)
                {
                    // Die aktuelle Daten werden überarbeitet
                    client.KundePk = EditSelektedKunde.KundePk;
                    client.Kundenummer = EditSelektedKunde.Kundenummer;
                    client.KundeVorname = EditSelektedKunde.KundeVorname;
                    client.KundeNachname = EditSelektedKunde.KundeNachname;
                    client.KundeAdresse = EditSelektedKunde.KundeAdresse;
                    client.KundeEmail = EditSelektedKunde.KundeEmail;
                    client.KundeTelNr = EditSelektedKunde.KundeTelNr;
                    client.Passwort = EditSelektedKunde.Passwort;
                }
                else
                {
                    // Neue Eintragung in DB
                    client = new Kunde();
                    client.KundePk = EditSelektedKunde.KundePk;
                    client.Kundenummer = EditSelektedKunde.Kundenummer;
                    client.KundeVorname = EditSelektedKunde.KundeVorname;
                    client.KundeNachname = EditSelektedKunde.KundeNachname;
                    client.KundeAdresse = EditSelektedKunde.KundeAdresse;
                    client.KundeEmail = EditSelektedKunde.KundeEmail;
                    client.KundeTelNr = EditSelektedKunde.KundeTelNr;
                    client.Passwort = EditSelektedKunde.Passwort;
                    context.Kunde.Add(client); // Hinzufügen in DB
                }
                context.SaveChanges();  // Änderungen werden in DB gespeichert
            }
            Verlassen();
        }
        private void DelKunde()
        {
            MessageBoxResult result = MessageBox.Show("Wollen Sie wirklich die angegeben Daten löschen", "Löschen", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // Datensatz löschen
                using (KVwProDBContext context = new KVwProDBContext())
                {
                    Kunde delKun = context.Kunde.Where(p => p.KundePk == EditSelektedKunde.KundePk).FirstOrDefault();
                    // Registrieren
                    context.Kunde.Remove(delKun);
                    // Änderung in DB speichern
                    context.SaveChanges();
                }
            }   Listefullen();
        }
        private void Verlassen()
        {
            m_window.Close();
        }
    }
}
