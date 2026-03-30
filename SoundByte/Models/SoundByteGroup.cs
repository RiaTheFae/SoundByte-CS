using System.Collections.ObjectModel;

namespace SoundByte.Models;

public class SoundByteGroup
{
    public string Name { get; set; }
    ObservableCollection<SoundByteItem> Items { get; set; } = [];

    public SoundByteGroup() { }

    public SoundByteGroup(string name) => Name = name;

    public void AddItem(SoundByteItem item) => Items.Add(item);

    public void RemoveItem(SoundByteItem item) => Items.Remove(item);

    public void MoveUp(SoundByteItem item)
    {
        int index = Items.IndexOf(item);
        if (index > 0)
        {
            Items.RemoveAt(index);
            Items.Insert(index - 1, item);
        }
    }

    public void MoveDown(SoundByteItem item)
    {
        int index = Items.IndexOf(item);
        if (index < Items.Count - 1)
        {
            Items.RemoveAt(index);
            Items.Insert(index + 1, item);
        }
    }
}