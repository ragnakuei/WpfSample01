using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Diagram;
using WpfSample01.CustomControls;
using WpfSample01.Helpers;

namespace WpfSample01.D
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

        private DView ViewClass
        {
            get => (_currentWindowService as CurrentWindowService)?.ActualWindow as DView;
        }

        private void AddDiagramControl(string svgFilePath)
        {
            var diagram = new DiagramImage
                          {
                              Image = SvgHelper.FromFilePathToImageSource(svgFilePath),
                              Width = 100,
                              Height = 200
                          };

            ViewClass.diagramLayout.Items.Add(diagram);
        }
        
        #region View Related Member

        #endregion

        #region View Related Event

        public ICommand OnLoadedCommand { get; }

        private void OnLoadedCommandExecute()
        {
            var svgFilePath = Path.Combine(
                                           AppDomain.CurrentDomain.BaseDirectory,
                                           "Images",
                                           "NoteBook 1.svg"
                                          );

            new DragDropSvgImage(ViewClass.canvasLayout, svgFilePath)
                      {
                          Width = 100,
                          Margin = new Thickness
                                   {
                                       Left = 0,
                                       Top = 0
                                   }
                      };
            
            var svgFilePath2 = Path.Combine(
                                            System.AppDomain.CurrentDomain.BaseDirectory,
                                            "Images",
                                            "NoteBook 2.svg"
                                           );
            AddDiagramControl(svgFilePath2);
        }

        private bool OnLoadedCommandCanEnable()
        {
            return true;
        }

        #endregion
    }
}