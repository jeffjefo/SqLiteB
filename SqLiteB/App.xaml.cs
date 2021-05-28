using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqLiteB
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //para ponele de principal la pantalla login
            MainPage = new NavigationPage (new Login());
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
