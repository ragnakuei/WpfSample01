using DevExpress.Mvvm.POCO;

namespace WpfSample01.Samples.K
{
    public class User {
        protected User(string name, int iD, UserRole role) {
            Name = name;
            ID = iD;
            Role = role;
        }
        public static User Create(int id, string name, UserRole role) {
            return ViewModelSource.Create(() => new User(name, id, role));
        }

        public string Name { get; set; }
        public int ID { get; set; }
        public UserRole Role { get; set; }
    }
}