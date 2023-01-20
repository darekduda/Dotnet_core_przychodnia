using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class WszystkieKrajeViewModel : WszystkieViewModel<KrajeForAllView>
    {
        public WszystkieKrajeViewModel()
         : base()
        {
            base.DisplayName = "Wszystkie kraje";
        }
        public override void load()
        {
            List = new ObservableCollection<KrajeForAllView>

                (
                    //zapytanie pobiera z bazy danych wszystkie faktury i zapisuje je jako FakturyForAllView
                    from kraj in gabinetEntities.Kraj //dla kazdej faktury z bazy danych faktur tworzymy nowa
                                                          //fakture for all view
                    select new KrajeForAllView
                    {
                        IDKraju = kraj.IDKraju,
                        Nazwa = kraj.Nazwa,
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
                List = new ObservableCollection<KrajeForAllView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa" };

        }

        public override void Sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<KrajeForAllView>(List.OrderBy(item => item.Nazwa));
        }

        public override void del()
        {
            KrajeForAllView krajSelectedListItem = List.Single(item => item.IDKraju == SelectedItem.IDKraju); // znajdz jeden element f listy List,
            Kraj kraj = gabinetEntities.Kraj.Single(item => item.IDKraju == krajSelectedListItem.IDKraju);
            gabinetEntities.Kraj.Remove(kraj); // usuwa z bazy
            gabinetEntities.SaveChanges();
            List.Remove(krajSelectedListItem); // usuwa z listy na widoku
        }

        public override void modify()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

