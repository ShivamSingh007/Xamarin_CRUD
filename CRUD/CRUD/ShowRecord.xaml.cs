using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CRUD.Models;

namespace CRUD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowRecord : ContentPage
    {
        SQLiteHelper db;
        public ShowRecord()
        {
            db = new SQLiteHelper();
            InitializeComponent();
            DisplayAllRecord();
        }
        async void DisplayAllRecord()
        {
            var allRecord = await db.GetAllRecord();
            LstRecord.ItemsSource = allRecord;
        }
        protected override void OnAppearing()
        {
            DisplayAllRecord();
        }

        private async void Update_Clicked(object sender, EventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            int pid = int.Parse(btn.CommandParameter.ToString().Trim());
            await Navigation.PushAsync(new Updatepage(pid));
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            int pid = int.Parse(btn.CommandParameter.ToString().Trim());
            Person p = new Person();
            p.id = pid;
            db.DeleteRecord(p);
            DisplayAlert("Delete", "Record Deleted Successfully", "ok");
            LstRecord.ItemsSource = null;
            DisplayAllRecord();
        }
    }
}