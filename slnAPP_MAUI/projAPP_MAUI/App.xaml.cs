using projAPP_MAUI.Models;
using projAPP_MAUI.View;
using projAPP_MAUI.ViewModels;
using System.Diagnostics.Tracing;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace projAPP_MAUI;

public partial class App : Application
{
	public List<CProducts> allProdForList { get; set; }
	
   
    public string keyword { get; set; }
    public int selectedProdSN { get; set; }
	public string lblHome { get; set; }
	public bool isEditor { get; set; }
	public bool isAddProduct { get; set; }

	public App()
	{
		InitializeComponent();
        MainPage = new NavigationPage( new PgLogin());
		selectedProdSN = -1;
        //string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        //string path = Path.Combine(folder, "password.txt");
        //File.WriteAllText(path, "abc123", Encoding.UTF8);
    }
}
