using projAPP_MAUI.Models;
using projAPP_MAUI.View;
using System.Security.Cryptography.X509Certificates;

namespace projAPP_MAUI;

public partial class App : Application
{
	public List<CProducts> allProdForList = new List<CProducts>();
	public int selectedProdSN { get; set; }
	public App()
	{
		InitializeComponent();
        MainPage = new NavigationPage( new PgProductMangement());
		selectedProdSN = -1;

    }
}
