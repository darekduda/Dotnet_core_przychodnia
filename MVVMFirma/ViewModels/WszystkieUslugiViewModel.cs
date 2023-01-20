using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class WszystkieUslugiViewModel : WszystkieViewModel<UslugiForAllView>
    {
        public WszystkieUslugiViewModel()
          : base()
        {
            base.DisplayName = "Uslugi";
        }
        public override void load()
        {
            List = new ObservableCollection<UslugiForAllView>

                (
                    //zapytanie pobiera z bazy danych wszystkie faktury i zapisuje je jako FakturyForAllView
                    from usluga in gabinetEntities.Usluga //dla kazdej faktury z bazy danych faktur tworzymy nowa
                                                        //fakture for all view
                    select new UslugiForAllView
                    {
                        IDUslugi = usluga.IDUslugi,
                        Nazwa = usluga.Nazwa,
                    }
                );
        }

        #region Sort and Find
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa"};
        }

        public override void Find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<UslugiForAllView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa"};

        }

        public override void Sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<UslugiForAllView>(List.OrderBy(item => item.Nazwa));
        }

        public override void del()
        {
            UslugiForAllView uslugaSelectedListItem = List.Single(item => item.IDUslugi == SelectedItem.IDUslugi); // znajdz jeden element f listy List,
            Usluga usluga = gabinetEntities.Usluga.Single(item => item.IDUslugi == uslugaSelectedListItem.IDUslugi);
            gabinetEntities.Usluga.Remove(usluga); // usuwa z bazy           
            gabinetEntities.SaveChanges();
            List.Remove(uslugaSelectedListItem); // usuwa z listy na widoku
        }

        public override void modify()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
