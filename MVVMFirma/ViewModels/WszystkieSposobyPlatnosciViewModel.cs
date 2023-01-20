using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MVVMFirma.Models.Entities;


namespace MVVMFirma.ViewModels
{
    public class WszystkieSposobyPlatnosciViewModel : WszystkieViewModel<SposobyPlatnosciForAllView>
    {  
        public WszystkieSposobyPlatnosciViewModel()
          : base()
        {
            base.DisplayName = "Wszystkie sposoby płatności";
        }
        public override void load()
        {
            List = new ObservableCollection<SposobyPlatnosciForAllView>

                (
                    //zapytanie pobiera z bazy danych wszystkie faktury i zapisuje je jako FakturyForAllView
                    from item in gabinetEntities.SposobPlatnosci //dla kazdej faktury z bazy danych faktur tworzymy nowa
                                                            //fakture for all view
                select new SposobyPlatnosciForAllView
                    {
                        IDSposobuPlatnosci = item.IDSposobuPlatnosci,
                        Nazwa = item.Nazwa,
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
            if (FindField == "Nazwa")
                List = new ObservableCollection<SposobyPlatnosciForAllView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa" };

        }

        public override void Sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<SposobyPlatnosciForAllView>(List.OrderBy(item => item.Nazwa));
        }

        public override void del()
        {
            SposobyPlatnosciForAllView sposobPlatnosciSelectedListItem = List.Single(item => item.IDSposobuPlatnosci == SelectedItem.IDSposobuPlatnosci); // znajdz jeden element f listy List,
            SposobPlatnosci sposobPlatnosci = gabinetEntities.SposobPlatnosci.Single(item => item.IDSposobuPlatnosci == sposobPlatnosciSelectedListItem.IDSposobuPlatnosci);
            gabinetEntities.SposobPlatnosci.Remove(sposobPlatnosci); // usuwa z bazy           
            gabinetEntities.SaveChanges();
            List.Remove(sposobPlatnosciSelectedListItem); // usuwa z listy na widoku
        }

        public override void modify()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
