using System.Windows;
using DevExpress.Mvvm;

namespace WpfSample01.Helpers
{
    public static class DataContextHelper
    {
        public static TDataContext GetDataContext<TViewMode, TDataContext>(this object view) where TViewMode : FrameworkElement 
                                                                                             where TDataContext : ViewModelBase
        {
            return (view as TViewMode)?.DataContext as TDataContext;
        }
        
    }
}