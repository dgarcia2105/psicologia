using MM.CAAM.MAUI.Movil.Views.Pages.FlyoutSample;

namespace MM.CAAM.MAUI.Movil;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        //MainPage = new AppShell();  //Pagina de inicio
        //MainPage = new Views.Pages.FlyoutSample.FlyoutSamplePage();	//Pagina de inicio
        //MainPage = new Views.Pages.TabbedPageSample.TabbedPageSample();
        //MainPage = new Views.Pages.TabbedPageSample.TabbedPageSample();

        //var navPage = new NavigationPage(new MainPage());         //NAVIGATION
        //navPage.BarBackground = Colors.Chocolate;
        //navPage.BarTextColor = Colors.White;

        //MainPage = new MainPage();                   //PAGINA PRINCIPAL
        //MainPage = new Views.TabedPageMain();
        MainPage = new Views.LoginPage();

        //MainPage = new NavigationPage(new MainPage()); //DEFAULT APARECE NAVIGATION PAGE
    }
}
