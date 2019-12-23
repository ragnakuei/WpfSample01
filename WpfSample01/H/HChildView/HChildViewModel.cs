using System.Windows.Input;
using DevExpress.Mvvm;

namespace WpfSample01.H.HChildView
{
    public class HChildViewModel : ViewModelBase
    {
        public HChildViewModel()
        {
            ShowMessageCommand = new DelegateCommand(ShowMessage);
            OnLoadedCommand = new DelegateCommand(OnLoadedCommandExecute, OnLoadedCommandCanEnable);
        }

        private ICurrentWindowService _currentWindowService
        {
            get => GetService<ICurrentWindowService>();
        }

        IMessageBoxService MessageBoxService
        {
            get =>  GetService<IMessageBoxService>(ServiceSearchMode.PreferParents);
        }
        
        #region View Related Event

        public ICommand OnLoadedCommand { get; }

        private void OnLoadedCommandExecute()
        {
            MessageBoxService.Show("OnLoad");
        }

        private bool OnLoadedCommandCanEnable()
        {
            return true;
        }

        public ICommand ShowMessageCommand { get; }

        void ShowMessage()
        {
            MessageBoxService.Show("This is ChildView");
        }
        
        #endregion
    }
}