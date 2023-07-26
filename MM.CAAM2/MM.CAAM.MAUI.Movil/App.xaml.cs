using MM.CAAM.MAUI.Movil.Views.Pages.FlyoutSample;

namespace MM.CAAM.MAUI.Movil;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        //MainPage = new AppShell();  //Pagina de inicio
        //MainPage = new Views.Pages.FlyoutSample.FlyoutSamplePage();	//Pagina de inicio
        MainPage = new Views.Pages.TabbedPageSample.TabbedPageSample();
    }
}
