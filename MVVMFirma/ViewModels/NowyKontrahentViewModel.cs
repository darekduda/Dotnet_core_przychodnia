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
    public class NowyKontrahentViewModel : JedenViewModel<Kontrahent>, IDataErrorInfo // wsystkie zakładki dziedziczą po workSpaceViewModel
    {
        #region Fields
        //to jest komenda która wywoła okno wyświetlające wszystkich kontrahentów
        private BaseCommand _ShowAdresy;
        #endregion Fields

        #region MyRegion

        public NowyKontrahentViewModel()
            :base()
        {
            base.DisplayName = "Nowy kontrahent"; //nazwa zakładki
            item = new Kontrahent();
            //ten messenger oczekuje na kontrahneta który przyjdzie do nowej faktury z okna wyświetlającego wszytskich kontrahentów
            //jezeli zlapiemy messegerem kontrahenta wybranego w oknie kontrahenci to wywołamy funkcję getWybranyKontrahent
            Messenger.Default.Register<AdresyForAllView>(this, getWybranyAdres);

        }

        #region Command
        //ta komenda która wywoła okno wszyscy kontrahenci 
        //ta komenda do MainWindowViewModel wyśle messengerem komunikat KontrahenciShow 
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

        public string Kod
        {
            get
            {
                return item.Kod;
            }
            set
            {
                if (item.Kod != value)
                {
                    item.Kod = value;
                    base.OnPropertyChanged(() => Kod);
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

        public string Nip
        {
            get
            {
                return item.Nip;
            }
            set
            {
                if (item.Nip != value)
                {
                    item.Nip = value;
                    base.OnPropertyChanged(() => Nip);
                }
            }
        }

        public string Regon
        {
            get
            {
                return item.Regon;
            }
            set
            {
                if (item.Regon != value)
                {
                    item.Regon = value;
                    base.OnPropertyChanged(() => Regon);
                }
            }
        }


        public string OsobaKontaktowa
        {
            get
            {
                return item.OsobaKontaktowa;
            }
            set
            {
                if (item.OsobaKontaktowa != value)
                {
                    item.OsobaKontaktowa = value;
                    base.OnPropertyChanged(() => OsobaKontaktowa);
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

        #endregion

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
                if (name == "OsobaKontaktowa")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(this.OsobaKontaktowa);
                }
                if (name == "Nip")
                {
                    komunikat = StringValidator.SprawdzCzyNIPJestPoprawny(this.Nip);
                }
                if (name == "Regon")
                {
                    komunikat = StringValidator.SprawdzCzyREGONJestPoprawny(this.Regon);
                }

                return komunikat;
            }
        }
        //dodajemy funkcje ktora przed zapisem bedzie sprawdzala czy mozna zapisac rekord
        //jezeli ta funkcja zwroci true rekord bedzie zapisany
        //jezeli false nie pozwoli zapisac rekordu
        public override bool IsValid()
        {
            if (this["Nazwa"] == null && this["Nip"] == null )
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
            gabinetEntities.Kontrahent.Add(item);
            //a następnie zapisujemy zmiany w bazie danych
            gabinetEntities.SaveChanges();
        }
    }
}
