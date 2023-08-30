using CommunityToolkit.Maui;

namespace MM.CAAM.MAUI.Movil;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        ////OLD Cambio de color status bar, CommunityToolkit.Maui
        //builder
        //	.UseMauiApp<App>()
        //	.ConfigureFonts(fonts =>
        //	{
        //		fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        //		fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        //	});

        ////NEW se agrega: .UseMauiCommunityToolkit()
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        return builder.Build();
    }
}
