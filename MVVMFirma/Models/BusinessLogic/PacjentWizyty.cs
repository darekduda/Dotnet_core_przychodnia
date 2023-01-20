using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.BusinessLogic
{
    class PacjentWizyty : DatabaseClass
    {
        public PacjentWizyty(GabinetEntities4 gabinetEntities)
            :base(gabinetEntities)
        {

        }
        public decimal? WizytyPacjenta(int idPacjenta, DateTime odDaty, DateTime doDaty)
        {
            return
                (
                    from wizyta in gabinetEntities.Wizyta
                    where
                    wizyta.IDPacjenta == idPacjenta &&
                    wizyta.DataWizyty >= odDaty &&
                    wizyta.DataWizyty <= doDaty
                    select wizyta.IDWizyty
                    ).Count();
        }
    }
}
