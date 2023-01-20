using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.BusinessLogic
{
    public class ZyskU:DatabaseClass
    {
        #region  Constructor
        public ZyskU(GabinetEntities4 gabinetEntities)
            : base(gabinetEntities)
        {
        }
        #endregion Constructor
        #region BusinessFunction
        //Funkcja 
        public decimal? ZyskOkresUsluga(int idUslugi, DateTime odDaty, DateTime doDaty)
        {
            return
                (
                    from pozycja in gabinetEntities.PozycjaFaktury
                    where
                    pozycja.IDUslugi == idUslugi &&
                    pozycja.Faktura.DataWystawienia >= odDaty &&
                    pozycja.Faktura.DataWystawienia <= doDaty
                    select pozycja.Cena * pozycja.Ilosc
                ).Sum();
        }
        #endregion BusinessFunction
    }
}
