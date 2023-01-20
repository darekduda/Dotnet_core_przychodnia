using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.EntitiesForView
{
    public class PacjenciForAllView
    {
        public int IDPacjenta { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string AdresEmail { get; set; }
        public string NrTelefonu { get; set; }
        //to są pola zamiast klucza obcego IDAdresu
        public string PacjentAdres { get; set; }
        public string PacjentCzyAktywny { get; set; }
        public string PacjentNFZ { get; set; }
    }
}
