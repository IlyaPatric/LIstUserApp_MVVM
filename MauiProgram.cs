using LIstUserApp.Model;
using LIstUserApp.Services;
using LIstUserApp.View;
using LIstUserApp.ViewModel;
using Microsoft.Extensions.Logging;

namespace LIstUserApp;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				//fonts.AddFont("fontello.ttf", "Icons");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<UserService>();

		builder.Services.AddSingleton<UserRepository>();

		builder.Services.AddTransient<MainViewModel>();
		builder.Services.AddTransient<DetailsViewModel>();

		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<DetailsPage>();

		return builder.Build();
	}
}
