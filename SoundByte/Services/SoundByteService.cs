using System.Collections.ObjectModel;
using System.Text.Json;
using SoundByte.Models;

namespace SoundByte.Services;

internal class SoundByteService
{
    private readonly string filePath = Path.Combine(FileSystem.AppDataDirectory, "soundbytes.json");

    public async Task SaveAsync(List<SoundByteGroup> items)
    {
        string json = JsonSerializer.Serialize(items);
        await File.WriteAllTextAsync(filePath, json);
    }

    public async Task<List<SoundByteGroup>> LoadAsync()
    {
        if (!File.Exists(filePath))
            return [];

        string json = await File.ReadAllTextAsync(filePath);
        return JsonSerializer.Deserialize<List<SoundByteGroup>>(json) ?? [];
    }
}