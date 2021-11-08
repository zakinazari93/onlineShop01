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
    class RechnungViewModel: BaseViewModel
    {
        // Properties
        public double RechnungSumme { get; set; }
        public double MWSt { get; set; }
        private DateTime m_Datum;
        public string Datum
        {
            get { return m_Datum.ToShortDateString(); }
            set
            {
                m_Datum = DateTime.Today;
            }
        }
        public Rechnung SelektedFinalRech { get; set; }
        // ICommand
        public ICommand FinishCmd { get; set; }

        // Attribute
        private RechnungWindow m_window;

        // Konstruktor
        public RechnungViewModel(double RechSum, RechnungWindow window)
        {
            m_window = window;
            RechnungSumme = RechSum;
            MWSt = RechSum * 0.2;
            // Command
            FinishCmd = new RelayCommand(FertigMeth);
            Datum = "";
        }
        private void FertigMeth ()
        {
            m_window.Close();
        }
    }
}
