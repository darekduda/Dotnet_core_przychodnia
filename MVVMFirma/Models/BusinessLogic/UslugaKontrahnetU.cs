using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.BusinessLogic
{
    public class UslugaKontrahnetU : DatabaseClass
    {
        public UslugaKontrahnetU(GabinetEntities4 gabinetEntities)
            :base(gabinetEntities)
        {

        }
        #region  ViewFunction
        //metoda pobierze 
        public IQueryable<ComboBoxKeyAndValue> GetUslugiKontrahentComboBoxItems()
        {
            return
                (
                    from usluga in gabinetEntities.UslugaKontrahent
                    select new ComboBoxKeyAndValue
                    {
                        Key = usluga.IDUslugi,
                        Value = usluga.Nazwa
                    }
                ).ToList().AsQueryable();
        }
        #endregion ViewFunction
    }
}
