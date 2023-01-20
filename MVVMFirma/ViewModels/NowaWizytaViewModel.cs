using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.Models.Validator;
using System;
using System.ComponentModel;
using System.Linq;

namespace MVVMFirma.ViewModels
{
    public class NowaWizytaViewModel : JedenViewModel<Wizyta>, IDataErrorInfo
    {
        public NowaWizytaViewModel()
            : base()
        {
            // tu okreslamy nazwe zakladki
            base.DisplayName = "Wizyta";
            item = new Wizyta();
        }
        #region Propertis

        public DateTime? DataWizyty
        {
            get
            {
                return item.DataWizyty;
            }
            set
            {
                if (item.DataWizyty != value)
                {
                    item.DataWizyty = value;
                    base.OnPropertyChanged(() => DataWizyty);
                }
            }
        }
        public string GodzinaWizyty
        {
            get
            {
                return item.GodzinaWizyty;
            }
            set
            {
                if (item.GodzinaWizyty != value)
                {
                    item.GodzinaWizyty = value;
                    base.OnPropertyChanged(() => GodzinaWizyty);
                }
            }
        }
        public int? IDPacjenta
        {
            get
            {
                return item.IDPacjenta;
            }
            set
            {
                if (item.IDPacjenta != value)
                {
                    item.IDPacjenta = value;
                    base.OnPropertyChanged(() => IDPacjenta);
                }
            }
        }
        //to jest properties obsługujący comboboxa z wyborem pacjentow
        public IQueryable<ComboBoxKeyAndValue> PacjenciComboBoxItems
        {
            get
            {
                return
                    (
                    //Zapytanie pobiera z bazy danych wszytskich pacjentow 
                    //i zapisuje ich w comboBoxKeyAndValue
                    from pacjent in gabinetEntities.Pacjent
                    select new ComboBoxKeyAndValue
                    {
                        Key = pacjent.IDPacjenta,
                        Value = pacjent.Imie + " " + pacjent.Nazwisko
                    }
                    ).ToList().AsQueryable();
            }
        }
       public int? IDRodzajuWizyty
        {
            get
            {
                return item.IDRodzajuWizyty;
            }
            set
            {
                if (item.IDRodzajuWizyty != value)
                {
                    item.IDRodzajuWizyty = value;
                    base.OnPropertyChanged(() => IDRodzajuWizyty);
                }
            }
        }
        //to jest propertis ktory służy do wypełnienia combo boxa wyświetlającego do wyboru 
        //wszystkich sposobów płatności
        public IQueryable<RodzajWizyty> RodzajeWizytComboBoxItems
        {
            get
            {
                return
                    (
                    from rodzajWizyty in gabinetEntities.RodzajWizyty
                    select rodzajWizyty
                    ).ToList().AsQueryable();
            }
        }
        public int? IDEWizyty
        {
            get
            {
                return item.IDEWizyty;
            }
            set
            {
                if (item.IDEWizyty != value)
                {
                    item.IDEWizyty = value;
                    base.OnPropertyChanged(() => IDEWizyty);
                }
            }
        }

        public IQueryable<EWizyta> EWizytaComboBoxItems
        {
            get
            {
                return
                    (
                    from ewizyta in gabinetEntities.EWizyta
                    select ewizyta
                    ).ToList().AsQueryable();
            }
        }

        public int? IDTypuWizyty
        {
            get
            {
                return item.IDTypuWizyty;
            }
            set
            {
                if (item.IDTypuWizyty != value)
                {
                    item.IDTypuWizyty = value;
                    base.OnPropertyChanged(() => IDTypuWizyty);
                }
            }
        }
        //wszystkich sposobów płatności
        public IQueryable<TypWizyty> TypyWizytComboBoxItems
        {
            get
            {
                return
                    (
                    from typWizyty in gabinetEntities.TypWizyty
                    select typWizyty
                    ).ToList().AsQueryable();
            }
        }
        public int? IDSkierowania
        {
            get
            {
                return item.IDSkierowania;
            }
            set
            {
                if (item.IDSkierowania != value)
                {
                    item.IDSkierowania = value;
                    base.OnPropertyChanged(() => IDSkierowania);
                }
            }
        }
        public IQueryable<Skierowanie> SkierowanieComboBoxItems
        {
            get
            {
                return
                    (
                    from skierowanie in gabinetEntities.Skierowanie
                    select skierowanie
                    ).ToList().AsQueryable();
            }
        }
        public int? IDUslugi
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
        #endregion Propertis
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
                if (name == "GodzinaWizyty")
                {
                    komunikat = StringValidator.SprawdzCzyFormatGodzinyJestPoprawny(this.GodzinaWizyty);
                }
                if (name == "DataWizyty")
                {
                    komunikat = StringValidator.SprawdzDateWizyty(this.DataWizyty);
                }
                return komunikat;
            }
        }
        //dodajemy funkcje ktora przed zapisem bedzie sprawdzala czy mozna zapisac rekord
        //jezeli ta funkcja zwroci true rekord bedzie zapisany
        //jezeli false nie pozwoli zapisac rekordu
        public override bool IsValid()
        {
            if (this["GodzinaWizyty"] == null)
                return true;
            return false;
        }
        #endregion
        public override void Save()
        {
            //najpierw dodajemy towar do lokalnej kolekcji towarów
            gabinetEntities.Wizyta.Add(item);
            //a następnie zapisujemy zmiany w bazie danych
            gabinetEntities.SaveChanges();
        }
    }
}