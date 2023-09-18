using MM.CAAM.MAUI.Movil.ViewModels.Home;

namespace MM.CAAM.MAUI.Movil.Views.Home;

public partial class Inicio : ContentPage
{
    //VIEWMODEL
    private bool AcceptBack;


    private InicioViewModel ViewModel
    {
        get { return BindingContext as InicioViewModel; }
        set { BindingContext = value; }
    }

    public Inicio()
	{
		InitializeComponent();

        BindingContext = new InicioViewModel();

        Connectivity.ConnectivityChanged += ConnectivityChangedHandler;
    }


    //VIEWMODEL
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.OnAppearing();
    }
    //VIEWMODEL
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        ViewModel.OnDisappearing();
    }

    //MAIN-PAGE
    protected override bool OnBackButtonPressed()
    {
        if (AcceptBack)
            return false;

        PromptForExit();
        return true;
    }

    //MAIN-PAGE
    private async void PromptForExit()
    {
        if (await DisplayAlert("", "Esta seguro que desea salir ?", "Si", "No"))
        {
            AcceptBack = true;
            ExitApp();
        }
    }

    //MAIN-PAGE 
    private void ExitApp()
    {
        Application.Current.Quit();
    }

    //ALL PAGES
    private void ConnectivityChangedHandler(object sender, ConnectivityChangedEventArgs e)
    {
        Device.BeginInvokeOnMainThread(() =>
        {

            //string avisoStatus = string.Empty;

            //switch (Connectivity.NetworkAccess)
            //{
            //    case NetworkAccess.None:
            //        avisoStatus = $"Sin conexión";
            //        break;
            //    case NetworkAccess.Local:
            //        avisoStatus = $"Solo acceso a red Local";
            //        break;
            //    case NetworkAccess.ConstrainedInternet:
            //        avisoStatus = $"Acceso a internet Limitado";
            //        break;
            //    case NetworkAccess.Unknown:
            //        avisoStatus = $"Estado de conexión Desconocido";
            //        break;
            //    case NetworkAccess.Internet:
            //        avisoStatus = $"";
            //        break;
            //}

            //if (string.IsNullOrEmpty(avisoStatus))
            //{
            //    frameAviso.IsVisible = false;
            //}
            //else
            //{
            //    frameAviso.IsVisible = true;
            //}

            //lblAviso.Text = avisoStatus;
        });
    }
}