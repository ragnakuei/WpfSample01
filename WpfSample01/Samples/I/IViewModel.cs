using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using WpfSample01.Common;
using WpfSample01.Helpers;
using WpfSample01.Samples.I.IChildView;

namespace WpfSample01.Samples.I
{
    public class IViewModel : ViewModelBase
    {

        public IViewModel()
        {
            OnLoadedCommand = new DelegateCommand(OnLoadedCommandExecute);
        }

        private ICurrentWindowService _currentWindowService
        {
            get => GetService<ICurrentWindowService>();
        }

        public IView ViewClass
        {
            get => (_currentWindowService as CurrentWindowService)?.ActualWindow as IView;
        }
        
        private string _textBoxValue = "Initial Value";
        public string TextBoxValue
        {
            get => _textBoxValue;
            set => SetValue(ref _textBoxValue, value, nameof(TextBoxValue));
        }

        private IMessageBoxService MessageBoxService
        {
            get => GetService<IMessageBoxService>();
        }

        private IChildViewModel ChildViewModel
        {
            get => ViewClass.ChildAView.GetDataContext<IChildAView, IChildViewModel>();
        }
        
        private IChildViewModel ChildBViewModel
        {
            get => ViewClass.ChildBView.GetDataContext<IChildBView, IChildViewModel>();
        }
        
        #region View Related Event

        public ICommand OnLoadedCommand { get; }

        private void OnLoadedCommandExecute()
        {
            ChildViewModel.TextBoxValueChange += ChildAViewUpdateTextBoxValue;
            ChildBViewModel.TextBoxValueChange += ChildBViewUpdateTextBoxValue;
        }

        private void ChildAViewUpdateTextBoxValue(object sender, NewValueEventArgs<string> e)
        {
            TextBoxValue = e.Value;
        }
        
        private void ChildBViewUpdateTextBoxValue(object sender, NewValueEventArgs<string> e)
        {
            TextBoxValue = e.Value;
        }

        #endregion
    }
}