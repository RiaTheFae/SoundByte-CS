using CommunityToolkit.Mvvm.ComponentModel;

namespace SoundByte.Services
{
	public class AppSettingsService : ObservableObject
	{
		private const string MaxWidthKey = "MaxWidth";
		private const int MaxWidthDefault = 6;

		public int MaxWidth
		{
			get => Preferences.Get(MaxWidthKey, MaxWidthDefault);
			set
			{
				Preferences.Set(MaxWidthKey, value);
				OnPropertyChanged();
			}
		}
	}
}
