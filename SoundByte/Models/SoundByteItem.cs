namespace SoundByte.Models;

public class SoundByteItem
{
    public string Name { get; set; }
    public string FilePath { get; set; }
    public SoundbyteColors Color { get; set; }
    public SoundByteItem() { }

    public SoundByteItem(string name, string filePath, SoundbyteColors color)
    {
        Name = name;
        FilePath = filePath;
        Color = color;
    }
}