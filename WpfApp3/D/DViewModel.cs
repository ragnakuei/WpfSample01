using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using WpfApp3.CustomControls;

namespace WpfApp3.D
{
    public class DViewModel : ViewModelBase
    {
        public DViewModel()
        {
            OnLoadedCommand = new DelegateCommand(OnLoadedCommandExecute, OnLoadedCommandCanEnable);
        }

        private ICurrentWindowService _currentWindowService
        {
            get => GetService<ICurrentWindowService>();
        }

        private DView _viewClass
        {
            get => (_currentWindowService as CurrentWindowService)?.ActualWindow as DView;
        }

        #region View Related Member

        private DragDropSvgImage _image1;

        #endregion

        #region View Related Event

        public ICommand OnLoadedCommand { get; private set; }
        
        private void OnLoadedCommandExecute()
        {
            var svgFilePath = Path.Combine(
                                           AppDomain.CurrentDomain.BaseDirectory,
                                           "Images",
                                           "NoteBook 1.svg"
                                          );
            
            _image1 = new DragDropSvgImage(_viewClass.canvasLayout, svgFilePath)
                                 {
                                     Width = 100,
                                     Margin = new Thickness
                                              {
                                                  Left = 0,
                                                  Top = 0
                                              }
                                 };
        }

        private bool OnLoadedCommandCanEnable()
        {
            return true;
        }

        #endregion
    }
}