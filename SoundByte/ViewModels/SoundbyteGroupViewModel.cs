using SoundByte.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace SoundByte.ViewModels;

public partial class SoundByteGroupViewModel : ObservableObject
{
	private readonly SoundByteGroup _group;
	public SoundByteGroup Group => _group;
	public string Name => _group.Name;
	public bool IsDefault => _group.IsDefault;
	public ObservableCollection<SoundbyteItemViewModel> Items { get; } = [];

	public SoundByteGroupViewModel(SoundByteGroup group)
	{
		_group = group;
		foreach (var item in group.Items)
			Items.Add(new SoundbyteItemViewModel(item));
	}

	public void AddItem(SoundbyteItem item)
	{
		_group.AddItem(item);
		Items.Add(new SoundbyteItemViewModel(item));
	}

	public void RemoveItem(SoundbyteItemViewModel itemVm)
	{
		_group.RemoveItem(itemVm.Item);
		Items.Remove(itemVm);
	}

}