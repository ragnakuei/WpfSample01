using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;

namespace WpfSample01.F
{
    public class FViewModel : ViewModelBase
    {
        public FViewModel()
        {
            OnLoadedCommand = new DelegateCommand(OnLoadedCommandExecute, OnLoadedCommandCanEnable);
        }

        private ICurrentWindowService _currentWindowService
        {
            get => GetService<ICurrentWindowService>();
        }

        public FView ViewClass
        {
            get => (_currentWindowService as CurrentWindowService)?.ActualWindow as FView;
        }

        public double AxisX
        {
            get => GetValue<double>();
            set => SetValue(value);
        }

        public double AxisY
        {
            get => GetValue<double>();
            set => SetValue(value);
        }

        #region View Related Event

        public ICommand OnLoadedCommand { get; }

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