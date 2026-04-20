namespace SoundByte.Models;

public class SoundByteItem
{
    public string Name { get; set; }
    public string FilePath { get; set; }
    public int Color { get; set; }
    public SoundByteItem() { }

    public SoundByteItem(string name, string filePath, Colors color)
    {
        Name = name;
        FilePath = filePath;
        Color = (int)color;
    }
}