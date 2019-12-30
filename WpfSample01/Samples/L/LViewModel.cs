using System.Diagnostics;
using System.Windows.Input;
using DevExpress.Mvvm;

namespace WpfSample01.Samples.L
{
    public class LViewModel : ViewModelBase
    {
        public LViewModel()
        {
            SaveCommand = new DelegateCommand(SaveCommandExecute);
            CloseCommand = new DelegateCommand(CloseCommandExecute);
        }

        public ICommand SaveCommand { get; private set; }

        private void SaveCommandExecute()
        {
            Debug.WriteLine("Save");
        }

        public ICommand CloseCommand { get; private set; }

        private void CloseCommandExecute()
        {
            Debug.WriteLine("Close");
        }
    }
}