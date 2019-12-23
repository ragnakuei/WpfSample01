using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using WpfSample01.ViewSample.ViewSampleChildView;

namespace WpfSample01.ViewSample
{
    public class ViewSampleViewModel : ViewModelBase
    {
        public ViewSampleViewModel()
        {
            OnLoadedCommand = new DelegateCommand(OnLoadedCommandExecute, OnLoadedCommandCanEnable);
        }

        private ICurrentWindowService _currentWindowService
        {
            get => GetService<ICurrentWindowService>();
        }

        public ViewSampleView ViewClass
        {
            get => (_currentWindowService as CurrentWindowService)?.ActualWindow as ViewSampleView;
        }

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

        #endregion
    }
}