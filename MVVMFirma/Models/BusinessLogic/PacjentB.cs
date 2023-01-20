using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.BusinessLogic
{
    public class PacjentB: DatabaseClass
    {
        public PacjentB(GabinetEntities4 gabinetEntities)
            :base(gabinetEntities)
        {

        }
        #region  ViewFunction
        //metoda pobierze 
        public IQueryable<ComboBoxKeyAndValue> GetPacjentComboBoxItems()
        {
            return
                (
                    from pacjent in gabinetEntities.Pacjent
                    select new ComboBoxKeyAndValue
                    {
                        Key = pacjent.IDPacjenta,
                        Value = pacjent.Imie+ " " + pacjent.Nazwisko
                    }
                ).ToList().AsQueryable();
        }
        #endregion ViewFunction
    }
}
