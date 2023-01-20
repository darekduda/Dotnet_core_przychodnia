using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.BusinessLogic
{
    public class LiczbaWizyt:DatabaseClass
    {
        public LiczbaWizyt(GabinetEntities4 gabinetEntities)
            :base(gabinetEntities)
        {

        }
    }
}
