using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _02_mvvm
{
    class MainViewModel
    {
        private ObservableCollection<Contact> contacts;
        private RelayCommand copyCommand;
        private RelayCommand removeCommand;

        public MainViewModel()
        {
            contacts = new ObservableCollection<Contact>()
            {
                new Contact() { Name = "Vova", Surname = "Rakuten", Age = 16, Phone = "+380(66)456-66-66", IsMale = true},
                new Contact() { Name = "Olga", Surname = "Balasko", Age = 15, Phone = "+380(55)123-66-99", IsMale = false},
                new Contact() { Name = "Andrii", Surname = "Shyven", Age = 24, Phone = "+380(98)876-33-66", IsMale = true},
            };

            copyCommand = new RelayCommand((o) => CreateCopy(), (o) => IsContactSelected());
            removeCommand = new RelayCommand((o) => RemoveSelected(), (o) => IsContactSelected());
        }

        public ICommand CopyCommand => copyCommand;
        public ICommand RemoveCommand => removeCommand;

        public Contact SelectedContact { get; set; }
        public IEnumerable<Contact> Contacts => contacts;

        public void CreateCopy()
        {
            if (IsContactSelected())
            {
                Contact newContact = new Contact()
                {
                    Name = SelectedContact.Name,
                    Surname = SelectedContact.Surname,
                    Age = SelectedContact.Age,
                    Phone = SelectedContact.Phone,
                    IsMale = SelectedContact.IsMale,
                };
                contacts.Add(newContact);
            }
        }
        public bool IsContactSelected() => SelectedContact != null;
        public void RemoveSelected()
        {
            if (IsContactSelected())
                contacts.Remove(SelectedContact);
        }
    }
}
