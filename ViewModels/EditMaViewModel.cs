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
    class EditMaViewModel: BaseViewModel
    {
        public ObservableCollection<Mitarbeiter> EditMaListe { get; set; } // Anlegen der Liste mit Collection vom DB
        public Mitarbeiter SelektedMaEdit { get; set; }
        // Attribute
        private EditMaWindow m_window;
        // Commands
        public ICommand SpeichernCmd { get; set; }
        public ICommand VerlassenCmd { get; set; }
        public ICommand DelCmd { get; set; }

        // Konstruktor
        public EditMaViewModel(EditMaWindow window)
        {
            // Commands
            SpeichernCmd = new RelayCommand(Speichern);
            VerlassenCmd = new RelayCommand(Verlassen);
            DelCmd = new RelayCommand(DelMitarbeiter);
            // Daten initialisieren
            m_window = window;
            EditMaListe = new ObservableCollection<Mitarbeiter>();
           using (KVwProDBContext context = new KVwProDBContext()) // Füllen der Kategorie Daten von DB
            {
                var callMa = context.Mitarbeiter;
                foreach (var item in callMa)
                {
                    EditMaListe.Add(item);
                }
            }
        }
        private void Listefullen()
        {
            EditMaListe.Clear(); // Löschen der Kat Liste nach jede Änderung
            using (KVwProDBContext context= new KVwProDBContext())  // Zugriff auf DB
            {
                var fillMa = context.Mitarbeiter;
                foreach(Mitarbeiter item in fillMa)
                {
                    EditMaListe.Add(item);
                }
            }
        }
        private void Speichern ()
        {
            if(SelektedMaEdit== null)
            {
                // MessageBox
                MessageBox.Show("Es wurde nichts hinzugefügt!", "Fehler", MessageBoxButton.OK);
                Listefullen();
                return;
            }
            if(SelektedMaEdit.MaNachname==null|| SelektedMaEdit.MaNachname=="")
            {
                // MessageBox
                MessageBox.Show("Unvollständige Daten wurden eingegeben!", "Fehler", MessageBoxButton.OK);
                Listefullen();
                return;
            }
            using (KVwProDBContext context= new KVwProDBContext())
            {
                Mitarbeiter ma = context.Mitarbeiter.Where(p => p.MaPk == SelektedMaEdit.MaPk).FirstOrDefault();
                if(ma!=null)
                {
                    // Die aktuelle Daten werden überarbeitet
                    ma.MaPk = SelektedMaEdit.MaPk;
                    ma.MaVorname = SelektedMaEdit.MaVorname;
                    ma.MaNachname = SelektedMaEdit.MaNachname;
                    ma.MaPasswort = SelektedMaEdit.MaPasswort;
                }
                else
                {
                    // Neue Eintragung in DB
                    ma = new Mitarbeiter();
                    ma.MaPk = SelektedMaEdit.MaPk;
                    ma.MaVorname = SelektedMaEdit.MaVorname;
                    ma.MaNachname = SelektedMaEdit.MaNachname;
                    ma.MaPasswort = SelektedMaEdit.MaPasswort;
                    context.Mitarbeiter.Add(ma); // Hinzufügen in DB
                }
                context.SaveChanges(); // Änderungen werden in DB gespeichert
            }
            Verlassen();
        }
        private void DelMitarbeiter()
        {
            MessageBoxResult result = MessageBox.Show("Wollen Sie wirklich die angegeben Daten löschen", "Löschen", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // Datensatz löschen
                using (KVwProDBContext context = new KVwProDBContext())
                {
                    Mitarbeiter delMa = context.Mitarbeiter.Where(a => a.MaPk == SelektedMaEdit.MaPk).FirstOrDefault();
                    // Registrierung
                    context.Mitarbeiter.Remove(delMa);
                    // Änderung in DB speichern
                    context.SaveChanges();
                }
                Listefullen();
            }
        }
        private void Verlassen()
        {
            m_window.Close();
        }
    }
}
