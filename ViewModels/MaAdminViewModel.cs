using KVwWPF.Commands;
using KVwWPF.Models;
using KVwWPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KVwWPF.ViewModels
{
    class MaAdminViewModel:BaseViewModel
    {
        //Properties die wir selfer definieren
        private int m_kundeId; //1- Kunde
        public int KundeKey
        {
            get { return m_kundeId; }
            set
            {
                m_kundeId = value;
                OnPropertyChanged("KundeKey");
            }
        }
        private int m_produktId; //2- Produkt
        public int ProduktKey
        {
            get { return m_produktId; }
            set
            {
                m_produktId = value;
                OnPropertyChanged("ProduktKey");
            }
        }
        private int m_RechnungId; //3- Rechnung
        public int RechnungKey
        {
            get { return m_RechnungId; }
            set
            {
                m_RechnungId = value;
                OnPropertyChanged("RechnungKey");
            }
        }
        private int m_MitarbeiterId; //4- Mitarbeiter
        public int MitarbeiterKey
        {
            get { return m_MitarbeiterId; }
            set
            {
                m_MitarbeiterId = value;
                OnPropertyChanged("MitarbeiterKey");
            }
        }
        private int m_RegalId; //5- Regal
        public int RegalKey
        {
            get { return m_RegalId; }
            set
            {
                m_RegalId = value;
                OnPropertyChanged("RegalKey");
            }
        }
        private int m_KategorieId; //6- Kategorie
        public int KategorieKey
        {
            get { return m_KategorieId; }
            set
            {
                m_KategorieId = value;
                OnPropertyChanged("KategorieKey");
            }
        }

        // Anlegen mit LIste vom DB
        public ObservableCollection<Kunde> KundeTabelle { get; set; }  //01- Kunde
        public ObservableCollection<Produkt> ProduktTabelle { get; set; }   // 2- Produkt
        public ObservableCollection<Rechnung> RechnungTabelle { get; set; } // 3- Rechnung
        public ObservableCollection<Mitarbeiter> MitarbeiterTabelle { get; set; } // 4- Mitarbeiter
        public ObservableCollection<Regal> RegalTabelle { get; set; } // 5- Regal
        public ObservableCollection<Kategorie> KategorieTabelle { get; set; }  // 6- Kategorie

        // Commands der Tabellen alle 6 Datenbank
        public ICommand EditKunCmd { get; set; }   // Kunde
        public ICommand EditProdCmd { get; set; }   // Produkt
        public ICommand EditRechCmd { get; set; }   // Rechnung
        public ICommand EditMaCmd { get; set; }     // Mitarbeiter
        public ICommand EditRegalCmd { get; set; }   // Regal
        public ICommand EditKatCmd { get; set; }     // Kategorie

        // Attribute
        private MaAdminWindow m_adminWindow;

        // Konstruktor
        public MaAdminViewModel(MaAdminWindow window)
        {
            
            m_adminWindow = window;
            // Initialisierung der ObservableCollection aller 6 Tabellen der DB
            KundeTabelle = new ObservableCollection<Kunde>();
            ProduktTabelle = new ObservableCollection<Produkt>();
            RechnungTabelle = new ObservableCollection<Rechnung>();
            MitarbeiterTabelle = new ObservableCollection<Mitarbeiter>();
            KategorieTabelle = new ObservableCollection<Kategorie>();
            RegalTabelle = new ObservableCollection<Regal>();
            // Commands initialisieren
            EditKunCmd = new RelayCommand(BearbeiteKunde);
            EditProdCmd = new RelayCommand(BearbeiteProdukt);
            EditRechCmd = new RelayCommand(BearbeiteRechnung);
            EditMaCmd = new RelayCommand(BearbeiteMitarbeiter);
            EditRegalCmd = new RelayCommand(BearbeiteRegal);
            EditKatCmd = new RelayCommand(BearbeiteKategorie);
            using (KVwProDBContext context = new KVwProDBContext())  // Füllen von Daten alle Tabellen
            {
                var allekunde = context.Kunde; // 1- Kunde
                foreach (Kunde item in allekunde)
                {
                    KundeTabelle.Add(item); 
                }
                var alleprodukte = context.Produkt;    // 2- Produkte
                foreach (Produkt item in alleprodukte)
                {
                    ProduktTabelle.Add(item);
                }
                var alleRechnung = context.Rechnung;   // 3- Rechnung
                foreach (Rechnung item  in alleRechnung)
                {
                    RechnungTabelle.Add(item);
                }
                var alleMitarbeiter = context.Mitarbeiter;    // 4- Mitarbeiter
                foreach (Mitarbeiter item in alleMitarbeiter)
                {
                    MitarbeiterTabelle.Add(item);
                }
                var alleRegal = context.Regal;     // 5- Regal
                foreach (Regal item in alleRegal)
                {
                    RegalTabelle.Add(item);
                }
                var alleKategorie = context.Kategorie;   // 6- Kategorie
                foreach (Kategorie item in alleKategorie)
                {
                    KategorieTabelle.Add(item);
                }
            }
          
        }
        // Initialisierung der Window pro Tabelle der DB, die durch Buttons geöffnet werden
        private void BearbeiteKunde ()
        {
            EditKundeWindow kundeWindow = new EditKundeWindow();
            kundeWindow.ShowDialog();
        }
        private void BearbeiteProdukt()
        {
            EditProdWindow produktwindow = new EditProdWindow();
            produktwindow.ShowDialog();
        }
        private void BearbeiteRechnung()
        {
            EditRechWindow rechwindow = new EditRechWindow();
            rechwindow.ShowDialog();
        }
        private void BearbeiteMitarbeiter()
        {
            EditMaWindow maWindow = new EditMaWindow();
            maWindow.ShowDialog();
        }
        private void BearbeiteRegal()
        {
            EditRegalWindow regalWindow = new EditRegalWindow();
            regalWindow.ShowDialog();
        }
        private void BearbeiteKategorie()
        {
            EditKategWindow kategWindow = new EditKategWindow();
            kategWindow.ShowDialog();
        }
    }
}
