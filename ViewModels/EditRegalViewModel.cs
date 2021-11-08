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
    class EditRegalViewModel : BaseViewModel
    {
        public ObservableCollection<Regal> EditRegalList { get; set; }  // Anlegen der Liste mit Collection vom DB
        public Regal SelektedEditRegal { get; set; }

        // Attribute
        private EditRegalWindow m_window;

        // Commands
        public ICommand SpeichernCmd { get; set; }
        public ICommand VerlassenCmd { get; set; }
        public ICommand DelCmd { get; set; }

        // Konstruktor
        public EditRegalViewModel (EditRegalWindow window)
        {
            // Commands
            SpeichernCmd = new RelayCommand(Speichern);
            VerlassenCmd = new RelayCommand(Verlassen);
            DelCmd = new RelayCommand(DelRegal);
            // Daten initialisieren
            m_window = window;
            // Initialisierung der ObservableCollection 
            EditRegalList = new ObservableCollection<Regal>();
            using (KVwProDBContext context= new KVwProDBContext()) // Füllen der Kategorie Daten von DB
            {
                var callRegal = context.Regal;
                foreach(var item in callRegal)
                {
                    EditRegalList.Add(item);
                }
            }
        }
        private void Listefullen()
        {
            EditRegalList.Clear(); // Löschen der Kat Liste nach jede Änderung
            using (KVwProDBContext context= new KVwProDBContext())  // Zugriff auf DB
            {
                var fillRegal = context.Regal;
                foreach(Regal item in fillRegal)
                {
                    EditRegalList.Add(item);
                }
            }
        }
        private void Speichern ()
        {
            if(SelektedEditRegal==null)
            {
                // MessageBox
                MessageBox.Show("Es wurde nichts hinzugefügt!", "Fehler", MessageBoxButton.OK);
                Listefullen();
                return;
            }
            if(SelektedEditRegal.RegalName==null || SelektedEditRegal.RegalName==""|| SelektedEditRegal.RegalMaxAnz==0)
            {
                // MessageBox
                MessageBox.Show("Unvollständige Daten wurden eingegeben!", "Fehler", MessageBoxButton.OK);
                Listefullen();
                return;
            }
            using (KVwProDBContext context= new KVwProDBContext())
            {
                Regal regal = context.Regal.Where(r => r.RegalPk == SelektedEditRegal.RegalPk).FirstOrDefault();
                if(regal!=null)
                {
                    // Die aktuelle Daten werden überarbeitet
                    regal.RegalPk = SelektedEditRegal.RegalPk;
                    regal.RegalName = SelektedEditRegal.RegalName;
                    regal.RegalOrt = SelektedEditRegal.RegalOrt;
                    regal.RegalMaxAnz = SelektedEditRegal.RegalMaxAnz;
                }
                else
                {
                    // Hinzufügen neue Daten
                    regal = new Regal();
                    regal.RegalPk = SelektedEditRegal.RegalPk;
                    regal.RegalName = SelektedEditRegal.RegalName;
                    regal.RegalOrt = SelektedEditRegal.RegalOrt;
                    regal.RegalMaxAnz = SelektedEditRegal.RegalMaxAnz;
                    context.Regal.Add(regal);
                }
                context.SaveChanges(); // Änderungen werden in DB gespeichert
            }
            Verlassen();
        }
        private void DelRegal()
        {
            MessageBoxResult result = MessageBox.Show("Wollen Sie wirklich die angegeben Daten löschen", "Löschen", MessageBoxButton.YesNo);
            if(result==MessageBoxResult.Yes)
            {
                // Datensatz löschen
                using(KVwProDBContext context= new KVwProDBContext())
                {
                    Regal reg = context.Regal.Where(a => a.RegalPk == SelektedEditRegal.RegalPk).FirstOrDefault();
                    // Registrierung
                    context.Regal.Remove(reg);
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
