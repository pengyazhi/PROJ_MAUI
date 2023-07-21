using projAPP_MAUI.Models;
using projAPP_MAUI.ViewModels;

namespace projAPP_MAUI.View;

public partial class PgProductMangement : ContentPage
{
    CProducts _current= null;
    CProductViewModels _vm =null;
    public PgProductMangement()
	{
		InitializeComponent();
        _vm = this.BindingContext as CProductViewModels;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        App app = Application.Current as App;
        if (app.selectedProdSN > 0)
        {
            _current = app.allProdForList.FirstOrDefault(p => p.촽ㆄ많 == app.selectedProdSN);
            if (_current != null) 
            {
                txtName.Text = _current.product;
                txtSupplier.Text = _current.supplier;
                txtPrice.Text = _current.price.ToString();
                txtDate.Text = _current.date;
                txtMin.Text = _current.min.ToString();
                txtMax.Text = _current.max.ToString();
            }
        }
    }
    protected override void OnDisappearing()
    {
        App app = Application.Current as App;
        app.selectedProdSN = -1;
    }
    private void btnAdd_Clicked(object sender, EventArgs e)
    {
		int sn = Preferences.Default.Get("COUNT", 0);
		sn++;
		Preferences.Default.Set("COUNT", sn);
        Preferences.Default.Set("N" + sn, txtName.Text);
        Preferences.Default.Set("S"+sn,txtSupplier.Text);
        Preferences.Default.Set("P" + sn, txtPrice.Text);
        Preferences.Default.Set("D" + sn, txtDate.Text);
        Preferences.Default.Set("MIN" + sn, txtMin.Text);
        Preferences.Default.Set("MAX" + sn, txtMax.Text);
        clear();
    }

    private void btnList_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PgProductList());
    }

    private void btnDelete_Clicked(object sender, EventArgs e)
    {
        if(_current != null)
        {
            Preferences.Default.Remove("N" + _current.촽ㆄ많.ToString());
            Preferences.Default.Remove("S" + _current.촽ㆄ많.ToString());
            Preferences.Default.Remove("P" + _current.촽ㆄ많.ToString());
            Preferences.Default.Remove("D" + _current.촽ㆄ많.ToString());
            Preferences.Default.Remove("MIN" + _current.촽ㆄ많.ToString());
            Preferences.Default.Remove("MAX" + _current.촽ㆄ많.ToString());
        }
        _current = null;
        clear();
    }

    private void btnClear_Clicked(object sender, EventArgs e)
    {
        clear();
    }
    void clear()
    {
        txtName.Text = "";
        txtSupplier.Text = "";
        txtPrice.Text = "";
        txtDate.Text = "";
        txtMin.Text = "";
        txtMax.Text = "";

    }

    private void btnFirst_Clicked(object sender, EventArgs e)
    {
        _vm.moveFirst();
    }

    private void btnPrevious_Clicked_1(object sender, EventArgs e)
    {
        _vm.movePrevious();
    }

    private void btnNext_Clicked_2(object sender, EventArgs e)
    {
        _vm.moveNext();
    }

    private void btnLast_Clicked_3(object sender, EventArgs e)
    {
        _vm.moveLast();
    }

    private void btnSearch_Clicked_4(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PgSearch());
    }

    private void btnHome_Clicked(object sender, EventArgs e)
    {

    }
}