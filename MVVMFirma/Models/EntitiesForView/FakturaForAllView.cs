using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.EntitiesForView
{
    //tworzy my tę klasę po to żeby w klasie faktury, ktróa miała klucze obce w tej klasie zastapić klucze
    //konkretnymi danymi
    public class FakturaForAllView
    {
        public int IDFaktury { get; set; }
        public string Numer { get; set; }
        public DateTime? DataWystawienia { get; set; }
        //to są pola zamiast klucza obcego IDKontrahenta
        public string KontrahentNazwa { get; set; }
        public string KontrahentNip { get; set; }
        public string KontrahentAdres { get; set; }
        public DateTime? TerminPlatnosci { get; set; }
        // to jest pole zamiast IDSposobuPlatnosci
        public string SposobPlatnosciNazwa { get; set; }
        public string StatusFakturyNazwa { get; set; }

    }
}
