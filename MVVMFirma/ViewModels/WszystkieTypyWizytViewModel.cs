using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MVVMFirma.Models.Entities;

namespace MVVMFirma.ViewModels
{
    public class WszystkieTypyWizytViewModel : WszystkieViewModel<TypyWizytForAllView>
    {
        public WszystkieTypyWizytViewModel()
       : base()
        {
            base.DisplayName = "Typy wizyt";
        }
        public override void load()
        {
            List = new ObservableCollection<TypyWizytForAllView>

                (
                    //zapytanie pobiera z bazy danych wszystkie faktury i zapisuje je jako FakturyForAllView
                    from item in gabinetEntities.TypWizyty //dla kazdej faktury z bazy danych faktur tworzymy nowa
                                                                //fakture for all view
                    select new TypyWizytForAllView
                    {
                        IDTypuWizyty = item.IDTypuWizyty,
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
                List = new ObservableCollection<TypyWizytForAllView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa" };

        }

        public override void Sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<TypyWizytForAllView>(List.OrderBy(item => item.Nazwa));
        }

        public override void del()
        {
            TypyWizytForAllView typWizytySelectedListItem = List.Single(item => item.IDTypuWizyty == SelectedItem.IDTypuWizyty); // znajdz jeden element f listy List,
            TypWizyty typWizyty = gabinetEntities.TypWizyty.Single(item => item.IDTypuWizyty == typWizytySelectedListItem.IDTypuWizyty);
            gabinetEntities.TypWizyty.Remove(typWizyty); // usuwa z bazy           
            gabinetEntities.SaveChanges();
            List.Remove(typWizytySelectedListItem); // usuwa z listy na widoku
        }

        public override void modify()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
