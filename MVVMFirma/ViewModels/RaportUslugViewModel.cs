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
    public class RaportUslugViewModel: WorkspaceViewModel
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
        private int _IDUslugi;
        public int IDUslugi
        {
            get
            {
                return _IDUslugi;
            }
            set
            {
                if (value != _IDUslugi)
                {
                    _IDUslugi = value;
                    OnPropertyChanged(() => IDUslugi);
                }
            }
        }

        public IQueryable<ComboBoxKeyAndValue> UslugaKontrahentComboBoxItems
        {
            get
            {
                //
                return new UslugaKontrahnetU(gabinetEntities).GetUslugiKontrahentComboBoxItems();
            }
        }

        private decimal? _Zysk;
        public decimal? Zysk
        {
            get
            {
                return _Zysk;
            }
            set
            {
                if (value != _Zysk)
                {
                    _Zysk = value;
                    OnPropertyChanged(() => Zysk);
                }
            }
        }

        public RaportUslugViewModel()
        {
            base.DisplayName = "Raport Uslug";
            gabinetEntities = new GabinetEntities4();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
            Zysk = 0;
        }

        #region Commands
        //
        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                {
                    _ObliczCommand = new BaseCommand(() => obliczZyskClick());
                }
                return _ObliczCommand;
            }
        }
        #endregion
        #region Helpers
        private void obliczZyskClick()
        {
            //to jest 
            Zysk = new ZyskU(gabinetEntities).ZyskOkresUsluga(IDUslugi, DataOd, DataDo);
        }
        #endregion
    }
}
