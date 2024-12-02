namespace Apuntes;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
    }

    private void btnClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}