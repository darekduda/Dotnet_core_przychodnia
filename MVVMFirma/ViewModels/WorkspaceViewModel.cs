using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVMFirma.Helper;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    //to jest klasa z której beda dziedziczyc wszytskie viewmodele zakladek w projekcie. Kazda zakladka w projelcie w warstwie 
    //viewModel powinna dziedziczyć z workspaceViewModel
    public abstract class WorkspaceViewModel : BaseViewModel
    {
        // kazda zakladka zawiera displayName odziedziczony z BaseViewModel oraz command do zamknięcia okna ktora wywoluje funkcję
        // onreqestClose
        #region Fields
        private BaseCommand _CloseCommand;
        #endregion 

        #region Constructor
        public WorkspaceViewModel()
        {
        }
        #endregion 

        #region CloseCommand
        public ICommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                    _CloseCommand = new BaseCommand(() => this.OnRequestClose());
                return _CloseCommand;
            }
        }
        #endregion 

        #region RequestClose [event]
        public event EventHandler RequestClose;
        protected void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion 
    }
}
