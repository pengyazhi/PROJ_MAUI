using projAPP_MAUI.ViewModels;

namespace projAPP_MAUI.View;

public partial class PgHome : ContentPage
{
	public PgHome()
	{
		InitializeComponent();
	}

    private void btnProductList_Clicked(object sender, EventArgs e)
    { 
        App app = Application.Current as App;
        app.isEditor = false;
        Navigation.PushAsync(new PgProductList());
    }

    private void btnProductMangement_Clicked(object sender, EventArgs e)
    {
        App app = Application.Current as App;
        app.isEditor = true;
        Navigation.PushAsync(new PgProductList());
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
       new CProductViewModels();
       App app = Application.Current as App;
        lblHome.Text = app.lblHome;
    }

    private void btnµn¥X_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void btn­×§ï±K½X_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PgSettingEditor());
    }
}