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
    public partial class Updatepage : ContentPage
    {
        SQLiteHelper db;
        public Updatepage(int pid)
        {
            db = new SQLiteHelper();
            ReadSingleRecord(pid);
            InitializeComponent();
        }
        async void ReadSingleRecord(int pno)
        {
            var dtl = await db.GetSingleRecord(pno);
            txtid.Text = pno.ToString();
            txtname.Text = dtl.Name;
            txtdob.Date = dtl.DOB.Date;
            txtaddress.Text = dtl.Address;
        }

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            Person p = new Person();
            p.id = int.Parse(txtid.Text);
            p.Name = txtname.Text;
            p.DOB = txtdob.Date;
            p.Address = txtaddress.Text;
            await db.UpdateRecord(p);
            await DisplayAlert("Update", "Record Updated Successfully", "ok");
            await Navigation.PopAsync();
        }
    }
}