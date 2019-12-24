using System;
using System.Net.Mime;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using WpfSample01.Common;
using WpfSample01.Helpers;
using WpfSample01.I.IChildView;

namespace WpfSample01.I
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
        
        private string _textBoxValue;
        public string TextBoxValue
        {
            get => _textBoxValue;
            set => SetValue(ref _textBoxValue, value, nameof(TextBoxValue));
        }

        private IMessageBoxService MessageBoxService
        {
            get => GetService<IMessageBoxService>();
        }

        #region View Related Event

        public ICommand OnLoadedCommand { get; }

        private void OnLoadedCommandExecute()
        {
            // ViewClass.ChildAView.GetDataContext<IChildAView, IChildAViewModel>().TextBoxValueChange += ChildViewUpdateTextBoxValue;
            ViewClass.ChildBView.GetDataContext<IChildBView, IChildBViewModel>().TextBoxValueChange += ChildViewUpdateTextBoxValue;
        }

        private void ChildViewUpdateTextBoxValue(object sender, NewValueEventArgs<string> e)
        {
            TextBoxValue = e.Value;
        }

        #endregion
    }
}