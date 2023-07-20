namespace projAPP_MAUI.View;

public partial class PgHome : ContentPage
{
	public PgHome()
	{
		InitializeComponent();
	}

    private void btnProductList_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PgProductList());
    }

    private void btnProductMangement_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PgProductMangement());
    }
}