using System.Collections.ObjectModel;

namespace SoundByte.Models;

public class SoundByteGroup
{
    public string Name { get; set; }
    public ObservableCollection<SoundByteItem> Items { get; set; } = [];

    public SoundByteGroup() { }

    public SoundByteGroup(string name) => Name = name;

    public void AddItem(SoundByteItem item) => Items.Add(item);

    public void RemoveItem(SoundByteItem item) => Items.Remove(item);
}