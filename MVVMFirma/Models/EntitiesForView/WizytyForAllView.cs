using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.EntitiesForView
{
    public class WizytyForAllView
    {
        public int IDWizyty { get; set; }
        public string PacjentImieNazwisko { get; set; }
        public DateTime? DataWizyty { get; set; }
        public string GodzinaWizyty { get; set; }
        public string RodzajWizyty { get; set; }
        public string EWizyta { get; set; }
        public string TypWizyty { get; set; }
        public string Skierowanie { get; set; }
        
    }
}
