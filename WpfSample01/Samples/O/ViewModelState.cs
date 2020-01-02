using DevExpress.Mvvm;

namespace WpfSample01.Samples.O
{
    public class ViewModelState : ViewModelBase {
        public string State {
            get { return GetProperty(() => State); }
            set { SetProperty(() => State, value); }
        }
        public string FullOwnerName {
            get { return GetProperty(() => FullOwnerName); }
            set { SetProperty(() => FullOwnerName, value); }
        }
    }
}