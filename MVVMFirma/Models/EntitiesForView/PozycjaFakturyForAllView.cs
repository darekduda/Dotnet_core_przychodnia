using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PozycjaFakturyForAllView
    {
        public int IDPozycjiFaktury { get; set; }
        public int IDFaktury { get; set; }
        public int IDUslugi { get; set; }
        public decimal? Ilosc { get; set; }
        public decimal? Cena { get; set; }
        public decimal? Rabat { get; set; }
        public string UslugaNazwa { get; set; }
    }
}
