using System.Collections.ObjectModel;
using SoundByte.Models;
using SoundByte.Services;
namespace SoundByte.ViewModels;

public class SoundByteViewModel
{
    private readonly SoundByteService service = new();

    public ObservableCollection<SoundByteGroup> Groups { get; set; } = [];
    public async Task Initialize()
    {
        var groups = await service.LoadAsync();
        Groups.Clear();
        foreach (var group in groups)
        {
            Groups.Add(group);
        }
    }

    public async Task SaveGroups()
    {
        await service.SaveAsync([.. Groups]);
    }
}