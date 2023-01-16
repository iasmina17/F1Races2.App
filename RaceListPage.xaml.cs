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
        var slist = (Race)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveRaceAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Race)BindingContext;
        await App.Database.DeleteRaceAsync(slist);
        await Navigation.PopAsync();
    }

}