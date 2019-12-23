using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;

namespace WpfSample01.H
{
    public class HViewModel : ViewModelBase
    {
        public HViewModel()
        {
            ShowMessageCommand = new DelegateCommand(ShowMessage);
            OnLoadedCommand = new DelegateCommand(OnLoadedCommandExecute, OnLoadedCommandCanEnable);
        }

        private ICurrentWindowService _currentWindowService
        {
            get => GetService<ICurrentWindowService>();
        }

        IMessageBoxService MessageBoxService { get { return GetService<IMessageBoxService>(); } }
        
        #region View Related Event

        public ICommand OnLoadedCommand { get; private set; }

        private void OnLoadedCommandExecute()
        {
            // MessageBox.Show("OnLoad");
        }

        private bool OnLoadedCommandCanEnable()
        {
            return true;
        }

        public ICommand ShowMessageCommand { get; private set; }
        
        void ShowMessage() {
            
            MessageBoxService.Show("This is MainView!");
        }
        
        #endregion
    }
}