using KVwWPF.Commands;
using KVwWPF.Models;
using KVwWPF.Views;
using Microsoft.EntityFrameworkCore;
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
    
    class ProdWahlViewModel: BaseViewModel
    {
        // Properties
        public ObservableCollection<Produkt> ProduktList { get; set; }
        public ObservableCollection<Produkt> MyChoice { get; set; }
        public ObservableCollection<Rechnung> RechList { get; set; } // Zugriff auf Rechnungen
        public Rechnung SelektedRech { get; set; }  // Ist ein SelektedRechnung vorhanden
        public Produkt SelektedProdukt { get; set; }
        public Produkt MeinProdukt { get; set; }
        public double MengeAdd { get; private set; }  // Durch Klicken auf Rechte Fensterseite zeigen und addieren
        public double PreisSum { get; private set; }
        public int RechNr { get; private set; } // Für Button Weiter und Speichern der neuen Daten
        public DateTime RechDat { get; set; }
        public double RechSum { get; private set; }

        public double RechKundeFK { get; private set; }
        public double RechMitarbeiterFK { get; private set; }

        // Commands
        public ICommand AddCmd { get; set; }
        public ICommand RemoveCmd { get; set; }
        public ICommand WeiterCmd { get; set; }
        public ICommand AbbruchCmd { get; set; }

        // Attribute
        private int m_RechID;
        private int m_KundePK;
        private ProduktWahlWindow m_window;

        // Konstruktor
        public ProdWahlViewModel(ProduktWahlWindow window, int KundePk)
        {
            // Commands initialisieren
            AddCmd = new RelayCommand(AddProdukt);
            RemoveCmd = new RelayCommand(RemoveProdukt);
            WeiterCmd = new RelayCommand(Continue);
            AbbruchCmd = new RelayCommand(Cancelation);
            // Initialisierung der Window und Observalbe-Collection
            m_window = window;
            ProduktList = new ObservableCollection<Produkt>();
            MyChoice = new ObservableCollection<Produkt>();
            RechList = new ObservableCollection<Rechnung>(); // initialisieren von Rechnungen und Abfrage
            RechDat = DateTime.Now;
            m_KundePK = KundePk;
            using (KVwProDBContext context = new KVwProDBContext())
            {
                var produkt = context.Produkt;
                foreach (var item in produkt)
                {
                    ProduktList.Add(item);
                }
            }
        }
        public void AddProdukt()
        {
            using (KVwProDBContext context = new KVwProDBContext())
            {
                // Dies ist die Summe für die Rechnung
                PreisSum += SelektedProdukt.Preis;
                // Dieser Code macht einen Update für die Datenbank
                // Wir müssen in der DB den richtigen Eintrag suchen
                var produktWahl = context.Produkt.Where(p => p.ProduktPk == SelektedProdukt.ProduktPk).SingleOrDefault();
                if (produktWahl != null && produktWahl.ProduktMenge > 0)
                {
                    // Produkt wird zur Liste rechts hinzugefügt
                    LetzteProduktHinzuFuegen();
                    // Ein Produkt wird gekauft => Inkrement der Menge
                    produktWahl.ProduktMenge--;
                    // in DB speichern
                    context.SaveChanges();
                }
                else 
                {
                    // Fehlermeldung anzeigen
                    MessageBox.Show("Unvollständige Daten wurden eingegeben!", "Fehler", MessageBoxButton.OK);
                }
            }
        }
        private void RemoveProdukt()
        {
            using (KVwProDBContext context = new KVwProDBContext())
            {

                var produktABWahl = context.Produkt.Where(p => p.ProduktPk == SelektedProdukt.ProduktPk).SingleOrDefault();
                if (SelektedProdukt.ProduktMenge>=1 && SelektedProdukt.ProduktMenge<100)
                {
                    PreisSum -= SelektedProdukt.Preis;
                    produktABWahl.ProduktMenge++;
                    context.SaveChanges();
                    for (int i=0; i<MyChoice.Count; i++)
                    {
                        if(MyChoice[i].ProduktPk==SelektedProdukt.ProduktPk)
                        {
                            MyChoice.RemoveAt(i);
                            break;
                        }
                    }
                } 
            }  
        }
        private void LetzteProduktHinzuFuegen()
        {
            MeinProdukt = SelektedProdukt;
            MeinProdukt.ProduktMenge = 1;
            // einfügen an der Stelle 0, alle anderen rücken nach
            MyChoice.Insert(0, MeinProdukt);
        }
        private void Continue()
        {

            using (KVwProDBContext context= new KVwProDBContext())
            {
                // Neuer Eintrag
                Rechnung rech = new Rechnung();
                rech.RechKundeFk = m_KundePK;
                rech.RechNr = RechNr;
                rech.RechDat = RechDat;
                rech.RechSum = PreisSum;
                context.Rechnung.Add(rech);
                context.SaveChanges();
                m_RechID = rech.RechnungPk;
                RechnungWindow rechwindow = new RechnungWindow(PreisSum); // Initialisierung neuer Fenster
                rechwindow.ShowDialog();
            }
        }
        private void Cancelation()
        {
            using (KVwProDBContext context = new KVwProDBContext()) 
            {
                foreach (Produkt item in MyChoice)
                {
                    Produkt produkt = context.Produkt.Where(p => p.ProduktPk == item.ProduktPk).FirstOrDefault();
                    produkt.ProduktMenge++;
                    context.SaveChanges();
                    m_window.Close();
                } 

            }
        }
    }
}
