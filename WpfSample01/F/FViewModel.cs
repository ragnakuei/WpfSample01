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

        private double _axisX;

        public double AxisX
        {
            get => _axisX;
            set => SetValue(ref _axisX, value);
        }

        private double _axisY;

        public double AxisY
        {
            get => _axisY;
            set => SetValue(ref _axisY, value);
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