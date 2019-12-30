using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace WpfSample01.Samples.K
{
    // 在 SelectedRole Binding 回 GridControl 時，無法改成用 ViewModelBase 方式做 Binding，只能用 ViewModelSource 的方式來達成
    
    public class KViewModel
    {
        public KViewModel()
        {
            Users = new ObservableCollection<User>
                    {
                        User.Create(0, "Jack", UserRole.Administrator),
                        User.Create(1, "Ron", UserRole.User),
                        User.Create(2, "John", UserRole.User),
                        User.Create(3, "Antoni", UserRole.User),
                        User.Create(4, "Paul", UserRole.Moderator),
                    };
            
            SelectedRole = UserRole.User;
            
            CheckCommand = new DelegateCommand(CheckCommandExecute);
        }

        public static KViewModel Create() {
            return ViewModelSource.Create(() => new KViewModel());
        }
        
        public ICommand CheckCommand { get; private set; }

        private void CheckCommandExecute()
        {
            MessageBox.Show(SelectedRole.ToString());
        }

        public virtual ObservableCollection<User> Users { get; set; }
        public virtual UserRole SelectedRole { get; set; }
    }
}