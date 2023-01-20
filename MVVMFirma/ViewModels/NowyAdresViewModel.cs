using MVVMFirma.Models.Entities;
using MVVMFirma.Models.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class NowyAdresViewModel : JedenViewModel<Adres>, IDataErrorInfo
    {

        public NowyAdresViewModel()
           : base()
        {
            // tu okreslamy nazwe zakladki
            base.DisplayName = "Adres";
            item = new Adres();
        }
        public int IDAdresu
        {
            get
            {
                return item.IDAdresu;
            }
            set
            {
                if (item.IDAdresu != value)
                {
                    item.IDAdresu = value;
                    base.OnPropertyChanged(() => IDAdresu);
                }
            }
        }
        public string Ulica
        {
            get
            {
                return item.Ulica;
            }
            set
            {
                if (item.Ulica != value)
                {
                    item.Ulica = value;
                    base.OnPropertyChanged(() => Ulica);
                }
            }
        }
        public string NrDomu
        {
            get
            {
                return item.NrDomu;
            }
            set
            {
                if (item.NrDomu != value)
                {
                    item.NrDomu = value;
                    base.OnPropertyChanged(() => NrDomu);
                }
            }
        }
        public string NrLokalu
        {
            get
            {
                return item.NrLokalu;
            }
            set
            {
                if (item.NrLokalu != value)
                {
                    item.NrLokalu = value;
                    base.OnPropertyChanged(() => NrLokalu);
                }
            }
        }
        public int? IDKraju
        {
            get
            {
                return item.IDKraju;
            }
            set
            {
                if (item.IDKraju != value)
                {
                    item.IDKraju = value;
                    base.OnPropertyChanged(() => IDKraju);
                }
            }
        }
        public int? IDWojewodztwa
        {
            get
            {
                return item.IDWojewodztwa;
            }
            set
            {
                if (item.IDWojewodztwa != value)
                {
                    item.IDWojewodztwa = value;
                    base.OnPropertyChanged(() => IDWojewodztwa);
                }
            }
        }
          public string KodPocztowy
        {
            get
            {
                return item.KodPocztowy;
            }
            set
            {
                if (item.KodPocztowy != value)
                {
                    item.KodPocztowy = value;
                    base.OnPropertyChanged(() => KodPocztowy);
                }
            }
        }
        public string Miasto
        {
            get
            {
                return item.Miasto;
            }
            set
            {
                if (item.Miasto != value)
                {
                    item.Miasto = value;
                    base.OnPropertyChanged(() => Miasto);
                }
            }
        }
        //to jest propertis ktory służy do wypełnienia combo boxa wyświetlającego do wyboru 
        //wszystkie wojewodztwa
        public IQueryable<Wojewodztwo> WojewodztwaComboBoxItems
        {
            get
            {
                return
                    (
                    from wojewodztwo in gabinetEntities.Wojewodztwo
                    select wojewodztwo
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<Kraj> KrajeComboBoxItems
        {
            get
            {
                return
                    (
                    from kraj in gabinetEntities.Kraj
                    select kraj
                    ).ToList().AsQueryable();
            }
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
                if (name == "Ulica")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Ulica);
                }
                if (name == "Miasto")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Miasto);
                }
                if (name == "KodPocztowy")
                {
                    komunikat = StringValidator.SprawdzCzyKodPocztowyJestPoprawnyRegEx(this.KodPocztowy);
                }
                return komunikat;
            }
        }
        //dodajemy funkcje ktora przed zapisem bedzie sprawdzala czy mozna zapisac rekord
        //jezeli ta funkcja zwroci true rekord bedzie zapisany
        //jezeli false nie pozwoli zapisac rekordu
        public override bool IsValid()
        {
            if (this["Ulica"] == null && this["Miasto"] == null)
                return true;
            return false;
        }
        #endregion
        #region  Helpers 
        public override void Save()
        {
            //najpierw dodajemy towar do lokalnej kolekcji towarów
            gabinetEntities.Adres.Add(item);
            //a następnie zapisujemy zmiany w bazie danych
            gabinetEntities.SaveChanges();
        }
        #endregion Heplpers
    }
}
