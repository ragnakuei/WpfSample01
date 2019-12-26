using System;
using DevExpress.Mvvm;
using WpfSample01.Common;

namespace WpfSample01.Samples.I.IChildView
{
    public class IChildViewModel : ViewModelBase
    {
        public IChildViewModel()
        {
        }

        private string _textBoxValue;

        public string TextBoxValue
        {
            get => _textBoxValue;
            set
            {
                SetValue(ref _textBoxValue, value, nameof(TextBoxValue));

                if (_isCallTextBoxValueChangeEvent)
                {
                    var newValueEventArgs = new NewValueEventArgs<string> { Value = TextBoxValue };
                    OnTextBoxValueChange(newValueEventArgs);    
                }
            }
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

        private bool _isCallTextBoxValueChangeEvent = false;
        
        protected override void OnParameterChanged(object parameter)
        {
            base.OnParameterChanged(parameter);
            _isCallTextBoxValueChangeEvent = false;
            if (parameter?.ToString() != null)
            {
                TextBoxValue = parameter.ToString();
            }
            _isCallTextBoxValueChangeEvent = true;
        }
    }
}