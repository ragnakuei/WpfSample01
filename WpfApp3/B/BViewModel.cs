using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.UI;

namespace WpfApp3.B
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
        
        public event EventHandler<EventArgs> ValueChange;

        protected virtual void OnValueChange(EventArgs e)
        {
            ValueChange?.Invoke(this, e);
        }
    }
}