using CommunityToolkit.Maui.Views;
using SoundByte.Models;

namespace SoundByte.Views;

public partial class AddSoundbytePopup : Popup<SoundbyteItem?>
{
	public AddSoundbytePopup()
	{
		InitializeComponent();
		AddSoundbyteColorPicker.ItemsSource = Enum.GetValues<SoundbyteColors>().ToList();
		AddSoundbyteColorPicker.SelectedIndex = 0;
	}

	private async void AddSoundbyteClicked(object? sender, EventArgs e)
	{
		if (!string.IsNullOrWhiteSpace(AddSoundbyteNameEntry.Text) && !string.IsNullOrWhiteSpace(AddSoundbyteFilePathEntry.Text))
		{
			var item = new SoundbyteItem(AddSoundbyteNameEntry.Text, AddSoundbyteFilePathEntry.Text, (SoundbyteColors)AddSoundbyteColorPicker.SelectedIndex);

			await CloseAsync(item);
		}
		else
		{
			ErrorLabel.IsVisible = true;
		}
	}
	private async void Cancel(object sender, EventArgs e)
	{
		await CloseAsync();
	}
	private static readonly string[] windowsFileTypes = [".mp3", ".wav", ".m4a", ".flac", ".aac", ".ogg", ".wma"];
	private static readonly string[] androidFileTypes = ["audio/*"];
	private static readonly PickOptions pickOptions = new()
	{
		PickerTitle = "Select an Audio File",
		FileTypes = new FilePickerFileType(
		new Dictionary<DevicePlatform, IEnumerable<string>>
		{
		{ DevicePlatform.WinUI, windowsFileTypes },
		{ DevicePlatform.Android, androidFileTypes }
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
