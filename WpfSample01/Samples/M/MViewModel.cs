using System.Collections.Generic;
using DevExpress.Mvvm;

namespace WpfSample01.Samples.M
{
    public class MViewModel : ViewModelBase
    {
        public MViewModel()
        {
            
        }
        
        public string Test(string s)
        {
            return $"Test:{s}";
        }
    }
}