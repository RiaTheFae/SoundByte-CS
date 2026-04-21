using System.Text.Json;
using SoundByte.Models;

namespace SoundByte.Services;

internal class SoundByteService
{
    private readonly string filePath = Path.Combine(FileSystem.AppDataDirectory, "soundbytes.json");
    private static readonly JsonSerializerOptions jsonOptions = new()
    {
        WriteIndented = true
    };
    public async Task SaveAsync(List<SoundByteGroup> groups)
    {
        string json = JsonSerializer.Serialize(groups, jsonOptions);
        await File.WriteAllTextAsync(filePath, json);
    }

    public async Task<List<SoundByteGroup>> LoadAsync()
    {
        List<SoundByteGroup> groups;
        if (!File.Exists(filePath))
            groups = [];
        else
        {
            string json = await File.ReadAllTextAsync(filePath);
            groups = JsonSerializer.Deserialize<List<SoundByteGroup>>(json, jsonOptions) ?? [];
        }
        if (!groups.Exists(g => g.IsDefault))
        {
            groups.Insert(0, new SoundByteGroup("Default") { IsDefault = true });
        }
        return groups;
    }
}