using MM.CAAM.MAUI.Movil.Views.Pages.FlyoutSample;

namespace MM.CAAM.MAUI.Movil;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);

        await animar_dotnet_bot();

        //await Navigation.PushAsync(new Views.Pages.TabbedPageSample.TabbedPageSample()); //TABBED
        //await Navigation.PushAsync(new FlyoutMenuPage());
        await Navigation.PushModalAsync(new FlyoutMenuPage(), false);
    }
	 
    private async Task animar_dotnet_bot()
    {
        //var rotate = bot.RotateTo(bot.Rotation + 90, 1000, Easing.Linear);  //Gira
        var scale = bot.ScaleTo(bot.Scale * 1.25, 1000, Easing.BounceIn);   //Brinca  
        //var translate = bot.TranslateTo(bot.X, bot.Y + 100, 1000);          //Translate   
        //await Task.WhenAll(rotate, scale);
        await Task.WhenAll(scale);

        //var animation = new Animation((value) =>
        //{
        //    bot.Opacity= value;
        //}, 0, 1); 
        //bot.Animate("Opacity", animation, length: 1000);


    }
}

