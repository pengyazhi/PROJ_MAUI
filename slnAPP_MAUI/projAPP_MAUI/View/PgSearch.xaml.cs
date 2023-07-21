using projAPP_MAUI.ViewModels;

namespace projAPP_MAUI.View;

public partial class PgSearch : ContentPage
{ 
	List<CKeywordViewModel> _keywords = new List<CKeywordViewModel>();
	
	public PgSearch()
	{
		InitializeComponent();
	}

    private void btnConfirm_Clicked(object sender, EventArgs e)
    {
        CKeywordViewModel x = new CKeywordViewModel();
		x.keyword = txtNameAndDate.Text;
		x.price = Convert.ToInt32(txtPrice.Text);
        (Application.Current as App).keywords.Add(x);
		Navigation.PopAsync();
    }
}