using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;

namespace WpfSample01.Samples.E.SubUserControl
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

        private string _userName;
        public string UserName
        {
            get => _userName;
            set => SetValue(ref _userName, value);
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