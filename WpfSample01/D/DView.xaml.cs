using DevExpress.Xpf.Diagram;
using DevExpress.Xpf.Ribbon;
using WpfSample01.Helpers;
using Path = System.IO.Path;

namespace WpfSample01.D
{
    public partial class DView : DXRibbonWindow
    {
        public DView()
        {
            InitializeComponent();

            var svgFilePath2 = Path.Combine(
                                            System.AppDomain.CurrentDomain.BaseDirectory,
                                            "Images",
                                            "NoteBook 2.svg"
                                           );
            AddDiagramControl(svgFilePath2);
        }

        private void AddDiagramControl(string svgFilePath)
        {
            var diagram = new DiagramImage
                          {
                              Image = SvgHelper.FromFilePathToImageSource(svgFilePath),
                              Width = 100,
                              Height = 200
                          };

            diagramLayout.Items.Add(diagram);
        }
    }
}