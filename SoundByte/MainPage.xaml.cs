using System.Collections.ObjectModel;

namespace SoundByte;

public partial class MainPage : ContentPage
{
	public ObservableCollection<string> SoundBytes { get; set; } = [];
	public MainPage()
	{
		SoundBytes.Add("Test");

		InitializeComponent();
		BindingContext = this;
	}

	private void OnAddSoundByteClicked(object? sender, EventArgs e)
	{
		SoundBytes.Add(SoundbyteNameInput.Text);
		SoundbyteNameInput.Text = "";
	}
}
