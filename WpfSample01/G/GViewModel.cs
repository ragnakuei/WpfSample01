using System.Windows.Input;
using DevExpress.Mvvm;

namespace WpfSample01.G
{
    public class GViewModel : ViewModelBase
    {

        public GViewModel()
        {
            OnLoadedCommand = new DelegateCommand(OnLoadedCommandExecute, OnLoadedCommandCanEnable);
        }

        public string LabelValue
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        #region View Related Event

        public ICommand OnLoadedCommand { get; }

        private void OnLoadedCommandExecute()
        {
            // MessageBox.Show("OnLoad");
        }

        private bool OnLoadedCommandCanEnable()
        {
            return true;
        }

        #endregion

        protected override void OnInitializeInDesignMode()
        {
            base.OnInitializeInDesignMode();
            LabelValue = "InDesignMode";
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
            LabelValue = "InRuntime";
        }
    }
}