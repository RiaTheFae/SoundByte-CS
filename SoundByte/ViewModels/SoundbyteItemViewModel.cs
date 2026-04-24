using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SoundByte.Models;

namespace SoundByte.ViewModels;

public partial class SoundbyteItemViewModel(SoundbyteItem item) : ObservableObject
{
	private readonly SoundbyteItem _item = item;

	public SoundbyteItem Item => _item;
	public string Name => _item.Name;
	public SoundbyteColors Color => _item.Color;

	[RelayCommand]
	private async Task Remove()
	{
		throw (new NotImplementedException());
	}

	[RelayCommand]
	private async Task Play()
	{
		throw (new NotImplementedException());
	}

	[RelayCommand]
	private async Task Rename(string newName)
	{
		_item.Name = newName;
		OnPropertyChanged(nameof(Name));
	}
}
