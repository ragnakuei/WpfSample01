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

        public string UserName
        {
            get => GetValue<string>();
            set => SetValue(value);
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

        #endregion
    }
}