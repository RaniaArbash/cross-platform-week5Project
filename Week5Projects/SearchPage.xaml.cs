using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Week5Projects
{
    public partial class SearchPage : ContentPage
    {
        public NetworkingManager networkingManager = new NetworkingManager();
        private BindableProperty IsSearchingProperty =
            BindableProperty.Create("IsSearching", typeof(bool), typeof(SearchPage), false);
        public bool IsSearching
        {
            get { return (bool)GetValue(IsSearchingProperty); }
            set { SetValue(IsSearchingProperty, value); }
        }
        public SearchPage()
        {
            BindingContext = this;
            InitializeComponent();
        }
        async void OnTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {    
            if (e.NewTextValue == null )
                return;
            await FindStock(e.NewTextValue);
        }

        async Task FindStock(string query)
        {
            try
            {
                IsSearching = true;
                var stocks = await networkingManager.searchForStock(query);
                stockListView.ItemsSource = stocks;
                stockListView.IsVisible = stocks.Any();
                notFound.IsVisible = !stockListView.IsVisible;
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Could not retrieve the list of movies.", "OK");
            }
            finally
            {
                IsSearching = false;
            }
        }

    }
}
