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

        
        public static readonly BindableProperty IsSearchingProperty =
            BindableProperty.Create("IsSearching", typeof(bool), typeof(SearchPage));
        public bool IsSearching
        {
            get { return (bool)GetValue(IsSearchingProperty); }
            set { SetValue(IsSearchingProperty, value); }

        }
        public SearchPage()
        {
            BindingContext = this;
            InitializeComponent();
            IsSearching = false;

        }
        async void OnTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {    
            if (e.NewTextValue == null )
                return;
            await FindStock(e.NewTextValue);
        }

        async Task FindStock(string query)
        {
            try {
                IsSearching = true;
               var stockList = await networkingManager.searchForStock(query);
                stockListView.ItemsSource = stockList;
            }
            catch {
                await DisplayAlert("Error", "Could not found any result ", "OK");
            }
            finally
            {

                IsSearching = false;
            }
        }

    }
}
