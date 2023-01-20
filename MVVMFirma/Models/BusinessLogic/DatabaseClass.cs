using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.BusinessLogic
{
    public class DatabaseClass
    {
        #region Fields
        protected GabinetEntities4 gabinetEntities;
        #endregion Fields

        #region Constructor
        public DatabaseClass(GabinetEntities4 gabinetEntities)
        {
            this.gabinetEntities = gabinetEntities;
        }
        #endregion Constructor
    }
}
