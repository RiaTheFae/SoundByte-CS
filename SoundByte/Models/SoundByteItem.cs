namespace SoundByte.Models;

public class SoundbyteItem
{
	public string? Name { get; set; }
	public string? FilePath { get; set; }
	public SoundbyteColors Color { get; set; }
	public SoundbyteItem() { }

	public SoundbyteItem(string name, string filePath, SoundbyteColors color)
	{
		Name = name;
		FilePath = filePath;
		Color = color;
	}
}