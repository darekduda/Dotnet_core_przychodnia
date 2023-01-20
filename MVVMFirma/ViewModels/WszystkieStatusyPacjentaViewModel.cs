using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class WszystkieStatusyPacjentaViewModel : WszystkieViewModel<StatusPacjentaForAllView>
    {
        public WszystkieStatusyPacjentaViewModel()
       : base()
        {
            base.DisplayName = "Wszystkie statusy pacjenta";
        }
        public override void load()
        {
            List = new ObservableCollection<StatusPacjentaForAllView>

                (
                    //zapytanie pobiera z bazy danych wszystkie faktury i zapisuje je jako FakturyForAllView
                    from item in gabinetEntities.StatusPacjenta //dla kazdej faktury z bazy danych faktur tworzymy nowa
                                                                 //fakture for all view
                    select new StatusPacjentaForAllView
                    {
                        IDStatusuPacjenta = item.IDStatusuPacjenta,
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
                List = new ObservableCollection<StatusPacjentaForAllView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa" };

        }

        public override void Sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<StatusPacjentaForAllView>(List.OrderBy(item => item.Nazwa));
        }

        public override void del()
        {
            StatusPacjentaForAllView statusPacjentaSelectedListItem = List.Single(item => item.IDStatusuPacjenta == SelectedItem.IDStatusuPacjenta); // znajdz jeden element f listy List,
            StatusPacjenta statusPacjenta = gabinetEntities.StatusPacjenta.Single(item => item.IDStatusuPacjenta == statusPacjentaSelectedListItem.IDStatusuPacjenta);
            gabinetEntities.StatusPacjenta.Remove(statusPacjenta); // usuwa z bazy           
            gabinetEntities.SaveChanges();
            List.Remove(statusPacjentaSelectedListItem); // usuwa z listy na widoku
        }

        public override void modify()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
