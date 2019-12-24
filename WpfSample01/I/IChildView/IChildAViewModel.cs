using System;
using System.Windows.Input;
using DevExpress.Mvvm;
using WpfSample01.Common;

namespace WpfSample01.I.IChildView
{
    public class IChildAViewModel : ViewModelBase
    {

        public IChildAViewModel()
        {
            KeyUpCommand = new DelegateCommand(KeyUpExecutor);
            ClickConfirmCommand = new DelegateCommand(ClickConfirmExecutor);
        }

        private string _textBoxValue;
        public string TextBoxValue
        {
            get => _textBoxValue;
            set => SetValue(ref _textBoxValue, value, nameof(TextBoxValue));
        }

        public ICommand KeyUpCommand { get; }

        private void KeyUpExecutor()
        {
            var newValueEventArgs = new NewValueEventArgs<string>
                                    {
                                        Value = TextBoxValue
                                    };
            OnTextBoxValueChange(newValueEventArgs);
        }
        
        public event EventHandler<NewValueEventArgs<string>> TextBoxValueChange;

        protected virtual void OnTextBoxValueChange(NewValueEventArgs<string> e)
        {
            TextBoxValueChange?.Invoke(this, e);
        }
        
        private IMessageBoxService MessageBoxService
        {
            get => GetService<IMessageBoxService>();
        }
        
        public ICommand ClickConfirmCommand { get; }

        private void ClickConfirmExecutor()
        {
            var a = TextBoxValue;
        }
    }
}