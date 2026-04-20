using SoundByte.Models;
using SoundByte.ViewModels;

namespace SoundByte;

public partial class MainPage : ContentPage
{
	readonly private SoundByteViewModel viewModel;

	public MainPage()
	{
		InitializeComponent();
		viewModel = new SoundByteViewModel();
		BindingContext = viewModel;
		MainThread.BeginInvokeOnMainThread(async () => await viewModel.Initialize());
	}

	private async void OnAddSoundbyteClicked(object? sender, EventArgs e)
	{
		if (!string.IsNullOrWhiteSpace(AddSoundbyteNameEntry.Text) && !string.IsNullOrWhiteSpace(AddSoundbyteFilePathEntry.Text))
		{
			var defaultGroup = viewModel.Groups.First(g => g.Name == "Default");
			var item = new SoundByteItem(AddSoundbyteNameEntry.Text, AddSoundbyteFilePathEntry.Text);

			defaultGroup.AddItem(item);
			AddSoundbyteNameEntry.Text = null;
			AddSoundbyteFilePathEntry.Text = null;
		}
		else
		{
			await DisplayAlertAsync("Failed to add Soundbyte", "One or more fields were empty", "OK");
		}
		await viewModel.SaveGroups();
	}

	private async void ChooseFile(object sender, EventArgs e)
	{
		var result = await FilePicker.PickAsync();
		if (result != null)
		{
			AddSoundbyteFilePathEntry.Text = result.FullPath;
		}
	}
}