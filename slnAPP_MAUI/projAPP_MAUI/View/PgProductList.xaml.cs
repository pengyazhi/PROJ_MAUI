using projAPP_MAUI.Models;

namespace projAPP_MAUI.View;

public partial class PgProductList : ContentPage
{
	public PgProductList()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        App app = Application.Current as App;
        if (app.allProdForList != null)
        {
            cvList.ItemsSource = app.allProdForList;
        }
    }
    private void cvList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        App app =  Application.Current as App;
        app.selectedProdSN = (e.CurrentSelection.FirstOrDefault() as CProducts).¬y¤ô¸¹;
        Navigation.PopAsync();
    }
}