using System;
using System.Windows.Input;
using DevExpress.Mvvm;
using WpfSample01.Common;

namespace WpfSample01.I.IChildView
{
    public class IChildBViewModel : ViewModelBase
    {
        public IChildBViewModel()
        {
            KeyUpCommand = new DelegateCommand(KeyUpExecutor);
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
        
        protected override void OnParameterChanged(object parameter) {
            base.OnParameterChanged(parameter);
            if(parameter is string)
            {
                // MessageBoxService.Show("IChildAViewModel: Parameter = " + parameter);
                TextBoxValue = parameter.ToString();
            }
        }
    }
}