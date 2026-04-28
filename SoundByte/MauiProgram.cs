using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SoundByte.Services;
using SoundByte.ViewModels;
using SoundByte.Views;

namespace SoundByte;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("NotoEmoji-VariableFont_wght.ttf", "NotoEmoji");
			});
		builder.Services.AddSingleton<AppSettingsService>();
		builder.Services.AddSingleton<SoundByteViewModel>();
		builder.Services.AddSingleton<SoundbyteOptionsViewModel>();
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<OptionsPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
