﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace KVwWPF.Models
{
    public partial class Produkt
    {
        public Produkt()
        {
            ProdRechZuordnung = new HashSet<ProdRechZuordnung>();
        }

        public int ProduktPk { get; set; }
        public string ProduktName { get; set; }
        public double Preis { get; set; }
        public int ProduktMenge { get; set; }
        public int ProduktRegalFk { get; set; }
        public int ProduktKategorieFk { get; set; }

        public virtual Kategorie ProduktKategorieFkNavigation { get; set; }
        public virtual Regal ProduktRegalFkNavigation { get; set; }
        public virtual ICollection<ProdRechZuordnung> ProdRechZuordnung { get; set; }
    }
}