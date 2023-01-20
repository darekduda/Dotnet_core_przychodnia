using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class WszyscyKontrahenciViewModel : WszystkieViewModel<KontrahenciForAllView>
    {
      

        #region Constructor

        public WszyscyKontrahenciViewModel()
            :base()
        {
            base.DisplayName = "Wszyscy kontrahenci";
        }
        #endregion
        #region Properties
        private KontrahenciForAllView _WybranyKontrahent;
        public KontrahenciForAllView WybranyKontrahent
        {
            get
            {
                return _WybranyKontrahent;
            }
            set
            {
                if (_WybranyKontrahent != value)
                {
                    _WybranyKontrahent = value;
                    //jak klikniemy w datagridzie na wybranego kontrhaneta to wywola się set WybranegoKontrahneta
                    //i należy tego kontrahenta messengerem wysłać do okna z nową fakturą 
                    Messenger.Default.Send(_WybranyKontrahent);
                    //po wybraniu kontrahenta zamykam oknno
                    OnRequestClose();
                }
            }
        }

        public override void load()
        {
            List = new ObservableCollection<KontrahenciForAllView>

                (
                    //zapytanie pobiera z bazy danych wszystkie faktury i zapisuje je jako FakturyForAllView
                    from kontrahent in gabinetEntities.Kontrahent //dla kazdej faktury z bazy danych faktur tworzymy nowa
                                                        //fakture for all view
                    select new KontrahenciForAllView
                    {
                        IDKontrahenta = kontrahent.IDKontrahenta,
                        IDAdresu = kontrahent.IDAdresu,
                        OsobaKontaktowa = kontrahent.OsobaKontaktowa,
                        Nazwa = kontrahent.Nazwa,
                        Nip = kontrahent.Nip,
                        Regon = kontrahent.Regon,
                        Kod = kontrahent.Kod,
                        AdresEmail = kontrahent.AdresEmail,
                        NrTelefonu = kontrahent.NrTelefonu,
                        KontrahentAdres =
                        "ul. "
                        + kontrahent.Adres.Ulica + " "
                        + kontrahent.Adres.NrDomu + "/"
                        + kontrahent.Adres.NrLokalu + " " 
                        + kontrahent.Adres.Miasto + " "
                         + kontrahent.Adres.KodPocztowy + " ",
                    }
                );
        }
        #endregion
        #region Sort and Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa", "Kod", "NIP", "Cena malejąco", "Nazwa i Cena" };

        }

        public override void Sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<KontrahenciForAllView>(List.OrderBy(item => item.Nazwa));
            if (SortField == "Kod")
                List = new ObservableCollection<KontrahenciForAllView>(List.OrderBy(item => item.Kod));
            if (SortField == "NIP")
                List = new ObservableCollection<KontrahenciForAllView>(List.OrderBy(item => item.Nip));
            if (SortField == "Osoba kontaktowa")
                List = new ObservableCollection<KontrahenciForAllView>(List.OrderBy(item => item.OsobaKontaktowa));
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa", "Osoba kontaktowa" };
        }

        public override void Find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<KontrahenciForAllView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Osoba kontaktowa")
                List = new ObservableCollection<KontrahenciForAllView>(List.Where(item => item.OsobaKontaktowa != null && item.OsobaKontaktowa.StartsWith(FindTextBox)));
        }

        #endregion

        public override void del()
        {

        }

        public override void modify()
        {
        }
    }
}

