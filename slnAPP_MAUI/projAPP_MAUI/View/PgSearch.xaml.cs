
using projAPP_MAUI.ViewModels;

namespace projAPP_MAUI.View;

public partial class PgSearch : ContentPage
{ 
	
	
	public PgSearch()
	{
		InitializeComponent();
	}

    private void btnConfirm_Clicked(object sender, EventArgs e)
    {
  
        (Application.Current as App).keyword = txtNameAndDate.Text;
		Navigation.PopAsync();
    }
    protected override void OnDisappearing()
    {
        App app = Application.Current as App;
        app.selectedProdSN = -1;
        
    }
}