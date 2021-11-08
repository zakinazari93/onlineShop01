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
    class ProduktExt
    {
        public int ProduktPk { get; set; }
        public string ProduktName { get; set; }
        public double Preis { get; set; }
        public int ProduktMenge { get; set; }
        public string RegalText { get; set; }
        public string KategorieText { get; set; }
    }
    class EditProdViewModel:BaseViewModel
    {
        // Properties 
        public ObservableCollection<ProduktExt> ProdEditListe { get; set; } // Anlegen der Liste mit Collection vom DB
        public ObservableCollection<Regal> ProdEditRegalFK { get; set; }  // Für Dropdown 1
        public ObservableCollection<Kategorie> ProdEditKatFK { get; set; }  // Für Dropdown 2
        public ProduktExt SelektedProdEditListe { get; set; }

        // Attribute
        private EditProdWindow m_window;
        private int m_prodRegalFK;
        public int EditProdRegalFK
        {
            get { return m_prodRegalFK; }
            set
            {
                m_prodRegalFK = value;
                OnPropertyChanged("EditProdRegalFK");
            }
        }
        private int m_prodKatFK;
        public int EditProdKatFK
        {
            get { return m_prodKatFK; }
            set
            {
                m_prodKatFK = value;
                OnPropertyChanged("EditProdKatFK");
            }
        }

        // Command
        public ICommand SpeichernCmd { get; set; }
        public ICommand VerlassenCmd { get; set; }
        public ICommand DelCmd { get; set; }

        // Konstruktor
        public EditProdViewModel(EditProdWindow window)
        {
            // Commands
            SpeichernCmd = new RelayCommand(Speichern);
            VerlassenCmd = new RelayCommand(Verlassen);
            DelCmd = new RelayCommand(DelProdukt);
            // Daten initialisieren
            m_window = window;
            ProdEditListe = new ObservableCollection<ProduktExt>();
            ProdEditRegalFK = new ObservableCollection<Regal>(); // Für Dropdown 1
            ProdEditKatFK = new ObservableCollection<Kategorie>(); // Für Dropdown 2
            // Inhalt der Tabelle Produkt von DB abrufen
            using (KVwProDBContext context= new KVwProDBContext())
            {
                var callFK1 = context.Regal;
                foreach (var regal in callFK1)
                {
                    ProdEditRegalFK.Add(regal);
                }

                var callFK2 = context.Kategorie;
                foreach (var kat in callFK2)
                {
                    ProdEditKatFK.Add(kat);
                }
                var callProduct = context.Produkt;
                foreach(var item in callProduct)
                {
                    ProduktExt produkt = new ProduktExt();
                    produkt.ProduktPk = item.ProduktPk;
                    produkt.ProduktName = item.ProduktName;
                    produkt.ProduktMenge = item.ProduktMenge;
                    produkt.Preis = item.Preis;
                    // Füllen von RegalTExt und KategorieText fehlt noch
                    foreach(Regal regal in ProdEditRegalFK)
                    {
                        if(regal.RegalPk==item.ProduktRegalFk)
                        {
                            produkt.RegalText = regal.RegalName;
                        }
                    }
                    foreach (Kategorie kat in ProdEditKatFK)
                    {
                        if (kat.KategoriePk == item.ProduktKategorieFk)
                        {
                            produkt.KategorieText = kat.KategorieName;
                        }
                    }
                    ProdEditListe.Add(produkt);
                }

                
            }
        }
        private void Listefullen()
        {
            ProdEditListe.Clear();
            using(KVwProDBContext context= new KVwProDBContext())
            {
                var fillprod = context.Produkt;
                foreach(Produkt item in fillprod)
                {
                    ProduktExt produkt = new ProduktExt();
                    produkt.ProduktPk = item.ProduktPk;
                    produkt.ProduktName = item.ProduktName;
                    produkt.ProduktMenge = item.ProduktMenge;
                    produkt.Preis = item.Preis;
                    foreach (Regal regal in ProdEditRegalFK)
                    {
                        if (regal.RegalPk == item.ProduktRegalFk)
                        {
                            produkt.RegalText = regal.RegalName;
                        }
                    }
                    foreach (Kategorie kat in ProdEditKatFK)
                    {
                        if (kat.KategoriePk == item.ProduktKategorieFk)
                        {
                            produkt.KategorieText = kat.KategorieName;
                        }
                    }
                    ProdEditListe.Add(produkt);
                }
            }
        }
        private void Speichern()
        {
            if(SelektedProdEditListe== null)
            {
                // MessageBox
                MessageBox.Show("Kein Produkt hinzugefügt!", "Fehler", MessageBoxButton.OK);
                Listefullen();
                return;
            }
            if(SelektedProdEditListe.ProduktName==null|| SelektedProdEditListe.ProduktName ==""|| SelektedProdEditListe.Preis<=0|| SelektedProdEditListe.ProduktMenge<=0)
            {
                // MessageBox
                MessageBox.Show("Unvollständige Daten wurden eingegeben!", "Fehler", MessageBoxButton.OK);
                Listefullen();
                return;
            }
            // Regal FK Eingabe
            EditProdRegalFK = 0;
            foreach(Regal regal in ProdEditRegalFK)
            {
                if(regal.RegalName == SelektedProdEditListe.RegalText)
                {
                    EditProdRegalFK = regal.RegalPk;
                }
            }
            if(EditProdRegalFK==0)
            {
                MessageBox.Show("Regal existiert nicht!", "Fehler", MessageBoxButton.OK);
                return;
            }
            // Kategorie FK Eingabe
            EditProdKatFK = 0;
            foreach(Kategorie katFK in ProdEditKatFK)
            {
                if(katFK.KategorieName== SelektedProdEditListe.KategorieText)
                {
                    EditProdKatFK = katFK.KategoriePk;
                }
            }
            if(EditProdKatFK==0)
            {
                MessageBox.Show("Kategorie existiert nicht!", "Fehler", MessageBoxButton.OK);
                return;
            }
            // Abruf der DB Daten und in SelektedList speichern
            using (KVwProDBContext context= new KVwProDBContext())
            {
                Produkt editedProdukt = context.Produkt.Where(p => p.ProduktPk == SelektedProdEditListe.ProduktPk).FirstOrDefault();
                if(editedProdukt!=null)
                {
                    // Der Benutzer hat einen bestehenden Eintrag editiert
                    editedProdukt.ProduktName = SelektedProdEditListe.ProduktName;
                    editedProdukt.Preis = SelektedProdEditListe.Preis;
                    editedProdukt.ProduktMenge = SelektedProdEditListe.ProduktMenge;
                    editedProdukt.ProduktRegalFk = EditProdRegalFK;
                    editedProdukt.ProduktKategorieFk = EditProdKatFK;
                }
                else
                {
                    // Der Benutzer hat einen neuen Eintrag eingegeben
                    editedProdukt = new Produkt();
                    editedProdukt.ProduktName = SelektedProdEditListe.ProduktName;
                    editedProdukt.Preis = SelektedProdEditListe.Preis;
                    editedProdukt.ProduktMenge = SelektedProdEditListe.ProduktMenge;
                    editedProdukt.ProduktRegalFk = EditProdRegalFK;
                    editedProdukt.ProduktKategorieFk = EditProdKatFK;
                    context.Produkt.Add(editedProdukt);
                }
                context.SaveChanges();  // Speicherung der Änderung in DB
            }
            Verlassen();
        }
        private void DelProdukt()
        {
            MessageBoxResult result = MessageBox.Show("Wollen Sie wirklich die angegeben Daten löschen", "Löschen", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // Datensatz löschen
                using (KVwProDBContext context= new KVwProDBContext())
                {
                    Produkt delProdukt = context.Produkt.Where(p => p.ProduktPk == SelektedProdEditListe.ProduktPk).FirstOrDefault();
                    // Registrierung
                    context.Produkt.Remove(delProdukt);
                    // Änderung speichern
                    context.SaveChanges();
                }
                Listefullen();
            }
        }
        private void Verlassen()
        {
            // window schließen
            m_window.Close();
        }
    }
}
