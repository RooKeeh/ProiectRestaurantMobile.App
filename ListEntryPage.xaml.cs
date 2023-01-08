using ProiectRestaurantMobile.Models;

namespace ProiectRestaurantMobile;

public partial class ListEntryPage : ContentPage
{
	public ListEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetRestaurantListsAsync();
    }
    async void OnRestaurantListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListPage { BindingContext = new RestaurantList() });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ListPage { BindingContext = e.SelectedItem as RestaurantList });
        }
    }
}