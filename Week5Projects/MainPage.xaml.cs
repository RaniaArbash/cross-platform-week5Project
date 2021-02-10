using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Week5Projects
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<CarClass> car_list;
        public NetworkingManager networkingManager = new NetworkingManager();
        public MainPage()
        {
            InitializeComponent();
            
        }

        protected  async override void OnAppearing()
        {

          // var list = await networkingManager.getCars();

            postList.ItemsSource = null;
            var list = await networkingManager.GetAllPosts();
            car_list = new ObservableCollection<CarClass>(list);
            postList.ItemsSource = car_list;
            base.OnAppearing();

        }
         
        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
             networkingManager.PostOneCar();
        }
    }
}
