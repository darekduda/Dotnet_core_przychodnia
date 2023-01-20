using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MVVMFirma.Models.Entities;


namespace MVVMFirma.ViewModels
{
    public class WszystkieOddzialyNFZViewModel : WszystkieViewModel<OddzialNFZForAllView>
    { 
        public WszystkieOddzialyNFZViewModel()
          : base()
    {
        base.DisplayName = "Wszystkie oddziały NFZ";
    }
    public override void load()
    {
        List = new ObservableCollection<OddzialNFZForAllView>

            (
                //zapytanie pobiera z bazy danych wszystkie faktury i zapisuje je jako FakturyForAllView
                from item in gabinetEntities.OddziałNFZ //dla kazdej faktury z bazy danych faktur tworzymy nowa
                                                      //fakture for all view
                    select new OddzialNFZForAllView
                {
                    IDOddzialuNFZ = item.IDOddziałuNFZ,
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
            List = new ObservableCollection<OddzialNFZForAllView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
    }

    public override List<string> GetComboboxSortList()
    {
        return new List<string> { "Nazwa" };

    }

    public override void Sort()
    {
        if (SortField == "Nazwa")
            List = new ObservableCollection<OddzialNFZForAllView>(List.OrderBy(item => item.Nazwa));
    }

    public override void del()
        {
            OddzialNFZForAllView oddzialSelectedListItem = List.Single(item => item.IDOddzialuNFZ == SelectedItem.IDOddzialuNFZ); // znajdz jeden element f listy List,
            OddziałNFZ oddzial = gabinetEntities.OddziałNFZ.Single(item => item.IDOddziałuNFZ == oddzialSelectedListItem.IDOddzialuNFZ);
            gabinetEntities.OddziałNFZ.Remove(oddzial); // usuwa z bazy           
            gabinetEntities.SaveChanges();
            List.Remove(oddzialSelectedListItem); // usuwa z listy na widokuthrow new NotImplementedException();
        }

    public override void modify()
    {
        throw new NotImplementedException();
    }
    #endregion
}
}
