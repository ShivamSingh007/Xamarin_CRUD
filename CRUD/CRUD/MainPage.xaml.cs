using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CRUD.Models;

namespace CRUD
{
    public partial class MainPage : ContentPage
    {
        SQLiteHelper db;
        public MainPage()
        {
            db = new SQLiteHelper();
            InitializeComponent();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            string Name = txtname.Text;
            DateTime DOB = txtdob.Date;
            string Address = txtaddress.Text;
            string Gender= Rdbmale.IsChecked == true ? "Male" : "female";
            Person per = new Person()
            {
                Name = Name,
                DOB = DOB,
                Address = Address,
                Gender = Gender
            };
            await db.AddNewRecord(per);
            await DisplayAlert("Success", "Record Save Successfully", "ok");
            txtname.Text = string.Empty;
            txtaddress.Text = string.Empty;
            await Navigation.PushAsync(new ShowRecord());
        }
    }
}
