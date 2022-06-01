using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OrderingApp
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
            var swagitem = new SwagItems();
            BindingContext = swagitem;
        }


        async void OnSaveClicked(object sender, EventArgs e)
        {
            var swagitem = (SwagItems)BindingContext;
            ordersDatabase database = await ordersDatabase.Instance;
            await database.SaveItemAsync(swagitem);
            await Navigation.PushAsync(new SwagList());
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var swagitem = (SwagItems)BindingContext;
            ordersDatabase database = await ordersDatabase.Instance;
            await database.DeleteItemAsync(swagitem);
            await Navigation.PushAsync(new SwagList());

        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SwagList());

        }
    }
}
