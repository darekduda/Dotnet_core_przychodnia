using MVVMFirma.Models.EntitiesForView;
using System;
using MVVMFirma.Models.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    class WszyscyPracownicyViewModel : WszystkieViewModel<PracownikForAllView>
    {
        public WszyscyPracownicyViewModel()
       : base()
        {
            base.DisplayName = "Pracownicy";
        }
        public override void load()
        {
            List = new ObservableCollection<PracownikForAllView>

                (
                    //zapytanie pobiera z bazy danych wszystkie faktury i zapisuje je jako FakturyForAllView
                    from item in gabinetEntities.Pracownik //dla kazdej faktury z bazy danych faktur tworzymy nowa
                                                                  //fakture for all view
                    select new PracownikForAllView
                    {
                        IDPracownika = item.IDPracownika,
                        Imie = item.Imie,
                        Nazwisko = item.Nazwisko,
                        Stanowisko = item.Stanowisko,
                    }
                );
        }

        #region Sort and Find
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa" };
        }

        public override void Find()
        {
            if (FindField == "Nazwisko")
                List = new ObservableCollection<PracownikForAllView>(List.Where(item => item.Nazwisko != null && item.Nazwisko.StartsWith(FindTextBox)));
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa" };

        }

        public override void Sort()
        {
            if (SortField == "Nazwisko")
                List = new ObservableCollection<PracownikForAllView>(List.OrderBy(item => item.Nazwisko));
            if (SortField == "Stanowisko")
                List = new ObservableCollection<PracownikForAllView>(List.OrderBy(item => item.Stanowisko));

        }

        public override void del()
        {
            PracownikForAllView pracownikSelectedListItem = List.Single(item => item.IDPracownika == SelectedItem.IDPracownika); // znajdz jeden element f listy List,
            Pracownik pracownik = gabinetEntities.Pracownik.Single(item => item.IDPracownika == pracownikSelectedListItem.IDPracownika);
            gabinetEntities.Pracownik.Remove(pracownik); // usuwa z bazy
            gabinetEntities.SaveChanges();
            List.Remove(pracownikSelectedListItem); // usuwa z listy na widoku
        }

        public override void modify()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
