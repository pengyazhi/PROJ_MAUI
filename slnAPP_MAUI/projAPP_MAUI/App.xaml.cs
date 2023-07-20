using projAPP_MAUI.View;

namespace projAPP_MAUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage( new PgHome());
	}
}
