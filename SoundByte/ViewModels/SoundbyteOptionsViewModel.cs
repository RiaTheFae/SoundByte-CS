using CommunityToolkit.Mvvm.ComponentModel;
using SoundByte.Services;

namespace SoundByte.ViewModels
{
	public partial class SoundbyteOptionsViewModel(AppSettingsService settings) : ObservableObject
	{
		[ObservableProperty]
		private int _MaxWidth = settings.MaxWidth;

		partial void OnMaxWidthChanged(int value)
		{
			settings.MaxWidth = value;
		}
	}
}
