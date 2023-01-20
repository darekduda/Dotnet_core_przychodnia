using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class WszystkieUslugiKontrahentaViewModel : WszystkieViewModel<UslugiKontrahentForAllView>
    {
        public WszystkieUslugiKontrahentaViewModel()
       : base()
        {
            base.DisplayName = "Usługi kontrahenta";
        }
        public override void load()
        {
            List = new ObservableCollection<UslugiKontrahentForAllView>

                (
                    //zapytanie pobiera z bazy danych wszystkie faktury i zapisuje je jako FakturyForAllView
                    from item in gabinetEntities.UslugaKontrahent //dla kazdej faktury z bazy danych faktur tworzymy nowa
                                                           //fakture for all view
                    select new UslugiKontrahentForAllView
                    {
                        IDUslugi = item.IDUslugi,
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
                List = new ObservableCollection<UslugiKontrahentForAllView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa" };

        }

        public override void Sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<UslugiKontrahentForAllView>(List.OrderBy(item => item.Nazwa));
        }

        public override void del()
        {
            UslugiKontrahentForAllView uslugaKontrahentaSelectedListItem = List.Single(item => item.IDUslugi == SelectedItem.IDUslugi); // znajdz jeden element f listy List,
            UslugaKontrahent uslugaKontrahenta = gabinetEntities.UslugaKontrahent.Single(item => item.IDUslugi == uslugaKontrahentaSelectedListItem.IDUslugi);
            gabinetEntities.UslugaKontrahent.Remove(uslugaKontrahenta); // usuwa z bazy           
            gabinetEntities.SaveChanges();
            List.Remove(uslugaKontrahentaSelectedListItem); // usuwa z listy na widoku
        }

        public override void modify()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
