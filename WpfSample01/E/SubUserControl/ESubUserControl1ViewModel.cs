using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;

namespace WpfSample01.E.SubUserControl
{
    public class ESubUserControl1ViewModel : ViewModelBase
    {
        public ESubUserControl1ViewModel()
        {
            OnLoadedCommand = new DelegateCommand(OnLoadedCommandExecute, OnLoadedCommandCanEnable);
            ButtonClickCommand = new DelegateCommand(ButtonClickCommandExecute, ButtonClickCommandCanEnable);
        }

        private ICurrentWindowService _currentWindowService
        {
            get => GetService<ICurrentWindowService>();
        }

        public EView ViewClass
        {
            get => (_currentWindowService as CurrentWindowService)?.ActualWindow as EView;
        }

        #region Property

        private string _userName;

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value, nameof(UserName));
        }

        #endregion

        #region Event

        public ICommand OnLoadedCommand { get; private set; }

        private void OnLoadedCommandExecute()
        {
            // MessageBox.Show("OnLoad");
        }

        private bool OnLoadedCommandCanEnable()
        {
            return true;
        }

        public ICommand ButtonClickCommand { get; private set; }

        private void ButtonClickCommandExecute()
        {
            MessageBox.Show("Test");
        }

        private bool ButtonClickCommandCanEnable()
        {
            return true;
        }

        #endregion
    }
}