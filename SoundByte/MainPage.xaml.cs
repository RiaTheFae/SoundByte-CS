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
		AddSoundbyteColorPicker.ItemsSource = Enum.GetValues<SoundbyteColors>().ToList();
		AddSoundbyteColorPicker.SelectedIndex = 0;
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await viewModel.Initialize();
	}

	private async void OnAddSoundbyteClicked(object? sender, EventArgs e)
	{
		if (!string.IsNullOrWhiteSpace(AddSoundbyteNameEntry.Text) && !string.IsNullOrWhiteSpace(AddSoundbyteFilePathEntry.Text))
		{
			var item = new SoundByteItem(AddSoundbyteNameEntry.Text, AddSoundbyteFilePathEntry.Text, (SoundbyteColors)AddSoundbyteColorPicker.SelectedIndex);

			viewModel.SelectedGroup.AddItem(item);
			AddSoundbyteNameEntry.Text = null;
			AddSoundbyteFilePathEntry.Text = null;
		}
		else
		{
			await DisplayAlertAsync("Failed to add Soundbyte", "One or more fields were empty", "OK");
		}
		await viewModel.SaveGroups();
	}
	private static readonly string[] fileTypes = [".mp3", ".wav", ".m4a", ".flac", ".aac", ".ogg", ".wma"];
	private static readonly PickOptions pickOptions = new()
	{
		PickerTitle = "Select an Audio File",
		FileTypes = new FilePickerFileType(
		new Dictionary<DevicePlatform, IEnumerable<string>>
		{
			{ DevicePlatform.WinUI, fileTypes }
		})
	};
	private async void ChooseFile(object sender, EventArgs e)
	{
		try
		{
			var result = await FilePicker.PickAsync(pickOptions);
			if (result != null)
			{
				AddSoundbyteFilePathEntry.Text = result.FullPath;
			}
		}
		catch (OperationCanceledException) { }
	}
}