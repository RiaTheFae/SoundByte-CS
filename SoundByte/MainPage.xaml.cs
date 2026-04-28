using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using Microsoft.Maui.Controls.Shapes;
using SoundByte.Models;
using SoundByte.Services;
using SoundByte.ViewModels;
using SoundByte.Views;

namespace SoundByte;

public partial class MainPage : ContentPage
{
	private Task? _initializeTask;
	private readonly SoundByteViewModel _viewModel;
	private readonly AppSettingsService _settings;
	public MainPage(SoundByteViewModel viewModel, AppSettingsService settings)
	{
		InitializeComponent();
		_viewModel = viewModel;
		_settings = settings;
		BindingContext = _viewModel;

	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		_initializeTask ??= _viewModel.Initialize();
		await _initializeTask;
	}

	private async void CreateSoundbyte(object sender, EventArgs e)
	{
		var NewSoundbyte = new AddSoundbytePopup();

		IPopupResult<SoundbyteItem?> NewSoundbyteResult = await this.ShowPopupAsync<SoundbyteItem?>((View)NewSoundbyte, new PopupOptions
		{
			Shape = new RoundRectangle
			{
				CornerRadius = new CornerRadius(8),
				Stroke = Color.FromRgb(41, 41, 41),
				StrokeThickness = 3
			},
			Shadow = new Shadow
			{
				Brush = Brush.DarkSlateGray,
				Opacity = 0.7f
			}
		},
			CancellationToken.None);

		if (NewSoundbyteResult.Result is not null && _viewModel.SelectedGroup is not null)
		{
			_viewModel.SelectedGroup.AddItem(NewSoundbyteResult.Result);
			await _viewModel.SaveGroups();
		}
	}
	private async void PlaySoundbyteItem(object sender, EventArgs e)
	{
		if (sender is Button button)
			if (button.Text == "▶")
			{
				button.Text = "▷";
			}
			else
			{
				button.Text = "▶";
			}
	}
	private async void OpenOptions(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(OptionsPage));
	}
}
