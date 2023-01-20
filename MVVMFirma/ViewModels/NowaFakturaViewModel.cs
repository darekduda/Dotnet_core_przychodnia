using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.Models.Validator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowaFakturaViewModel : JedenWszystkieViewModel<Faktura, PozycjaFakturyForAllView>   //, IDataErrorInfo
    {
        #region Fields
        //to jest komenda która wywoła okno wyświetlające wszystkich kontrahentów
        private BaseCommand _ShowKontrahenci;
        #endregion Fields
        public NowaFakturaViewModel()
            : base()
        {
            base.DisplayName = "Nowa Faktura";
            base.DisplayListName = "Pozycje faktury";
            item = new Faktura();
            DataWystawienia = DateTime.Now.AddDays(14);
            DataSprzedazy = DateTime.Now;
            TerminPlatnosci = DateTime.Now.AddDays(21);
            Messenger.Default.Register<KontrahenciForAllView>(this, getWybranyKontrahent);
            //to jest messenger który oczekuje na dodaną pozycję faktury w nowym oknie
            //messeneg jak zlapie pozycje faktory to wywoła metoda addPozycjeFaktury
            Messenger.Default.Register<PozycjaFaktury>(this, addPozycjaFaktury);
        }
        #region Command
        //ta komenda która wywoła okno wszyscy kontrahenci 
        //ta komenda do MainWindowViewModel wyśle messengerem komunikat KontrahenciShow 
        public ICommand ShowKontrahenci
        {
            get
            {
                if (_ShowKontrahenci == null)
                    _ShowKontrahenci = new BaseCommand(() => Messenger.Default.Send("Wszyscy kontrahenciShow"));

                return _ShowKontrahenci;
            }
        }
        #endregion
        #region Propertis
        public string Numer
        {
            get
            {
                return item.Numer;
            }
            set
            {
                if (item.Numer != value)
                {
                    item.Numer = value;
                    base.OnPropertyChanged(() => Numer);
                }
            }
        }
        public int? IDKontrahenta
        {
            get
            {
                return item.IDKontrahenta;
            }
            set
            {
                if (item.IDKontrahenta != value)
                {
                    item.IDKontrahenta = value;
                    base.OnPropertyChanged(() => IDKontrahenta);
                }
            }
        }
        // to jest properties obsługujący comboboxa z wyborem kontrahentów
        public IQueryable<ComboBoxKeyAndValue> KontrahenciComboBoxItems
        {
            get
            {
                return
                    (
                    //Zapytanie pobiera z bazy danych wszytskich kontrahentów 
                    //i zapisuje ich w comboBoxKeyAndValue
                    from kontrahent in gabinetEntities.Kontrahent
                    select new ComboBoxKeyAndValue
                    {
                        Key = kontrahent.IDKontrahenta,
                        Value = kontrahent.Nazwa
                    }
                    ).ToList().AsQueryable();
            }
        }
        public int? IDSposobuPlatnosci
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
        //to jest propertis ktory służy do wypełnienia combo boxa wyświetlającego do wyboru 
        //wszystkich sposobów płatności
        public IQueryable<SposobPlatnosci> SposobyPlatnosciComboBoxItems
        {
            get
            {
                return
                    (
                    from platnosc in gabinetEntities.SposobPlatnosci
                    select platnosc
                    ).ToList().AsQueryable();
            }
        }
        public int? IDStatusuFaktury
        {
            get
            {
                return item.IDStatusuFaktury;
            }
            set
            {
                if (item.IDStatusuFaktury != value)
                {
                    item.IDStatusuFaktury = value;
                    base.OnPropertyChanged(() => IDStatusuFaktury);
                }
            }
        }
        public IQueryable<StatusFaktury> StatusFakturyComboBoxItems
        {
            get
            {
                return
                    (
                    from statusFaktury in gabinetEntities.StatusFaktury
                    select statusFaktury
                    ).ToList().AsQueryable();
            }
        }
        public DateTime? TerminPlatnosci
        {
            get
            {
                return item.TerminPlatnosci;
            }
            set
            {
                if (item.TerminPlatnosci != value)
                {
                    item.TerminPlatnosci = value;
                    base.OnPropertyChanged(() => TerminPlatnosci);
                }
            }
        }
        public int? IDRodzajuKwoty
        {
            get
            {
                return item.IDRodzajuKwoty;
            }
            set
            {
                if (item.IDRodzajuKwoty != value)
                {
                    item.IDRodzajuKwoty = value;
                    base.OnPropertyChanged(() => IDRodzajuKwoty);
                }
            }
        }
        //to jest propertis ktory służy do wypełnienia combo boxa wyświetlającego do wyboru 
        //wszystkich sposobów płatności
        public IQueryable<RodzajKwoty> RodzajeKwotComboBoxItems
        {
            get
            {
                return
                    (
                    from rodzajKwoty in gabinetEntities.RodzajKwoty
                    select rodzajKwoty
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<UslugaKontrahent> UslugaKontrahentComboBoxItems
        {
            get
            {
                return
                    (
                    from usluga in gabinetEntities.UslugaKontrahent
                    select usluga
                    ).ToList().AsQueryable();
            }
        }
        public DateTime? DataWystawienia
        {
            get
            {
                return item.DataWystawienia;
            }
            set
            {
                if (item.DataWystawienia != value)
                {
                    item.DataWystawienia = value;
                    base.OnPropertyChanged(() => DataWystawienia);
                }
            }
        }
        public DateTime? DataSprzedazy
        {
            get
            {
                return item.DataSprzedazy;
            }
            set
            {
                if (item.DataSprzedazy != value)
                {
                    item.DataSprzedazy = value;
                    base.OnPropertyChanged(() => DataSprzedazy);
                }
            }
        }
        private string _Kod;
        public string Kod
        {
            get
            {
                return _Kod;
            }
            set
            {
                if (_Kod != value)
                {
                    _Kod = value;
                    base.OnPropertyChanged(() => Kod);
                }
            }
        }
        private string _Nazwa;
        public string Nazwa
        {
            get
            {
                return _Nazwa;
            }
            set
            {
                if (_Nazwa != value)
                {
                    _Nazwa = value;
                    base.OnPropertyChanged(() => Nazwa);
                }
            }
        }
        private string _Nip;
        public string Nip
        {
            get
            {
                return _Nip;
            }
            set
            {
                if (_Nip != value)
                {
                    _Nip = value;
                    base.OnPropertyChanged(() => Nip);
                }
            }
        }
        private string _Regon;
        public string Regon
        {
            get
            {
                return _Regon;
            }
            set
            {
                if (_Regon != value)
                {
                    _Regon = value;
                    base.OnPropertyChanged(() => Regon);
                }
            }
        }
        private string _KontrahentAdres;
        public string KontrahentAdres
        {
            get
            {
                return _KontrahentAdres;
            }
            set
            {
                if (_KontrahentAdres != value)
                {
                    _KontrahentAdres = value;
                    base.OnPropertyChanged(() => KontrahentAdres);
                }
            }
        }
        private string _AdresUlica;
        public string AdresUlica
        {
            get
            {
                return _AdresUlica;
            }
            set
            {
                if (_AdresUlica != value)
                {
                    _AdresUlica = value;
                    base.OnPropertyChanged(() => AdresUlica);
                }
            }
        }
        private string _AdresNrDomu;
        public string AdresNrDomu
        {
            get
            {
                return _AdresNrDomu;
            }
            set
            {
                if (_AdresNrDomu != value)
                {
                    _AdresNrDomu = value;
                    base.OnPropertyChanged(() => AdresNrDomu);
                }
            }
        }
        private string _AdresNrLokalu;
        public string AdresNrLokalu
        {
            get
            {
                return _AdresNrLokalu;
            }
            set
            {
                if (_AdresNrLokalu != value)
                {
                    _AdresNrLokalu = value;
                    base.OnPropertyChanged(() => AdresNrLokalu);
                }
            }
        }
        private string _AdresKodPocztowy;
        public string AdresKodPocztowy
        {
            get
            {
                return _AdresKodPocztowy;
            }
            set
            {
                if (_AdresKodPocztowy != value)
                {
                    _AdresKodPocztowy = value;
                    base.OnPropertyChanged(() => AdresKodPocztowy);
                }
            }
        }
        private string _AdresMiasto;
        public string AdresMiasto
        {
            get
            {
                return _AdresMiasto;
            }
            set
            {
                if (_AdresMiasto != value)
                {
                    _AdresMiasto = value;
                    base.OnPropertyChanged(() => AdresMiasto);
                }
            }
        }
        private string _AdresWojewodztwoNazwa;
        public string AdresWojewodztwoNazwa
        {
            get
            {
                return _AdresWojewodztwoNazwa;
            }
            set
            {
                if (_AdresWojewodztwoNazwa != value)
                {
                    _AdresWojewodztwoNazwa = value;
                    base.OnPropertyChanged(() => AdresWojewodztwoNazwa);
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

                if (name == "Numer")
                {
                    komunikat = StringValidator.SprawdzCzyNrToInt(this.Numer);
                }
                if (name == "dataSprzedazy" && name == "DataWystawienia")
                {
                    komunikat = BusinessValidator.CzyDataSprzedazyJestWiekszaOdDatyWystawienia(this.DataSprzedazy, this.DataWystawienia);
                }
                return komunikat;
            }
        }
        //dodajemy 
        public override bool IsValid()
        {
            if (this["rabat"] == null && this["Numer"] == null)
                return true;
            return false;
        }
        #endregion
        #region  Helpers
        //to jest metoda która pobiera z bazy wszytskie pozycje tej faktury
        public override void Load()
        {
            List = new ObservableCollection<PozycjaFakturyForAllView>
            (
                from pozycja in item.PozycjaFaktury //to daje to samo co WHERE, to pobiera pozycje tej faktury w której jesteśmy
                select new PozycjaFakturyForAllView

                {
                   
                    UslugaNazwa = pozycja.UslugaKontrahent.Nazwa,
                    Cena = pozycja.Cena,
                    Rabat = pozycja.Rabat,
                    Ilosc = pozycja.Ilosc,
                }
                );
        }
 
       private void addPozycjaFaktury(PozycjaFaktury pozycjaFaktury)
        {
            //tworzymy nową pozycję faktury
            PozycjaFaktury nowa = new PozycjaFaktury();
            //wypelniamy jej dane
            nowa.IDUslugi = pozycjaFaktury.IDUslugi;
            nowa.UslugaKontrahent = gabinetEntities.UslugaKontrahent.Find(nowa.IDUslugi);
            nowa.Ilosc = pozycjaFaktury.Ilosc;
            nowa.Rabat = pozycjaFaktury.Rabat;
            nowa.Cena = pozycjaFaktury.Cena;
            //dodajemy do lokalnej kolekcji
            gabinetEntities.PozycjaFaktury.Add(nowa);
            //łączymy z aktualną fakturą
            item.PozycjaFaktury.Add(nowa);
            List.Add(
                new PozycjaFakturyForAllView()
                {           
                    UslugaNazwa = nowa.UslugaKontrahent.Nazwa,
                    Cena = nowa.Cena,
                    Rabat = nowa.Rabat,
                    Ilosc = nowa.Ilosc
                }
             );
        }

        private void getWybranyKontrahent(KontrahenciForAllView kontrahent)
        {
            //uzupełniamy dane kontrahenta w fakturze na bazie danych kontrahenta ktory przyjdzie z okna ze wszytskimi konttrahentami
            IDKontrahenta = kontrahent.IDKontrahenta;
            Kod = kontrahent.Kod;
            Nazwa = kontrahent.Nazwa;
            Nip = kontrahent.Nip;
            Regon = kontrahent.Regon;
            KontrahentAdres = kontrahent.KontrahentAdres;
        }

        public override void Save()
        {
            //najpierw dodajemy towar do lokalnej kolekcji towarów
            gabinetEntities.Faktura.Add(item);
            //a następnie zapisujemy zmiany w bazie danych
             gabinetEntities.SaveChanges();
        }
        #endregion Heplpers
    }
}
