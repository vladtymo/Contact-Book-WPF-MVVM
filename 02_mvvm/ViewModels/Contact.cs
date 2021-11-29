using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _02_mvvm
{
    class Contact : INotifyPropertyChanged
    {
        private string name;
        private string surname;
        private int age;
        private string phone;
        private bool isMale;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ShortInfo));
            }
        }
        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ShortInfo));
            }
        }
        public int Age
        {
            get => age;
            set
            {
                age = value;
                OnPropertyChanged();
            }
        }
        public string Phone
        {
            get => phone;
            set
            {
                phone = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ShortInfo));
            }
        }
        public bool IsMale
        {
            get => isMale;
            set
            {
                isMale = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(GenderName));
            }
        }

        public string GenderName => IsMale ? "Male" : "Female";
        public string ShortInfo => $"{Name} {Surname} {Phone}";

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{Name} {Surname} {Phone}";
        }
    }
}
