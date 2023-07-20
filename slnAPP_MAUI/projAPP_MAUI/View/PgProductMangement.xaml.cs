using projAPP_MAUI.Models;

namespace projAPP_MAUI.View;

public partial class PgProductMangement : ContentPage
{
    CProducts _current= null;
	public PgProductMangement()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        App app = Application.Current as App;
        if (app.selectedProdSN > 0)
        {
            _current = app.allProdForList.FirstOrDefault(p => p.流水號 == app.selectedProdSN);
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
        txtName.Text = "";
        txtSupplier.Text = "";
        txtPrice.Text = "";
        txtDate.Text = "";
        txtMin.Text = "";
        txtMax.Text="";
    }

    private void btnList_Clicked(object sender, EventArgs e)
    {
        int sn = Preferences.Default.Get("COUNT", 0);
        if (sn == 0)
            return;
        List<CProducts> products = new List<CProducts>();
        for(int i = 1; i <= sn; i++)
        {
            string KeyN = "N" + i;
            string KeyS = "S" + i;
            string KeyP = "P" + i;
            string KeyD = "D" + i;
            string KeyMin = "MIN" + i;
            string KeyMax = "MAX" + i;
            if (Preferences.Default.ContainsKey(KeyN))
            {
                CProducts x = new CProducts();
                x.product = Preferences.Default.Get(KeyN, "");
                x.supplier = Preferences.Default.Get(KeyS, "");
                x.price = Convert.ToInt32( Preferences.Default.Get(KeyP, ""));
                x.date = Preferences.Default.Get(KeyD, "");
                x.min = Convert.ToInt32(Preferences.Default.Get(KeyMin, ""));
                x.max = Convert.ToInt32(Preferences.Default.Get(KeyMax, ""));
                x.流水號 = i;
                products.Add(x);
            }
        }
        if (products.Count == 0)
            return;
        (Application.Current as App).allProdForList = products;
        Navigation.PushAsync(new PgProductList());
    }

    private void btnDelete_Clicked(object sender, EventArgs e)
    {

    }

    private void btnClear_Clicked(object sender, EventArgs e)
    {
        txtName.Text = "";
        txtSupplier.Text = "";
        txtPrice.Text = "";
        txtDate.Text="";
        txtMin.Text = "";
        txtMax.Text = "";
    }
}