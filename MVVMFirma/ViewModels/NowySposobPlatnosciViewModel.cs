using MVVMFirma.Models.Entities;
using MVVMFirma.Models.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class NowySposobPlatnosciViewModel : JedenViewModel<SposobPlatnosci>, IDataErrorInfo
    {
        public NowySposobPlatnosciViewModel()
            : base()
        {
            // tu okreslamy nazwe zakladki
            base.DisplayName = "Sposób płatności";
            item = new SposobPlatnosci();
        }
        public int IDSposobuPlatnosci
        {
            get
            {
                return item.IDSposobuPlatnosci;
            }
            set
            {
                if (item.IDSposobuPlatnosci != value)
                {
                    item.IDSposobuPlatnosci = value;
                    base.OnPropertyChanged(() => IDSposobuPlatnosci);
                }
            }
        }
        public string Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                if (item.Nazwa != value)
                {
                    item.Nazwa = value;
                    base.OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public override void Save()
        {
            //najpierw dodajemy towar do lokalnej kolekcji towarów
            gabinetEntities.SposobPlatnosci.Add(item);
            //a następnie zapisujemy zmiany w bazie danych
            gabinetEntities.SaveChanges();
        }
        #region  Validation 
        public string Error
        {
            get
            {
                return null;
            }
        }
        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "Nazwa")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Nazwa);
                }
                return komunikat;
            }
        }
        //dodajemy funkcje ktora przed zapisem bedzie sprawdzala czy mozna zapisac rekord
        //jezeli ta funkcja zwroci true rekord bedzie zapisany
        //jezeli false nie pozwoli zapisac rekordu
        public override bool IsValid()
        {
            if (this["Nazwa"] == null)
                return true;
            return false;
        }
        #endregion
    }
}
