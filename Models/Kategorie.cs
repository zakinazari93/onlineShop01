// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace KVwWPF.Models
{
    public partial class Kategorie
    {
        public Kategorie()
        {
            Produkt = new HashSet<Produkt>();
        }

        public int KategoriePk { get; set; }
        public string KategorieName { get; set; }

        public virtual ICollection<Produkt> Produkt { get; set; }
    }
}