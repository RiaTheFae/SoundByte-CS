using System.Collections.ObjectModel;

namespace SoundByte.Models;

public class SoundByteGroup
{
	required public string Name { get; set; }
	public bool IsDefault { get; set; }
	public ObservableCollection<SoundbyteItem> Items { get; set; } = [];

	public SoundByteGroup() { }

	public SoundByteGroup(string name) => Name = name;

	public void AddItem(SoundbyteItem item) => Items.Add(item);

	public void RemoveItem(SoundbyteItem item) => Items.Remove(item);
}
