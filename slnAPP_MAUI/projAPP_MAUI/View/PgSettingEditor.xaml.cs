using System.Text;

namespace projAPP_MAUI.View;

public partial class PgSettingEditor : ContentPage
{
	public PgSettingEditor()
	{
		InitializeComponent();
	}

    private async void btnConfirmPasswor_Clicked(object sender, EventArgs e)
    {
        string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string path = Path.Combine(folder, "password.txt");
        if (oldPassword.Text == File.ReadAllText(path, Encoding.UTF8) && oldPassword.Text != newPassword.Text)
        {
            File.WriteAllText(path, newPassword.Text, Encoding.UTF8);
            await DisplayAlert("����", "�ק�K�X���\!�Э��s�n�J","�T�w");
            await Navigation.PushAsync(new PgLogin());
        }
        else if(string.IsNullOrEmpty(oldPassword.Text) || string.IsNullOrEmpty(newPassword.Text))
        {
            await DisplayAlert("����", "�ק�K�X����!�нT�{�s�K�X�P�±K�X�O�_������g", "�T�w");
            clear();
        }
        else
        {
            await DisplayAlert("����", "�ק�K�X����!�нT�{�s�K�X�P�±K�X���P", "�T�w");
            clear();
        }
        
    }
    void clear()
    {
        oldPassword.Text = "";
        newPassword.Text = "";
    }
    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}