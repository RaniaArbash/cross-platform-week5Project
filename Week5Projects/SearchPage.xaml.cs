using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Week5Projects
{
    public partial class SearchPage : ContentPage
    {
        public NetworkingManager networkingManager = new NetworkingManager();
        YahooModel stocks;
        public SearchPage()
        {
            
            InitializeComponent();
            

        }
        protected async override void OnAppearing()
        {
            var dic = await networkingManager.searchForStock("apple");
            var obj = dic.ElementAt(0);

            base.OnAppearing();
        }
    }
}
