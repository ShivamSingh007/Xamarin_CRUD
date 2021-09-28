using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUD
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new string[] { "RadioButton_Experimental", "SwipeView_Experimental" });
            MainPage = new NavigationPage(new MainPage());
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
