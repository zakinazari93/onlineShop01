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
    class EditKategViewModel: BaseViewModel
    {
        public ObservableCollection<Kategorie> EditKat { get; set; } // Anlegen der Liste mit Collection vom DB
        public Kategorie SelektedKat { get; set; }
        // Attribute
        private EditKategWindow m_window;
        // Commands
        public ICommand SpeichernCmd { get; set; }
        public ICommand VerlassenCmd { get; set; }
        public ICommand DelCmd { get; set; }

        // Konstruktor
        public EditKategViewModel(EditKategWindow window)
        {
            // Commands
            SpeichernCmd = new RelayCommand(Speichern);
            VerlassenCmd = new RelayCommand(Verlassen);
            DelCmd = new RelayCommand(DelKategorie);
            // Daten initialisieren
            m_window = window;
            // Initialisierung der ObservableCollection 
            EditKat = new ObservableCollection<Kategorie>();
            using (KVwProDBContext context= new KVwProDBContext())  // Füllen der Kategorie Daten von DB
            {
                var callKat = context.Kategorie;
                foreach(var item in callKat)
                {
                    EditKat.Add(item);
                }
            }
        }
        private void Listefullen()
        {
            EditKat.Clear(); // Löschen der Kat Liste nach jede Änderung
            using (KVwProDBContext context= new KVwProDBContext())  // Zugriff auf DB
            {
                var fillKat = context.Kategorie;
                foreach(Kategorie item in fillKat)
                {
                    EditKat.Add(item);
                }
            }
        }
        private void Speichern()
        {
            if(SelektedKat== null)
            {
                // MessageBox
                MessageBox.Show("Es wurde nichts hinzugefügt!", "Fehler", MessageBoxButton.OK);
                Listefullen();
                return;
            }
            if(SelektedKat.KategorieName==null|| SelektedKat.KategorieName=="")
            {
                // MessageBox
                MessageBox.Show("Unvollständige Daten wurden eingegeben!", "Fehler", MessageBoxButton.OK);
                Listefullen();
                return;
            }
            using(KVwProDBContext context= new KVwProDBContext())
            {
                Kategorie kat = context.Kategorie.Where(p => p.KategoriePk == SelektedKat.KategoriePk).FirstOrDefault();
                if(kat!=null)
                {
                    // Änderung in den existierenden Tabellen
                    kat.KategoriePk = SelektedKat.KategoriePk;
                    kat.KategorieName = SelektedKat.KategorieName;
                }
                else
                {
                    // Hinzufügen neue Kategorien
                    kat = new Kategorie();
                    kat.KategoriePk = SelektedKat.KategoriePk;
                    kat.KategorieName = SelektedKat.KategorieName;
                    context.Kategorie.Add(kat); // Hinzufügen in DB
                }
                context.SaveChanges(); // Änderungen werden in DB gespeichert
            }
            Verlassen();
        }
        private void DelKategorie()
        {
            MessageBoxResult result = MessageBox.Show("Wollen Sie wirklich die angegeben Daten löschen", "Löschen", MessageBoxButton.YesNo);
            if(result==MessageBoxResult.Yes)
            {
                // Datensatz löschen
                using (KVwProDBContext context= new KVwProDBContext())
                {
                    Kategorie delKat = context.Kategorie.Where(p => p.KategoriePk == SelektedKat.KategoriePk).FirstOrDefault();
                    // Registrierung
                    context.Kategorie.Remove(delKat);
                    // Änderung in DB Speichern
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
