using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using SoundByte.Models;
using SoundByte.ViewModels;
using SoundByte.Views;

namespace SoundByte;

public partial class MainPage : ContentPage
{
	readonly private SoundByteViewModel viewModel;
	private Task? _initializeTask;
	public MainPage()
	{
		InitializeComponent();
		viewModel = new SoundByteViewModel();
		BindingContext = viewModel;
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		_initializeTask ??= viewModel.Initialize();
		await _initializeTask;
	}

	private async void CreateSoundbyte(object sender, EventArgs e)
	{
		var NewSoundbyte = new AddSoundbytePopup();

		IPopupResult<SoundbyteItem?> NewSoundbyteResult = await this.ShowPopupAsync<SoundbyteItem?>((View)NewSoundbyte, new PopupOptions { }, CancellationToken.None);

		if (NewSoundbyteResult.Result is not null && viewModel.SelectedGroup is not null)
		{
			viewModel.SelectedGroup.AddItem(NewSoundbyteResult.Result);
			await viewModel.SaveGroups();
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
}
