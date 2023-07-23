using projAPP_MAUI.ViewModels;

namespace projAPP_MAUI.View;

public partial class PgProductInfo : ContentPage
{
    CProductViewModels _vm = null;
	public PgProductInfo()
	{
		InitializeComponent();
        _vm = this.BindingContext as CProductViewModels;
        
    }
    protected override void OnDisappearing()
    {
        App app = Application.Current as App;
        app.selectedProdSN = -1;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        App app = Application.Current as App; 
       
        if (app.selectedProdSN >= 0)
        {
            _vm.moveTo(app.selectedProdSN);
        }
        
        if (!string.IsNullOrEmpty(app.keyword))
        {
            _vm.queryByKeyword(app.keyword);
            app.keyword = null;
        }
    }

    private void btnFirst_Clicked(object sender, EventArgs e)
    {
        _vm.moveFirst();
    }

    private void btnPrevious_Clicked(object sender, EventArgs e)
    {
        _vm.movePrevious();
    }

    private void btnNext_Clicked(object sender, EventArgs e)
    {
        _vm.moveNext();
    }

    private void btnLast_Clicked(object sender, EventArgs e)
    {
        _vm.moveLast();
    }

    private void btnSearch_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PgSearch());
    }

    private void btnHome_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PgHome());
    }

    private void btnList_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}