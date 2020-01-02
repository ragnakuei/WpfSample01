using System;
using System.Collections.Generic;
using System.Windows.Input;
using DevExpress.Mvvm;

namespace WpfSample01.Samples.O
{
    public class OTabContentViewModel : ViewModelBase, ISupportLogicalLayout<ViewModelState>, ISupportParentViewModel
    {
        public IDocumentManagerService DocumentManagerService => GetService<IDocumentManagerService>();
        
        #region ISupportParentViewModel
        
        public virtual object ParentViewModel { get; set; }
        
        #endregion
        
        #region ISupportLogicalLayout
        
        public virtual ViewModelState SaveState() {
            return State;
        }
        
        public virtual void RestoreState(ViewModelState state) {
            State = state;
        }
        
        bool ISupportLogicalLayout.CanSerialize {
            get { return !String.IsNullOrEmpty(State.State); }
        }
        
        public IEnumerable<object> LookupViewModels {
            get { return null; }
        }
        
        #endregion
        
        public OTabContentViewModel()
        {
            OpenChildDocumentCommand = new DelegateCommand(OpenChildDocumentCommandExecute);
            State = new ViewModelState { State = Guid.NewGuid().ToString()};
        }
        
        public ICommand OpenChildDocumentCommand { get; }
        
        public string Caption { get;}
        
        private bool _canBeClosed;
        
        public bool CanBeClosed
        {
            get => _canBeClosed;
            set => SetProperty(ref _canBeClosed, value, nameof(CanBeClosed));
        }
        
        private ViewModelState _state;
        
        public ViewModelState State
        {
            get => _state;
            set => SetProperty(ref _state, value, nameof(State));
        }
        
        private void OpenChildDocumentCommandExecute()
        {
            var document = DocumentManagerService.CreateDocument(nameof(OTabContentView), null, this);
            document.DestroyOnClose = false;
            document.Title = "Child Document";
            document.Id = "Child" + Guid.NewGuid().ToString().Replace("-", "");
            document.Show();
        }
    }
}