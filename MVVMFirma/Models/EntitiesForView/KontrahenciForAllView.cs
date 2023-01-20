using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.EntitiesForView
{
    public class KontrahenciForAllView
    {
        public int IDKontrahenta { get; set; }
        public int? IDAdresu { get; set; }
        public string Nazwa { get; set; }
        public string OsobaKontaktowa { get; set; }
        public string Nip { get; set; }
        public string Regon { get; set; }
        public string Kod { get; set; }
        public string AdresEmail { get; set; }
        public string NrTelefonu { get; set; }
        public string KontrahentAdres { get; set; }
        public string AdresUlica { get; set; }
        public string AdresNrDomu { get; set; }
        public string AdresNrLokalu { get; set; }
        public string AdresKodPocztowy { get; set; }
        public string AdresMiasto { get; set; }
        public string AdresWojewodztwoNazwa { get; set; }
        public string AdresKrajNazwa { get; set; }
    }
}
