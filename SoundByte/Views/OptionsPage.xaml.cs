using SoundByte.Services;
using SoundByte.ViewModels;

namespace SoundByte.Views;

public partial class OptionsPage : ContentPage
{
	private readonly SoundbyteOptionsViewModel _viewModel;
	private readonly AppSettingsService _settings;
	public OptionsPage(SoundbyteOptionsViewModel viewModel, AppSettingsService settings)
	{
		InitializeComponent();
		_viewModel = viewModel;
		_settings = settings;
		BindingContext = viewModel;
	}
}