using System;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Xpf.Ribbon;
using WpfSample01.B;
using WpfSample01.C;
using WpfSample01.D;
using WpfSample01.E;
using WpfSample01.F;
using WpfSample01.Models;

namespace WpfSample01.A
{
    public class AViewModel : ViewModelBase
    {
        private string _labelResult;

        public string LabelResult
        {
            get => _labelResult;
            private set
            {
                if (this.SetProperty<string>(ref this._labelResult, value, nameof(LabelResult)))
                {
                    // MessageBox.Show("Success");
                }
                else
                {
                    // MessageBox.Show("Failed");
                }
            }
        }

        public AViewModel()
        {
            OpenBViewCommand = new DelegateCommand(OpenBViewCommandExecute, OpenBViewCommandCanEnable);
            OpenCViewCommand = new DelegateCommand(OpenCViewCommandExecute, OpenCViewCommandCanEnable);
            OpenDViewCommand = new DelegateCommand(OpenDViewCommandExecute, OpenDViewCommandCanEnable);
            OpenEViewCommand = new DelegateCommand(OpenEViewCommandExecute, OpenEViewCommandCanEnable);
            OpenFViewCommand = new DelegateCommand(OpenFViewCommandExecute, OpenFViewCommandCanEnable);
        }

        #region BView - 在關閉時統一更新值

        public ICommand OpenBViewCommand { get; set; }

        private BView _bView;

        private void OpenBViewCommandExecute()
        {
            _bView = new BView();
            _bView.Closed += BViewClose;
            _bView.Show();
        }

        private bool OpenBViewCommandCanEnable()
        {
            return true;
        }


        private void BViewClose(object sender, EventArgs e)
        {
            var target = sender as DXRibbonWindow;
            LabelResult = (target.DataContext as BViewModel).LabelValue;
        }

        #endregion

        #region CView - 讓 ViewModel 來決定觸發 Event 的時機

        public ICommand OpenCViewCommand { get; set; }

        private CView _cView;

        private void OpenCViewCommandExecute()
        {
            _cView = new CView();
            (_cView.DataContext as CViewModel).ValueChangeWhenClose += CViewValueChangeWhenClose;

            _cView.Show();
        }

        private bool OpenCViewCommandCanEnable()
        {
            return true;
        }

        private void CViewValueChangeWhenClose(object sender, ValueChangeEventArgs<string> e)
        {
            LabelResult = e.NewValue;
        }

        #endregion

        #region DView - SVG

        public ICommand OpenDViewCommand { get; set; }

        private DView _dView;

        private void OpenDViewCommandExecute()
        {
            _dView = new DView();

            _dView.Show();
        }

        private bool OpenDViewCommandCanEnable()
        {
            return true;
        }

        #endregion

        #region EView - 嘗試將值傳入 UserControl 中

        public ICommand OpenEViewCommand { get; set; }

        private EView _eView;

        private void OpenEViewCommandExecute()
        {
            _eView = new EView();
            _eView.Show();
        }

        private bool OpenEViewCommandCanEnable()
        {
            return true;
        }

        #endregion

        #region FView - Custom Behavior

        public ICommand OpenFViewCommand { get; set; }

        private FView _fView;

        private void OpenFViewCommandExecute()
        {
            _fView = new FView();
            _fView.Show();
        }

        private bool OpenFViewCommandCanEnable()
        {
            return true;
        }

        #endregion
    }
}