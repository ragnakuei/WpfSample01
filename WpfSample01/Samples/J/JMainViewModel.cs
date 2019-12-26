using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm;
using WpfSample01.Models;

namespace WpfSample01.Samples.J
{
    public class JMainViewModel : ViewModelBase
    {
        public JMainViewModel()
        {
            OnLoadedCommand = new DelegateCommand(OnLoadedCommandExecute);
            PeopleListViewOnMouseDownCommand = new DelegateCommand<Person>(PeopleListViewOnMouseDownCommandExecute);
        }

        private Person[] _people;

        public Person[] People
        {
            get => _people;
            set => SetValue(ref _people, value, nameof(People));
        }


        public virtual Person SelectedPerson { get; set; }

        public ICommand OnLoadedCommand { get; }

        private void OnLoadedCommandExecute()
        {
            People = new[]
                     {
                         new Person
                         {
                             Id = 1,
                             Name = "A",
                             Age = 18,
                             HomeTown = "HomeTownA"
                         },
                         new Person
                         {
                             Id = 2,
                             Name = "B",
                             Age = 19,
                             HomeTown = "HomeTownB"
                         },
                         new Person
                         {
                             Id = 3,
                             Name = "C",
                             Age = 20,
                             HomeTown = "HomeTownC"
                         },
                     };
        }

        public ICommand PeopleListViewOnMouseDownCommand { get; }

        private void PeopleListViewOnMouseDownCommandExecute(Person selectedPerson)
        {
            SelectedPerson = selectedPerson;
        }
    }
}