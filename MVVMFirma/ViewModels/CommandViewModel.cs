using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    //to jest klasa z ktoerej beda dziedziczyly wsyztskie viewmodele ktore sa skojarzone z elementami lewego menu bocznego 
    //operacje
    public class CommandViewModel : BaseViewModel
    {
        //kazde z menu bocznych operacje posiada displayname odziedziczone z base view model a ponadto command otwierajaca
        // zakladke
        #region Properties
        public ICommand Command { get; private set; }
        #endregion

        #region Constructor
        public CommandViewModel(string displayName, ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            this.DisplayName = displayName;
            this.Command = command;
        }
        #endregion

    }
}
