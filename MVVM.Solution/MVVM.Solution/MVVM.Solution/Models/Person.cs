using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM.Solution.Models
{
    public class Person : INotifyPropertyChanged
    {
        public int Id { get; set; }
        //public string Name { get; set; }
        private string _name { get; set; }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Surname { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
