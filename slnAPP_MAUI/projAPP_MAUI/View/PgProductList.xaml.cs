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
        bindingSource();
        isEditor();
    }
    CPageStatus status = new CPageStatus();
    private void isEditor()
    {
        App app = Application.Current as App;
       
        if (app.isEditor)
        {
            btnPlus.IsVisible = true;
            lblListName.Text = status.crud;
         }
        else
        {
            btnPlus.IsVisible = false;
            lblListName.Text = status.list;
        }
    }

    private void bindingSource()
    {
        App app = Application.Current as App;
        if (app.allProdForList != null)
        {
            cvList.ItemsSource = app.allProdForList;
        }
    }

    private void cvList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        App app = Application.Current as App;
        if (app.isEditor)
        {
            app.selectedProdSN = (e.CurrentSelection.FirstOrDefault() as CProducts).流水號;
            Navigation.PushAsync(new PgProductMangement());
        }
        else
        {
            app.selectedProdSN = (e.CurrentSelection.FirstOrDefault() as CProducts).流水號;
            Navigation.PushAsync(new PgProductInfo());
        } 
    } 


    private void btnPlus_Clicked(object sender, EventArgs e)
    {
        App app = Application.Current as App;
        app.isAddProduct = true;
        Navigation.PushAsync(new PgProductMangement());
    }

    private void btnHome_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}