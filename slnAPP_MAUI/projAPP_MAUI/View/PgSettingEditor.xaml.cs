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
            await DisplayAlert("提示", "修改密碼成功!請重新登入","確定");
            await Navigation.PushAsync(new PgLogin());
        }
        else if(string.IsNullOrEmpty(oldPassword.Text) || string.IsNullOrEmpty(newPassword.Text))
        {
            await DisplayAlert("提示", "修改密碼失敗!請確認新密碼與舊密碼是否都有填寫", "確定");
            clear();
        }
        else
        {
            await DisplayAlert("提示", "修改密碼失敗!請確認新密碼與舊密碼不同", "確定");
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