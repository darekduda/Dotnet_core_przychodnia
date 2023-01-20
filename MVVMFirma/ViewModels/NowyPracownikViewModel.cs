using MVVMFirma.Models.Entities;
using MVVMFirma.Models.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class NowyPracownikViewModel : JedenViewModel<Pracownik>, IDataErrorInfo
    {
        public NowyPracownikViewModel()
        : base()
        {
            // tu okreslamy nazwe zakladki
            base.DisplayName = "Pracownik";
            item = new Pracownik();
        }
        public int IDPracownika
        {
            get
            {
                return item.IDPracownika;
            }
            set
            {
                if (item.IDPracownika != value)
                {
                    item.IDPracownika = value;
                    base.OnPropertyChanged(() => IDPracownika);
                }
            }
        }
        public string Imie
        {
            get
            {
                return item.Imie;
            }
            set
            {
                if (item.Imie != value)
                {
                    item.Imie = value;
                    base.OnPropertyChanged(() => Imie);
                }
            }
        }
        public string Nazwisko
        {
            get
            {
                return item.Nazwisko;
            }
            set
            {
                if (item.Nazwisko != value)
                {
                    item.Nazwisko = value;
                    base.OnPropertyChanged(() => Nazwisko);
                }
            }
        }
        public string Stanowisko
        {
            get
            {
                return item.Stanowisko;
            }
            set
            {
                if (item.Stanowisko != value)
                {
                    item.Stanowisko = value;
                    base.OnPropertyChanged(() => Stanowisko);
                }
            }
        }
        public override void Save()
        {
            //najpierw dodajemy towar do lokalnej kolekcji towarów
            gabinetEntities.Pracownik.Add(item);
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
                if (name == "Imie")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Imie);
                }
                //if (name == "Imie")
                //{
                //    komunikat = StringValidator.SprawdzCzyMaWiecejNizDwaZnaki(this.Imie);
                //}
                if (name == "Nazwisko")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.Nazwisko);
                }
                return komunikat;
            }
        }
        //dodajemy funkcje ktora przed zapisem bedzie sprawdzala czy mozna zapisac rekord
        //jezeli ta funkcja zwroci true rekord bedzie zapisany
        //jezeli false nie pozwoli zapisac rekordu
        public override bool IsValid()
        {
            if (this["Imie"] == null && this["Nazwisko"] == null && this["Stanowisko"] == null)
                return true;
            return false;
        }
        #endregion
    }
}

