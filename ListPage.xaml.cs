using ProiectRestaurantMobile.Models;

namespace ProiectRestaurantMobile;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
        InitializeComponent();
	}
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FoodPage((RestaurantList)
       this.BindingContext)
        {
            BindingContext = new Food()
        });

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (RestaurantList)BindingContext;

        listView.ItemsSource = await App.Database.GetListFoodsAsync(shopl.ID);
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (RestaurantList)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveRestaurantListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (RestaurantList)BindingContext;
        await App.Database.DeleteRestaurantListAsync(slist);
        await Navigation.PopAsync();
    }
}