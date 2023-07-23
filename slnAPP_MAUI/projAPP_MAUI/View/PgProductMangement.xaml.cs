
using projAPP_MAUI.Models;
using projAPP_MAUI.ViewModels;


namespace projAPP_MAUI.View;

public partial class PgProductMangement : ContentPage
{
    CProducts _current= null;
    CPageStatus status = new CPageStatus();
    CBtnStatus btnStatus = new CBtnStatus();
    
    public PgProductMangement()
	{
		InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        App app = Application.Current as App;
        if (app.isEditor)
        {
            addProduct();
            removeProduct();
        }
    }

    private void removeProduct()
    {
       App app = Application.Current as App;
        if (!app.isAddProduct)
        {
            lblCRUD.Text = status.removeProduct;
            if (app.selectedProdSN > 0)
            {
                btn�s�W.IsVisible = false;
                _current = app.allProdForList.FirstOrDefault(p => p.�y���� == app.selectedProdSN);
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
    }

    private void addProduct()
    {
        App app = Application.Current as App;
        if (app.isAddProduct)
        {
            lblCRUD.Text = status.addProduct;
            clear();
            btn�R��.IsVisible = false;
        }
    }

    protected override void OnDisappearing()
    {
        App app = Application.Current as App;
        app.selectedProdSN = -1;
        app.isAddProduct = false;
       new CProductViewModels();
    }
    bool isFirstAdd = true;
    private async void btnAdd_Clicked(object sender, EventArgs e)
    {
        if (isFirstAdd 
            && !string.IsNullOrEmpty(txtName.Text)
            && !string.IsNullOrEmpty(txtSupplier.Text)
            && !string.IsNullOrEmpty(txtPrice.Text)
            && !string.IsNullOrEmpty(txtDate.Text)
            && !string.IsNullOrEmpty(txtMin.Text)
            && !string.IsNullOrEmpty(txtMax.Text)
            )
        {
            isFirstAdd = false;
            btn�s�W.Text = btnStatus.addNext;
        }
        if(!string.IsNullOrEmpty(txtName.Text) 
            && !string.IsNullOrEmpty(txtSupplier.Text)
            && !string.IsNullOrEmpty(txtPrice.Text)
            && !string.IsNullOrEmpty(txtDate.Text)
            && !string.IsNullOrEmpty(txtMin.Text)
            && !string.IsNullOrEmpty(txtMax.Text)) 
        {
            int sn = Preferences.Default.Get("COUNT", 0);
            sn++;
            Preferences.Default.Set("COUNT", sn);
            Preferences.Default.Set("N" + sn, txtName.Text);
            Preferences.Default.Set("S" + sn, txtSupplier.Text);
            Preferences.Default.Set("P" + sn, txtPrice.Text);
            Preferences.Default.Set("D" + sn, txtDate.Text);
            Preferences.Default.Set("MIN" + sn, txtMin.Text);
            Preferences.Default.Set("MAX" + sn, txtMax.Text);
            clear();
        }
        else
        {
            await DisplayAlert("����","�ж�g�����T","�T�w");
        }
            
    }

    private void btnList_Clicked(object sender, EventArgs e)
    {
        #region ���J�ӫ~
        //int sn = Preferences.Default.Get("COUNT", 0);
        //if (sn == 0)
        //    return;
        //List<CProducts> products = new List<CProducts>();
        //for (int i = 1; i <= sn; i++)
        //{
        //    string KeyN = "N" + i;
        //    string KeyS = "S" + i;
        //    string KeyP = "P" + i;
        //    string KeyD = "D" + i;
        //    string KeyMin = "MIN" + i;
        //    string KeyMax = "MAX" + i;
        //    if (Preferences.Default.ContainsKey(KeyN))
        //    {
        //        CProducts x = new CProducts();
        //        x.product = Preferences.Default.Get(KeyN, "");
        //        x.supplier = Preferences.Default.Get(KeyS, "");
        //        x.price = Convert.ToInt32(Preferences.Default.Get(KeyP, ""));
        //        x.date = Preferences.Default.Get(KeyD, "");
        //        x.min = Convert.ToInt32(Preferences.Default.Get(KeyMin, ""));
        //        x.max = Convert.ToInt32(Preferences.Default.Get(KeyMax, ""));
        //        x.�y���� = i;
        //        products.Add(x);
        //    }
        //}
        //if (products.Count == 0)
        //    return;
        //(Application.Current as App).allProdForList = products;
        #endregion
        Navigation.PushAsync(new PgProductList());
    }

    private async void btnDelete_Clicked(object sender, EventArgs e)
    { 
        bool result = await DisplayAlert("����", "�T�w�n�R�����ӫ~?", "�T�w", "����");
        if(result) 
        {
            if (_current != null)
            {
                Preferences.Default.Remove("N" + _current.�y����.ToString());
                Preferences.Default.Remove("S" + _current.�y����.ToString());
                Preferences.Default.Remove("P" + _current.�y����.ToString());
                Preferences.Default.Remove("D" + _current.�y����.ToString());
                Preferences.Default.Remove("MIN" + _current.�y����.ToString());
                Preferences.Default.Remove("MAX" + _current.�y����.ToString());
            }
            _current = null;
            clear();
            await Navigation.PopAsync();
        }
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


    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    //public CProducts SetObjectToBE()
    //{
    //    CProducts M_CProducts = new CProducts();
    //    M_CProducts.product = txtName.Text;
    //    M_CProducts.supplier = txtSupplier.Text;
    //    M_CProducts.price = Convert.ToInt32(txtPrice.Text);
    //    M_CProducts.date = txtDate.Text;
    //    M_CProducts.min = Convert.ToInt32(txtMin.Text);
    //    M_CProducts.max = Convert.ToInt32(txtMax.Text);
    //    return M_CProducts;
    //}
}