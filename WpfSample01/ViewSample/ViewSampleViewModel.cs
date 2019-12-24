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

        public I.IView ViewClass
        {
            get => (_currentWindowService as CurrentWindowService)?.ActualWindow as I.IView;
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