// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace KVwWPF.Models
{
    public partial class ProdRechZuordnung
    {
        public int ProdRechProduktFk { get; set; }
        public int ProdRechRechnungFk { get; set; }

        public virtual Produkt ProdRechProduktFkNavigation { get; set; }
        public virtual Rechnung ProdRechRechnungFkNavigation { get; set; }
    }
}