using System;
using System.Collections.Generic;
using System.Windows.Input;
using DevExpress.Mvvm;

namespace WpfSample01.Samples.O
{
    public class OMainViewModel : ViewModelBase, ISupportLogicalLayout
    {
        #region ISupportLogicalLayout

        public bool CanSerialize => true;

        public IEnumerable<object> LookupViewModels => null;

        public IDocumentManagerService DocumentManagerService => GetService<IDocumentManagerService>();

        #endregion

        public ILayoutSerializationService LayoutSerializationService => GetService<ILayoutSerializationService>();

        public OMainViewModel()
        {
            OpenDocumentCommand = new DelegateCommand(OpenDocumentCommandExecute);

            State = new ViewModelState { State = "Root !" };
        }

        private ViewModelState _state;
        public ViewModelState State
        {
            get => _state;
            private set => SetProperty(ref _state, value, nameof(State));
        }

        public ICommand OpenDocumentCommand { get; set; }

        private void OpenDocumentCommandExecute()
        {
            var document = DocumentManagerService.CreateDocument(nameof(OTabContentView), null, this);
            document.Id = "Document" + Guid.NewGuid().ToString().Replace("-", "");
            document.DestroyOnClose = false;
            document.Title = "Root Document";
            document.Show();
        }
    }
}