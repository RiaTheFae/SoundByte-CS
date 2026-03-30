namespace SoundByte.Models;

public class SoundByteItem
{
    public string Name { get; set; }
    public string FilePath { get; set; }
    public Color Color { get; set; }
    public SoundByteItem() { }

    public SoundByteItem(string name, string filePath)
    {
        Name = name;
        FilePath = filePath;
        Color = Color.FromRgb(255, 255, 255);
    }
}