using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class WszystkieFakturyViewModel : WszystkieViewModel<FakturaForAllView>
    {
        #region Constructor
        public WszystkieFakturyViewModel()
            : base()
        {
            base.DisplayName = "Wszystkie faktury";
        }
        #endregion Constructor
        #region Helpers
        public override void del()
        {
            FakturaForAllView fakturaSelectedListItem = List.Single(f => f.IDFaktury == SelectedItem.IDFaktury); // znajdz jeden element f listy List,
            // gdzie IDFaktury jest równe Id wybranego elementu na widoku

            //FakturaForAllView fakturaSelectedListItem = null;
            //foreach(FakturaForAllView f in List)
            //{
            //    if(f.IDFaktury == SelectedItem.IDFaktury)
            //    {
            //        fakturaSelectedListItem = f;
            //        break;
            //    }
            //}
            Faktura faktura = gabinetEntities.Faktura.Single(f => f.IDFaktury == fakturaSelectedListItem.IDFaktury);
            gabinetEntities.Faktura.Remove(faktura); // usuwa z bazy
            gabinetEntities.SaveChanges();
            List.Remove(fakturaSelectedListItem); // usuwa z listy na widoku
        }

        public override void modify()
        {
            
        }

        //metoda load pobierze z bazy wszystkie towary i przypisze je do listy 
        public override void load()
        {
            //za pomocą obiektu reprezentującego całą bazę danych o nazwie fakturyEntities pobieram wszystkie 
            //rekordy z tabeli Towary i zamieniam je na ObservableCollection
            List = new ObservableCollection<FakturaForAllView>
                (
                    //zapytanie pobiera z bazy danych wszystkie faktury i zapisuje je jako FakturyForAllView
                    from faktura in gabinetEntities.Faktura //dla kazdej faktury z bazy danych faktur tworzymy nowa
                                                            //fakture for all view
                    select new FakturaForAllView
                    {//i wypelniamy jej dane
                        IDFaktury = faktura.IDFaktury,
                        Numer = faktura.Numer,
                        TerminPlatnosci = faktura.TerminPlatnosci,
                        DataWystawienia = faktura.DataWystawienia,
                        KontrahentNazwa = faktura.Kontrahent.Nazwa,
                        KontrahentNip = faktura.Kontrahent.Nip,
                        KontrahentAdres =
                        "ul. "
                        + faktura.Kontrahent.Adres.Ulica + " "
                        + faktura.Kontrahent.Adres.NrDomu + "/"
                        + faktura.Kontrahent.Adres.NrLokalu + " "
                        + faktura.Kontrahent.Adres.KodPocztowy + " "
                        + faktura.Kontrahent.Adres.Miasto,

                        SposobPlatnosciNazwa = faktura.SposobPlatnosci.Nazwa,
                        StatusFakturyNazwa = faktura.StatusFaktury.Nazwa,

                    }
                );
        }
        #endregion Helpers

        #region Sort and Find

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Numer", "Nazwa kontrahenta", "Termin płatności", "Kwota faktury malejąco"};

        }

        public override void Sort()
        {
            if (SortField == "Numer")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.Numer));
            if (SortField == "Nazwa kontrahenta")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.KontrahentNazwa));
            if (SortField == "Termin płatnośc")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.TerminPlatnosci));
         //   if (SortField == "Kwota faktury malejąco")
         //       List = new ObservableCollection<FakturaForAllView>(List.OrderByDescending(item => item.));
            //if (SortField == "Kod")
            //    List = new ObservableCollection<Towary>(List.OrderBy(item => item.Kod));
            //if (SortField == "Cena")
            //    List = new ObservableCollection<Towary>(List.OrderBy(item => item.Cena));
            //if (SortField == "Nazwa i Cena")
            //    List = new ObservableCollection<Towary>(List.OrderBy(item => item.Nazwa).ThenBy(item => item.Cena));
            //if (SortField == "Cena malejąco")
            //    List = new ObservableCollection<Towary>(List.OrderByDescending(item => item.Cena));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa kontrahenta", "Data wystawienia" };
        }

        public override void Find()
        {
            //if (FindField == "Nazwa kontrahenta")
            //    List = new ObservableCollection<Towary>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            //if (FindField == "Data wystawienia")
            //    List = new ObservableCollection<Towary>(List.Where(item => item.Kod != null && item.Kod.StartsWith(FindTextBox)));
        }




        #endregion
    }
}

