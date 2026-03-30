using System.Collections.ObjectModel;
using SoundByte.Models;
using SoundByte.ViewModels;

namespace SoundByte;

public partial class MainPage : ContentPage
{
	private SoundByteViewModel viewModel;

	public MainPage()
	{
		InitializeComponent();
		viewModel = new SoundByteViewModel();
		BindingContext = viewModel;

		MainThread.BeginInvokeOnMainThread(async () => await viewModel.Initialize());
	}

	private async void OnAddSoundByteClicked(object? sender, EventArgs e)
	{
		var defaultGroup = viewModel.Groups.First(g => g.Name == "Default");
		var item = new SoundByteItem(SoundbyteNameInput.Text, "");
		defaultGroup.AddItem(item);
		SoundbyteNameInput.Text = "";

		await viewModel.SaveGroups();
	}
}