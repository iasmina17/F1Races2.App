using F1Races2.Models;
namespace F1Races2;

public partial class RaceListPage : ContentPage
{
	public RaceListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var rlist = (RaceList)BindingContext;
        rlist.Date = DateTime.UtcNow;
        await App.Database.SaveRaceListAsync(rlist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var rlist = (RaceList)BindingContext;
        await App.Database.DeleteRaceListAsync(rlist);
        await Navigation.PopAsync();
    }

    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RacePage((RaceList)
       this.BindingContext)
        {
            BindingContext = new Race()
        });
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var racel = (RaceList)BindingContext;

        listView.ItemsSource = await App.Database.GetListRacesAsync(racel.ID);
    }

}