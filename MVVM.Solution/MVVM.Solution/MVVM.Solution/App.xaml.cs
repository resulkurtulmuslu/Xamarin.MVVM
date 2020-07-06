using MVVM.Solution.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVM.Solution
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PersonPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
