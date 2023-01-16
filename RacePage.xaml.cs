using F1Races2.Models;

namespace F1Races2;

public partial class RacePage : ContentPage
{
    RaceList rl;
    public RacePage(RaceList rlist)
    {
		InitializeComponent();
        rl = rlist;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var race = (Race)BindingContext;
        await App.Database.SaveRaceAsync(race);
        listView.ItemsSource = await App.Database.GetRacesAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var rlist = (Race)BindingContext;
        await App.Database.DeleteRaceAsync(rlist);
        listView.ItemsSource = await App.Database.GetRacesAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetRacesAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Race r;
        if (listView.SelectedItem != null)
        {
            r = listView.SelectedItem as Race;
            var lr = new ListRace()
            {
                RaceListID = rl.ID,
                RaceID = r.ID
            };
            await App.Database.SaveListRaceAsync(lr);
            r.ListRaces = new List<ListRace> { lr };
            await Navigation.PopAsync();
        }


    }
}