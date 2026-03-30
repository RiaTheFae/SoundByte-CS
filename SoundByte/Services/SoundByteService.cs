using System.Collections.ObjectModel;
using System.Text.Json;
using SoundByte.Models;

namespace SoundByte.Services;

internal class SoundByteService
{
    private readonly string filePath = Path.Combine(FileSystem.AppDataDirectory, "soundbytes.json");

    public async Task SaveAsync(List<SoundByteGroup> items)
    {
        // Convert ObservableCollections to Lists for serialization
        var serializableGroups = items.Select(g => new
        {
            g.Name,
            Items = g.Items.ToList()
        }).ToList();

        string json = JsonSerializer.Serialize(serializableGroups);
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
            groups = JsonSerializer.Deserialize<List<SoundByteGroup>>(json) ?? [];
        }

        if (!groups.Any(g => g.Name == "Default"))
        {
            groups.Insert(0, new SoundByteGroup("Default"));
        }

        return groups;
    }
}