using System.Collections.ObjectModel;
using SoundByte.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SoundByte.ViewModels;

public partial class SoundByteViewModel(AppSettingsService settings) : ObservableObject
{
	private readonly SoundByteService _service = new();
	private SoundByteGroupViewModel? _selectedGroup;
	public AppSettingsService Settings { get; } = settings;

	public ObservableCollection<SoundByteGroupViewModel> Groups { get; } = [];

	public SoundByteGroupViewModel? SelectedGroup
	{
		get => _selectedGroup;
		set => SetProperty(ref _selectedGroup, value);
	}

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
