using Microsoft.Extensions.Logging;
using MonkeyFinder.Services;
using MonkeyFinder.View;

namespace MonkeyFinder;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		// Now let's do some linking between the monkey service: which provide data query service to the view model
		// and the viewmodel: which defines what data and when it needs to be displayed
		// and the view: which defines how to display the data
		builder.Services.AddSingleton<MonkeyService>();
		builder.Services.AddSingleton<MonkeysViewModel>();
		builder.Services.AddSingleton<MainPage>(); // use the dependency service to register the main page
												   // the Shell itself and the navigation service and the inflation service and the creation service will not only be able to create the page, but if you register the page with the dependency service, it will be able to grab that page from the service and  all it's dependencies

		return builder.Build();
	}
}
