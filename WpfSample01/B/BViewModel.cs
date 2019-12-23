using System;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;

namespace WpfSample01.B
{
    public class BViewModel : ViewModelBase
    {
        public string LabelValue { get; set; }

        public ICommand CloseWindow { get; set; }

        public BViewModel()
        {
            CloseWindow = new DelegateCommand(CloseWndowCommandExecute, CloseWindowCommandCanEnable);
        }

        private ICurrentWindowService _currentWindowService
        {
            get => GetService<ICurrentWindowService>();
        }

        private BView _viewClass
        {
            get => (_currentWindowService as CurrentWindowService)?.ActualWindow as BView;
        }

        private void CloseWndowCommandExecute()
        {
            LabelValue = (_viewClass.DataContext as BViewModel)?.LabelValue;
            _viewClass.Close();
        }

        private bool CloseWindowCommandCanEnable()
        {
            return true;
        }
    }
}