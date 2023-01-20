using MVVMFirma.Models.Entities;
using MVVMFirma.Models.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class NowaUslugaViewModel : JedenViewModel<Usluga>
    {
        public NowaUslugaViewModel()
          : base()
        {
            // tu okreslamy nazwe zakladki
            base.DisplayName = "Usługa";
            item = new Usluga();
        }
        public int IDUslugi
        {
            get
            {
                return item.IDUslugi;
            }
            set
            {
                if (item.IDUslugi != value)
                {
                    item.IDUslugi = value;
                    base.OnPropertyChanged(() => IDUslugi);
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
            gabinetEntities.Usluga.Add(item);
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
