using System.Windows.Input;
using DevExpress.Mvvm;

namespace WpfSample01.H
{
    public class HViewModel : ViewModelBase
    {
        public HViewModel()
        {
            ShowMessageCommand = new DelegateCommand(ShowMessage);
            OnLoadedCommand = new DelegateCommand(OnLoadedCommandExecute);
        }

        private ICurrentWindowService _currentWindowService
        {
            get => GetService<ICurrentWindowService>();
        }

        IMessageBoxService MessageBoxService
        {
            get => GetService<IMessageBoxService>();
        }
        
        #region View Related Event

        public ICommand OnLoadedCommand { get; }

        private void OnLoadedCommandExecute()
        {
            // MessageBox.Show("OnLoad");
        }
        
        public ICommand ShowMessageCommand { get; }
        
        void ShowMessage() {
            
            MessageBoxService.Show("This is MainView!");
        }
        
        #endregion
    }
}