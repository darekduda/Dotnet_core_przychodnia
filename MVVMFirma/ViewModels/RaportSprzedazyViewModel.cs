using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class RaportSprzedazyViewModel: WorkspaceViewModel
    {
        private GabinetEntities4 gabinetEntities;

        private DateTime _DataOd;
        public DateTime DataOd
        {
            get
            {
                return _DataOd;
            }
            set
            {
                if (value != _DataOd)
                {
                    _DataOd = value;
                    OnPropertyChanged(() => DataOd);
                }
            }
        }
        private DateTime _DataDo;
        public DateTime DataDo
        {
            get
            {
                return _DataDo;
            }
            set
            {
                if (value != _DataDo)
                {
                    _DataDo = value;
                    OnPropertyChanged(() => DataDo);
                }
            }
        }
        private int _IDSkierowania;
        public int IDSkierowania
        {
            get
            {
                return _IDSkierowania;
            }
            set
            {
                if (value != _IDSkierowania)
                {
                    _IDSkierowania = value;
                    OnPropertyChanged(() => IDSkierowania);
                }
            }
        }

        //public IQueryable<ComboBoxKeyAndValue> SkierowanieComboBoxItems
        //{
        //    get
        //    {
        //        //
        //        return new SkierowanieB(gabinetEntities).GetSkierowanieComboBoxItems();
        //    }
        //}

        private decimal? _RefundacjaNFZ;
        public decimal? RefundacjaNFZ
        {
            get
            {
                return _RefundacjaNFZ;
            }
            set
            {
                if (value != _RefundacjaNFZ)
                {
                    _RefundacjaNFZ = value;
                    OnPropertyChanged(() => RefundacjaNFZ);
                }
            }
        }

        public RaportSprzedazyViewModel()
        {
            base.DisplayName = "Raport Wizyt";
            gabinetEntities = new GabinetEntities4();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
            RefundacjaNFZ = 0;
        }

        #region Commands
        //
        private BaseCommand _ObliczCommand;
        //public ICommand ObliczCommand
        //{
        //    get
        //    {
        //        if (_ObliczCommand == null)
        //        {
        //            _ObliczCommand = new BaseCommand(() => obliczRefundacjeClick());
        //        }
        //        return _ObliczCommand;
        //    }
        //}
        #endregion
        #region Helpers
        //private void obliczRefundacjeClick()
        //{
        //    //to jest 
        //    RefundacjaNFZ = new Refundacja(gabinetEntities).RefundowaneWizyty(IDSkierowania, DataOd, DataDo);
        //}
        #endregion

    }
}
