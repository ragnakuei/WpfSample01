using System;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using WpfSample01.Models;

namespace WpfSample01.Samples.C
{
    public class CViewModel : ViewModelBase
    {
        public string LabelValue { get; set; }

        public CViewModel()
        {
            ConfirmValueChange = new DelegateCommand(ConfirmValueChangeCommandExecute, ConfirmValueChangeCommandCanEnable);
            CloseWindow = new DelegateCommand(CloseWindowCommandExecute, CloseWindowCommandCanEnable);
        }

        private ICurrentWindowService _currentWindowService
        {
            get => GetService<ICurrentWindowService>();
        }

        private CView _viewClass
        {
            get => (_currentWindowService as CurrentWindowService)?.ActualWindow as CView;
        }

        private string _initialLabelValue;

        #region ConfirmValueChange

        public ICommand ConfirmValueChange { get; }

        private void ConfirmValueChangeCommandExecute()
        {
            var args = new ValueChangeEventArgs<string>
                       {
                           OldValue = _initialLabelValue,
                           NewValue = LabelValue,
                       };
            OnValueChangeWhenClose(args);
            _initialLabelValue = args.NewValue;
            _viewClass.Close();
        }

        private bool ConfirmValueChangeCommandCanEnable()
        {
            return true;
        }

        #endregion

        #region CloseWindow

        public ICommand CloseWindow { get; }

        private void CloseWindowCommandExecute()
        {
            _viewClass.Close();
        }

        private bool CloseWindowCommandCanEnable()
        {
            return true;
        }

        #endregion

        public event EventHandler<ValueChangeEventArgs<string>> ValueChangeWhenClose;

        protected virtual void OnValueChangeWhenClose(ValueChangeEventArgs<string> e)
        {
            ValueChangeWhenClose?.Invoke(this, e);
        }
    }
}