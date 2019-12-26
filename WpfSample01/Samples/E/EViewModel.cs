using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using WpfSample01.Samples.E.SubUserControl;

namespace WpfSample01.Samples.E
{
    public class EViewModel : ViewModelBase
    {
        private ESubUserControl1ViewModel _childUserControlViewModel;

        public EViewModel()
        {
            OnLoadedCommand = new DelegateCommand(OnLoadedCommandExecute, OnLoadedCommandCanEnable);
            TextBoxInputCommand = new DelegateCommand<string>(TextBoxInputCommandExecute, TextBoxInputCommandCanEnable);
        }

        private ICurrentWindowService _currentWindowService
        {
            get => GetService<ICurrentWindowService>();
        }

        public EView ViewClass
        {
            get => (_currentWindowService as CurrentWindowService)?.ActualWindow as EView;
        }

        #region View Related Event

        public ICommand OnLoadedCommand { get; }

        private void OnLoadedCommandExecute()
        {
            _childUserControlViewModel = new ESubUserControl1ViewModel();

            var childUserControl = new ESubUserControl1 { DataContext = _childUserControlViewModel };

            ViewClass.rootLayout.Children.Add(childUserControl);
        }

        private bool OnLoadedCommandCanEnable()
        {
            return true;
        }

        public ICommand<string> TextBoxInputCommand { get; }

        private void TextBoxInputCommandExecute(string value)
        {
            _childUserControlViewModel.UserName = value;
        }

        private bool TextBoxInputCommandCanEnable(string value)
        {
            return true;
        }

        #endregion
    }
}