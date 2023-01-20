using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.EntitiesForView
{
    public class AdresyForAllView
    {
        public int IDAdresu { get; set; }
        public string Ulica { get; set; }
        public string NrDomu { get; set; }
        public string NrLokalu { get; set; }
        public string KodPocztowy { get; set; }
        public string Miasto { get; set; }
        public string WojewodztwoNazwa { get; set; }
        public string KrajNazwa { get; set; }

    }
}
