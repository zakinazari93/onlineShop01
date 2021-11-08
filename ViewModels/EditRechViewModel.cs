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
    class EditRechViewModel : BaseViewModel
    {
        public ObservableCollection<Rechnung> EditRechList { get; set; } // Anlegen der Liste mit Collection vom DB
        public Rechnung SelektedEditRech { get; set; }

        // Attribute
        private EditRechWindow m_window;

        // Commands
        public ICommand SpeichernCmd { get; set; }
        public ICommand VerlassenCmd { get; set; }
        public ICommand DelCmd { get; set; }

        // Konstruktor
        public EditRechViewModel(EditRechWindow window)
        {
            // Commands
            SpeichernCmd = new RelayCommand(Speichern);
            VerlassenCmd = new RelayCommand(Verlassen);
            DelCmd = new RelayCommand(DelRech);
            // Daten initialisieren
            m_window = window;
            // Initialisierung der ObservableCollection 
            EditRechList = new ObservableCollection<Rechnung>();
            using (KVwProDBContext context = new KVwProDBContext())  // Füllen der Kategorie Daten von DB
            {
                var callRech = context.Rechnung;
                foreach(var item in callRech)
                {
                    EditRechList.Add(item);
                }
            }
        }
        private void Listefullen()
        {
            EditRechList.Clear();  // Löschen der Kat Liste nach jede Änderung
            using (KVwProDBContext context= new KVwProDBContext())  // Zugriff auf DB
            {
                var fillRech = context.Rechnung;
                foreach(Rechnung item in fillRech)
                {
                    EditRechList.Add(item);
                }
            }
        }
        private void Speichern()
        {
            if(SelektedEditRech==null)
            {
                // MessageBox
                MessageBox.Show("Es wurde nichts hinzugefügt!", "Fehler", MessageBoxButton.OK);
                Listefullen();
                return;
            }
            if(SelektedEditRech.RechNr==0|| SelektedEditRech.RechSum==0)
            {
                // MessageBox
                MessageBox.Show("Unvollständige Daten wurden eingegeben!", "Fehler", MessageBoxButton.OK);
                Listefullen();
                return;
            }
            using (KVwProDBContext context= new KVwProDBContext())
            {
                Rechnung rechCheck = context.Rechnung.Where(p => p.RechnungPk == SelektedEditRech.RechnungPk).FirstOrDefault();
                if(rechCheck!=null)
                {
                    // Änderung in den existierenden Tabellen
                    rechCheck.RechnungPk = SelektedEditRech.RechnungPk;
                    rechCheck.RechNr = SelektedEditRech.RechNr;
                    rechCheck.RechDat = SelektedEditRech.RechDat;
                    rechCheck.RechSum = SelektedEditRech.RechSum;
                }
                context.SaveChanges();
            }
            Verlassen();
        }
        private void DelRech()
        {
            MessageBoxResult result = MessageBox.Show("Wollen Sie wirklich die angegeben Daten löschen", "Löschen", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // Datensatz löschen
                using (KVwProDBContext context = new KVwProDBContext())
                {
                    Rechnung rechDel = context.Rechnung.Where(p => p.RechnungPk == SelektedEditRech.RechnungPk).FirstOrDefault();
                    // Registrierung
                    context.Rechnung.Remove(rechDel);
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
