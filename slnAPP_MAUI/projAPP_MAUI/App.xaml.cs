using projAPP_MAUI.Models;
using projAPP_MAUI.View;
using projAPP_MAUI.ViewModels;
using System.Diagnostics.Tracing;
using System.Security.Cryptography.X509Certificates;

namespace projAPP_MAUI;

public partial class App : Application
{
	public List<CProducts> allProdForList { get; set; }

	public List<CKeywordViewModel> keywords { get; set; }
    public int selectedProdSN { get; set; }
	public App()
	{
		InitializeComponent();
        MainPage = new NavigationPage( new PgProductMangement());
		selectedProdSN = -1;
       
    }
}
