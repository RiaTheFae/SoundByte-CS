using System.Collections.ObjectModel;
using SoundByte.Models;
using SoundByte.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SoundByte.ViewModels;

public partial class SoundByteViewModel : ObservableObject
{
	private readonly SoundByteService _service = new();

	public ObservableCollection<SoundByteGroupViewModel> Groups { get; } = [];

	[ObservableProperty]
	public partial SoundByteGroupViewModel? SelectedGroup { get; set; }

	public async Task Initialize()
	{
		var groups = await _service.LoadAsync();
		Groups.Clear();
		foreach (var group in groups)
			Groups.Add(new SoundByteGroupViewModel(group));
		SelectedGroup = Groups[0];
	}

	public async Task SaveGroups()
	{
		await _service.SaveAsync([.. Groups.Select(g => g.Group)]);
	}
}