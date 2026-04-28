namespace SoundByte.Models;

public class SoundbyteItem
{
	required public string Name { get; set; }
	required public string FilePath { get; set; }
	public SoundbyteColors Color { get; set; }
	public SoundbyteItem() { }

	public SoundbyteItem(string name, string filePath, SoundbyteColors color)
	{
		Name = name;
		FilePath = filePath;
		Color = color;
	}
}
