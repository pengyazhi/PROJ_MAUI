using Microsoft.Maui.Controls.Platform;
using projAPP_MAUI.Models;
using System.Text;

namespace projAPP_MAUI.View;

public partial class PgLogin : ContentPage
{
	public PgLogin()
	{
		InitializeComponent();
	}
	CLoginStatus _login = new CLoginStatus();
	CPageStatus _pgstatus = new CPageStatus();
    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
		App app = Application.Current as App;
        string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string path = Path.Combine(folder, "password.txt");
        if (txtaccount.Text == _login.accountForTD && txtpassword.Text == File.ReadAllText(path, Encoding.UTF8))
		{
			app.lblHome = _pgstatus.travelDate;
            await Navigation.PushAsync(new PgHome());
			return;
        }
		await DisplayAlert("登入錯誤", "帳號或密碼有誤,請重新輸入", "確定");
		txtaccount.Text = "";
		txtpassword.Text = "";

	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		txtaccount.Text = "";
		txtpassword.Text = "";
    }

    private void btnDemo_Clicked(object sender, EventArgs e)
    {
        txtaccount.Text = "Admin";
        string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); 
        string path = Path.Combine(folder, "password.txt");
        txtpassword.Text = File.ReadAllText(path, Encoding.UTF8);
    }
}