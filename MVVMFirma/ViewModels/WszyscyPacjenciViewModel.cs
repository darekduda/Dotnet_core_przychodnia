using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class WszyscyPacjenciViewModel : WszystkieViewModel<PacjenciForAllView>
    {
        public WszyscyPacjenciViewModel()
            : base()
        {
            base.DisplayName = "Pacjenci";
        }
        #region Helpers
        //metoda load pobierze z bazy wszystkie towary i przypisze je do listy 
        public override void load()
        {
            //za pomocą obiektu reprezentującego całą bazę danych o nazwie fakturyEntities pobieram wszystkie 
            //rekordy z tabeli Towary i zamieniam je na ObservableCollection


            List = new ObservableCollection<PacjenciForAllView>
                (
                    //zapytanie pobiera z bazy danych wszystkie faktury i zapisuje je jako FakturyForAllView
                    from pacjent in gabinetEntities.Pacjent //dla kazdej faktury z bazy danych faktur tworzymy nowa
                                                            //fakture for all view
                    select new PacjenciForAllView
                    {
                        IDPacjenta = pacjent.IDPacjenta,
                        Imie = pacjent.Imie,
                        Nazwisko = pacjent.Nazwisko,
                        AdresEmail = pacjent.AdresEmail,
                        NrTelefonu = pacjent.NrTelefonu,
                      //  StatusPacjenta = pacjent.IDStatusPacjenta.Nazwa,

                        PacjentAdres= "ul. " + pacjent.Adres.Ulica+" "
                        + pacjent.Adres.NrLokalu + " "
                        + pacjent.Adres.NrDomu + " " 
                        + pacjent.Adres.KodPocztowy + " "
                        +pacjent.Adres.Miasto,

                        PacjentCzyAktywny = pacjent.StatusPacjenta.Nazwa,
                        PacjentNFZ = pacjent.OddziałNFZ.Nazwa,
                    }

                );
        }
        #endregion Helpers
        #region Sort and Find
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwisko"};
        }

        public override void Find()
        {
            if (FindField == "Nazwisko")
                List = new ObservableCollection<PacjenciForAllView>(List.Where(item => item.Nazwisko != null && item.Nazwisko.StartsWith(FindTextBox)));
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwisko", "Czy w terapii", "Odział NFZ"};

        }

        public override void Sort()
        {
            if (SortField == "Nazwisko")
                List = new ObservableCollection<PacjenciForAllView>(List.OrderBy(item => item.Nazwisko));
            if (SortField == "Czy w terapii")
                List = new ObservableCollection<PacjenciForAllView>(List.OrderBy(item => item.PacjentCzyAktywny));
            if (SortField == "Odział NFZ")
                List = new ObservableCollection<PacjenciForAllView>(List.OrderBy(item => item.PacjentNFZ));
        }


        #endregion
        public override void del()
        {
            var messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć dane??", "Uwaga!",
               MessageBoxButton.YesNo,
               MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                PacjenciForAllView pacjentSelectedListItem = List.Single(item => item.IDPacjenta == SelectedItem.IDPacjenta); // znajdz jeden element f listy List,
                Pacjent pacjent = gabinetEntities.Pacjent.Single(item => item.IDPacjenta == pacjentSelectedListItem.IDPacjenta);
                gabinetEntities.Pacjent.Remove(pacjent); // usuwa z bazy
                gabinetEntities.SaveChanges();
                List.Remove(pacjentSelectedListItem); // usuwa z listy na widoku
            }
            else
            {
                return;
            }
        }

        public override void modify()
        {
            throw new NotImplementedException();
        }
    }
}