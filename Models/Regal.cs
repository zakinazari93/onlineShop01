﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace KVwWPF.Models
{
    public partial class Regal
    {
        public Regal()
        {
            Produkt = new HashSet<Produkt>();
        }

        public int RegalPk { get; set; }
        public string RegalName { get; set; }
        public string RegalOrt { get; set; }
        public int RegalMaxAnz { get; set; }

        public virtual ICollection<Produkt> Produkt { get; set; }
    }
}