using F1Races2.Models;
namespace F1Races2;

public partial class RaceEntryPage : ContentPage
{
	public RaceEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetRacesAsync();
    }
    async void OnRaceAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RaceListPage
        {
            BindingContext = new RaceList()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new RaceListPage
            {
                BindingContext = e.SelectedItem as RaceList
            });
        }
    }
}
