using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using WpfSample01.Models;

namespace WpfSample01.Samples.J
{
    public class JDetailViewModel : ISupportParentViewModel
    {
        public JDetailViewModel()
        {
        }

        public virtual object ParentViewModel { get; set; }

        public virtual Person SelectedPerson { get; set; }

        protected void OnParentViewModelChanged()
        {
            SelectedPerson = ParentViewModel as Person;
            this.RaisePropertyChanged(x => x.SelectedPerson);
        }
    }
}