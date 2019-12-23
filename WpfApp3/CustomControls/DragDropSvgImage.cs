using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp3.D;
using WpfApp3.Helpers;

namespace WpfApp3.CustomControls
{
    public class DragDropSvgImage : Image
    {
        private readonly Panel _parentElement;

        public DragDropSvgImage(Panel parentElement, string svgFilePath)
        {
            _parentElement = parentElement;

            Source = SvgHelper.FromFilePathToImageSource(svgFilePath);
            VerticalAlignment = VerticalAlignment.Center;
            HorizontalAlignment = HorizontalAlignment.Center;
            MouseLeftButtonDown += rect_MouseLeftButtonDown;
            MouseMove += rect_MouseMove;
            MouseLeftButtonUp += rect_MouseLeftButtonUp;
            
            _parentElement.Children.Add(this);
        }
        
        private bool _enableImageDrag;
        
        /// <summary>
        /// 【觸發】【滑鼠】紀錄點下左鍵
        /// </summary>
        private void rect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var rect = sender as Image;
            _enableImageDrag = true;
            rect.CaptureMouse();
        }
        
        /// <summary>
        /// 【觸發】【滑鼠】紀錄放開左鍵
        /// </summary>
        private void rect_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var rect = sender as Image;
            _enableImageDrag = false;
            rect.ReleaseMouseCapture();
        }
        
        /// <summary>
        /// 【連動觸發】【滑鼠】游標移動
        /// </summary>
        private void rect_MouseMove(object sender, MouseEventArgs e)
        {
            var image = sender as Image;
            if (_enableImageDrag == false)
            {
                return;
            }

            // 取的滑鼠在Canvas的點擊座標
            // var mousePos = e.GetPosition(rootLayout);
            var mousePos = e.GetPosition(_parentElement);
            
            //設定新座標
            double left = mousePos.X - (image.ActualWidth / 2);
            double top = mousePos.Y - (image.ActualHeight / 2);

            //計算上下限
            // double board_minleft = 0;
            // double board_mintop = 0;
            // double board_MAXleft = cav_board.Width - rect.Width;
            // double board_MAXtop = cav_board.Height - rect.Height;
            // if (left < board_minleft) { left = board_minleft; }
            // if (left > board_MAXleft) { left = board_MAXleft; }
            // if (top < board_mintop) { top = board_mintop; }
            // if (top > board_MAXtop) { top = board_MAXtop; }

            Canvas.SetLeft(image, left);
            Canvas.SetTop(image, top);
        }  
    }
}