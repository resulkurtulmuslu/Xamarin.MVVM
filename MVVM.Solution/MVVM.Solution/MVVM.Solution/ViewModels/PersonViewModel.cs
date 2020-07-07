using MVVM.Solution.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM.Solution.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private void BindData()
        {
            this.IsRefresh = true;

            Person.Clear();

            Person.Add(new Person
            {
                Id = 1,
                Name = "Resul",
                Surname = "Kurtulmuşlu"
            });

            Person.Add(new Person
            {
                Id = 2,
                Name = "Çoşkun",
                Surname = "Akdemir"
            });

            Person.Add(new Person
            {
                Id = 3,
                Name = "Osman",
                Surname = "Demir"
            });

            Person.Add(new Person
            {
                Id = 4,
                Name = "Melek",
                Surname = "Alice"
            });

            this.IsRefresh = false;
        }

        public PersonViewModel()
        {
            BindData();
            deleteCommand = new Command(onDelete);
            updateCommand = new Command(onUpdate);
            refreshCommand = new Command(onRefresh);
        }

        ICommand deleteCommand, updateCommand, refreshCommand;

        private ObservableCollection<Person> _person;
        private bool _isRefresh;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Person> Person
        {
            get
            {
                if (_person == null)
                    _person = new ObservableCollection<Person>();

                return _person;
            }
            set =>
                _person = value;
        }

        public bool IsRefresh
        {
            get
            {
                return _isRefresh;
            }
            set
            {
                _isRefresh = value;
                OnPropertyChanged();
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
            set
            {
                if (value == null)
                    return;
                deleteCommand = value;
            }
        }

        public ICommand UpdateCommand
        {
            get
            {
                return updateCommand;
            }
            set
            {
                if (value == null)
                    return;
                updateCommand = value;
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return refreshCommand;
            }
            set
            {
                if (value == null)
                    return;
                refreshCommand = value;
            }
        }

        private void onDelete(object param)
        {
            Person selectedModel = (Person)param;

            if (selectedModel != null)
                Person.Remove(selectedModel);
        }

        private void onUpdate(object param)
        {
            Person selectedModel = (Person)param;

            if (selectedModel != null)
                selectedModel.Name += ".i";
        }

        private void onRefresh()
        {
            BindData();
        }

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
