using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.Models.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
   public class NowyPacjentViewModel : JedenViewModel<Pacjent>, IDataErrorInfo
    {

        #region Fields
        //to jest komenda która wywoła okno wyświetlające wszystkich kontrahentów
        private BaseCommand _ShowAdresy;
        #endregion Fields

        public NowyPacjentViewModel()
            :base()
        {
            // tu okreslamy nazwe zakladki
            base.DisplayName = "Pacjent";
            item = new Pacjent();
            //ten messenger oczekuje na kontrahneta który przyjdzie do nowej faktury z okna wyświetlającego wszytskich kontrahentów
            //jezeli zlapiemy messegerem kontrahenta wybranego w oknie kontrahenci to wywołamy funkcję getWybranyKontrahent
            Messenger.Default.Register<AdresyForAllView>(this, getWybranyAdres);
        }

        #region Command
        //ta komenda która wywoła okno wszyscy kontrahenci 
        //ta komenda do MainWindowViewModel wyśle messengerem komunikat Adresy Show 
        public ICommand ShowAdresy
        {
            get
            {
                if (_ShowAdresy == null)
                    _ShowAdresy = new BaseCommand(() => Messenger.Default.Send("Adresy Show"));

                return _ShowAdresy;
            }
        }
        #endregion

        // dla każdego pola na interfejsie trzeba utworzyć propertisa zgodnie z poniższym wzorem
        public int IDPacjenta
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

        public String Pesel
        {
            get
            {
                return item.Pesel;
            }
            set
            {
                if (item.Pesel != value)
                {
                    item.Pesel = value;
                    base.OnPropertyChanged(() => Pesel);
                }
            }
        }

        public string NrTelefonu
        {
            get
            {
                return item.NrTelefonu;
            }
            set
            {
                if (item.NrTelefonu != value)
                {
                    item.NrTelefonu = value;
                    base.OnPropertyChanged(() => NrTelefonu);
                }
            }
        }

        public string AdresEmail
        {
            get
            {
                return item.AdresEmail;
            }
            set
            {
                if (item.AdresEmail != value)
                {
                    item.AdresEmail = value;
                    base.OnPropertyChanged(() => AdresEmail);
                }
            }
        }

        public int? IDStatusuPacjenta
        {
            get
            {
                return item.IDStatusuPacjenta; 
            }
            set
            {
                if (item.IDStatusuPacjenta != value)
                {
                    item.IDStatusuPacjenta = value;
                    base.OnPropertyChanged(() => IDStatusuPacjenta);
                }
            }
        }

        public int? IDOddziałuNFZ
        {
            get
            {
                return item.IDOddziałuNFZ;
            }
            set
            {
                if (item.IDOddziałuNFZ != value)
                {
                    item.IDOddziałuNFZ = value;
                    base.OnPropertyChanged(() => IDOddziałuNFZ);
                }
            }
        }

        //to jest propertis ktory służy do wypełnienia combo boxa wyświetlającego do wyboru 
        //wszystkie wojewodztwa
        public IQueryable<StatusPacjenta> StatusPacjentaComboBoxItems
        {
            get
            {
                return
                    (
                    from status in gabinetEntities.StatusPacjenta
                    select status
                    ).ToList().AsQueryable();
            }
        }

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
        public IQueryable<OddziałNFZ> OddzialyNFZComboBoxItems
        {
            get
            {
                return
                    (
                    from oddzialNFZ in gabinetEntities.OddziałNFZ
                    select oddzialNFZ
                    ).ToList().AsQueryable();
            }
        }

        public int? IDAdresu
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

        //to jest properties obsługujący comboboxa z wyborem kontrahentów
        public IQueryable<ComboBoxKeyAndValue> AdresyComboBoxItems
        {
            get
            {
                return
                    (
                    //Zapytanie pobiera z bazy danych wszytskich kontrahentów 
                    //i zapisuje ich w comboBoxKeyAndValue
                    from adres in gabinetEntities.Adres
                    select new ComboBoxKeyAndValue
                    {
                        Key = adres.IDAdresu,
                        Value = adres.Ulica + " "+ adres.NrDomu + " "+ adres.NrLokalu + " "
                        + adres.Miasto + " " + adres.KodPocztowy
                    }
                    ).ToList().AsQueryable();
            }
        }
        private string _Ulica;
        public string Ulica
        {
            get
            {
                return _Ulica;
            }
            set
            {
                if (_Ulica != value)
                {
                    _Ulica = value;
                    base.OnPropertyChanged(() => Ulica);
                }
            }
        }
        private string _NrDomu;
        public string NrDomu
        {
            get
            {
                return _NrDomu;
            }
            set
            {
                if (_NrDomu != value)
                {
                    _NrDomu = value;
                    base.OnPropertyChanged(() => NrDomu);
                }
            }
        }
        private string _NrLokalu;
        public string NrLokalu
        {
            get
            {
                return _NrLokalu;
            }
            set
            {
                if (_NrLokalu != value)
                {
                    _NrLokalu = value;
                    base.OnPropertyChanged(() => NrLokalu);
                }
            }
        }
        private string _KodPocztowy;
        public string KodPocztowy
        {
            get
            {
                return _KodPocztowy;
            }
            set
            {
                if (_KodPocztowy != value)
                {
                    _KodPocztowy = value;
                    base.OnPropertyChanged(() => KodPocztowy);
                }
            }
        }
        private string _Miasto;
        public string Miasto
        {
            get
            {
                return _Miasto;
            }
            set
            {
                if (_Miasto != value)
                {
                    _Miasto = value;
                    base.OnPropertyChanged(() => Miasto);
                }
            }
        }
        private string _WojewodztwoNazwa;
        public string WojewodztwoNazwa
        {
            get
            {
                return _WojewodztwoNazwa;
            }
            set
            {
                if (_WojewodztwoNazwa != value)
                {
                    _WojewodztwoNazwa = value;
                    base.OnPropertyChanged(() => WojewodztwoNazwa);
                }
            }
        }

        private string _KrajNazwa;
        public string KrajNazwa
        {
            get
            {
                return _KrajNazwa;
            }
            set
            {
                if (_KrajNazwa != value)
                {
                    _KrajNazwa = value;
                    base.OnPropertyChanged(() => KrajNazwa);
                }
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
                if (name == "Pesel")
                {
                    komunikat = StringValidator.SprawdzCzyPeselJestPoprawny(this.Pesel);
                }

                if (name == "AdresEmail")
                {
                    komunikat = StringValidator.SprawdzCzyEMAILJestPoprawny(this.AdresEmail);
                }
                if (name == "NrTelefonu")
                {
                    komunikat = StringValidator.SprawdzCzyNumerTelMaPoprawneZnaki(this.NrTelefonu);
                }
                return komunikat;
            }
        }
        //dodajemy funkcje ktora przed zapisem bedzie sprawdzala czy mozna zapisac rekord
        //jezeli ta funkcja zwroci true rekord bedzie zapisany
        //jezeli false nie pozwoli zapisac rekordu
        public override bool IsValid()
        {
            if (this["Imie"] == null && this["Nazwisko"] == null && this["NrTelefonu"] == null)
                return true;
            return false;
        }
        #endregion

        private void getWybranyAdres(AdresyForAllView adres)
        {
            //uzupełniamy dane kontrahenta w fakturze na bazie danych kontrahenta ktory przyjdzie z okna ze wszytskimi konttrahentami
            IDAdresu = adres.IDAdresu;
            Ulica = adres.Ulica;
            NrDomu = adres.NrDomu;
            NrLokalu = adres.NrLokalu;
            KodPocztowy = adres.KodPocztowy;
            Miasto = adres.Miasto;
            WojewodztwoNazwa = adres.WojewodztwoNazwa;
            KrajNazwa = adres.KrajNazwa;
        }


        public override void Save()
        {
            //najpierw dodajemy towar do lokalnej kolekcji towarów
            gabinetEntities.Pacjent.Add(item);
            //a następnie zapisujemy zmiany w bazie danych
            gabinetEntities.SaveChanges();
        }
    }
}
