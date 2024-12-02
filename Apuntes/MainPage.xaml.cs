namespace Apuntes
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void AlertClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alerta", "¿No sabes leer o que?", "Cerrar");
        }
    }

}
