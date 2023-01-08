using ProiectRestaurantMobile.Models;

namespace ProiectRestaurantMobile;

public partial class FoodPage : ContentPage
{
    RestaurantList rl;
    public FoodPage(RestaurantList rlist)
	{
		InitializeComponent();
        rl = rlist;
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var food = (Food)BindingContext;
        await App.Database.SaveFoodAsync(food);
        listView.ItemsSource = await App.Database.GetFoodsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var food = (Food)BindingContext;
        await App.Database.DeleteFoodAsync(food);
        listView.ItemsSource = await App.Database.GetFoodsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetFoodsAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Food f;
        if (listView.SelectedItem != null)
        {
            f = listView.SelectedItem as Food;
            var lf = new ListFood()
            {
                RestaurantListID = rl.ID,
                FoodID = f.ID
            };
            await App.Database.SaveListFoodAsync(lf);
            f.ListFoods = new List<ListFood> { lf };
            await Navigation.PopAsync();
        }
    }
}