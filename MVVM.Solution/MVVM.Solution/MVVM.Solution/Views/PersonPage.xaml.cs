using MVVM.Solution.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVM.Solution.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonPage : ContentPage
    {
        //private readonly List<Person> people = new List<Person>();
        private readonly IList<Person> people = new ObservableCollection<Person>(); // Ekleme ,silme ve reflesh durumlarında değişiklikleri hiçbirşeye ihtiyaç duymadan ekrana yansıtır.

        public PersonPage()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            people.Add(new Person
            {
                Id = 1,
                Name = "Resul",
                Surname = "Kurtulmuşlu"
            });

            people.Add(new Person
            {
                Id = 2,
                Name = "Çoşkun",
                Surname = "Akdemir"
            });

            people.Add(new Person
            {
                Id = 3,
                Name = "Osman",
                Surname = "Demir"
            });

            people.Add(new Person
            {
                Id = 4,
                Name = "Melek",
                Surname = "Alice"
            });

            //1 - lst_Person.ItemsSource = people;
            lst_Person.BindingContext = people;
        }

        private void btn_Delete_Clicked(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            Person selectedModel = (Person)item.CommandParameter;

            if (selectedModel != null)
                people.Remove(selectedModel);
        }

        private void btn_Update_Clicked(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            Person selectedModel = (Person)item.CommandParameter;

            if (selectedModel != null)
            {
                selectedModel.Name += ".i";
            }
        }
    }
}