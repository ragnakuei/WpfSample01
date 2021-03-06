﻿using System;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Xpf.Ribbon;
using WpfSample01.Models;
using WpfSample01.Samples.B;
using WpfSample01.Samples.C;
using WpfSample01.Samples.D;
using WpfSample01.Samples.E;
using WpfSample01.Samples.F;
using WpfSample01.Samples.G;
using WpfSample01.Samples.H;
using WpfSample01.Samples.I;
using WpfSample01.Samples.J;
using WpfSample01.Samples.K;
using WpfSample01.Samples.L;
using WpfSample01.Samples.M;
using WpfSample01.Samples.N;
using WpfSample01.Samples.O;

namespace WpfSample01.Samples.A
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
            OpenGViewCommand = new DelegateCommand(OpenGViewCommandExecute, OpenGViewCommandCanEnable);
            OpenHViewCommand = new DelegateCommand(OpenHViewCommandExecute, OpenHViewCommandCanEnable);
            OpenIViewCommand = new DelegateCommand(OpenIViewCommandExecute, OpenIViewCommandCanEnable);
            OpenJViewCommand = new DelegateCommand(OpenJMainViewCommandExecute, OpenJMainViewCommandCanEnable);
            OpenKViewCommand = new DelegateCommand(OpenKViewCommandExecute, OpenKViewCommandCanEnable);
            OpenLViewCommand = new DelegateCommand(OpenLViewCommandExecute, OpenLViewCommandCanEnable);
            OpenMViewCommand = new DelegateCommand(OpenMViewCommandExecute, OpenMViewCommandCanEnable);
            OpenNViewCommand = new DelegateCommand(OpenNViewCommandExecute, OpenNViewCommandCanEnable);
            OpenOViewCommand = new DelegateCommand(OpenOViewCommandExecute, OpenOViewCommandCanEnable);
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

        #region DView - DragDrop SVG

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

        #region EView - Pass Value To UserControl

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
        
        #region GView - OnInitialize

        public ICommand OpenGViewCommand { get; set; }

        private GView _gView;

        private void OpenGViewCommandExecute()
        {
            _gView = new GView();
            _gView.Show();
        }

        private bool OpenGViewCommandCanEnable()
        {
            return true;
        }

        #endregion
        
        #region HView - ParentViewModel

        public ICommand OpenHViewCommand { get; set; }

        private HView _hView;

        private void OpenHViewCommandExecute()
        {
            _hView = new HView();
            _hView.Show();
        }

        private bool OpenHViewCommandCanEnable()
        {
            return true;
        }

        #endregion
        
        #region IView - Pass Value Between ViewModels

        public ICommand OpenIViewCommand { get; set; }

        private IView _iView;

        private void OpenIViewCommandExecute()
        {
            _iView = new IView();
            _iView.Show();
        }

        private bool OpenIViewCommandCanEnable()
        {
            return true;
        }

        #endregion
        
        #region JView - ParentViewModel

        public ICommand OpenJViewCommand { get; set; }

        private JMainView _jMainView;

        private void OpenJMainViewCommandExecute()
        {
            _jMainView = new JMainView();
            _jMainView.Show();
        }

        private bool OpenJMainViewCommandCanEnable()
        {
            return true;
        }

        #endregion
        
        #region KView - EnumItemsSourceBehavior

        public ICommand OpenKViewCommand { get; set; }

        private KView _kView;

        private void OpenKViewCommandExecute()
        {
            _kView = new KView();
            _kView.Show();
        }

        private bool OpenKViewCommandCanEnable()
        {
            return true;
        }

        #endregion
        
        #region LView - EnumItemsSourceBehavior

        public ICommand OpenLViewCommand { get; set; }

        private LView _lView;

        private void OpenLViewCommandExecute()
        {
            _lView = new LView();
            _lView.Show();
        }

        private bool OpenLViewCommandCanEnable()
        {
            return true;
        }

        #endregion
        
        #region MView - EnumItemsSourceBehavior

        public ICommand OpenMViewCommand { get; set; }

        private MView _mView;

        private void OpenMViewCommandExecute()
        {
            _mView = new MView();
            _mView.Show();
        }

        private bool OpenMViewCommandCanEnable()
        {
            return true;
        }

        #endregion
        
        #region NView - EnumItemsSourceBehavior

        public ICommand OpenNViewCommand { get; set; }

        private NView _nView;

        private void OpenNViewCommandExecute()
        {
            _nView = new NView();
            _nView.Show();
        }

        private bool OpenNViewCommandCanEnable()
        {
            return true;
        }

        #endregion
        
        #region OView - DockingDocumentUIService

        public ICommand OpenOViewCommand { get; set; }

        private OMainView _oView;

        private void OpenOViewCommandExecute()
        {
            _oView = new OMainView();
            _oView.Show();
        }

        private bool OpenOViewCommandCanEnable()
        {
            return true;
        }

        #endregion
    }
}