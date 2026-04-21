using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SoundByte.Models;
using SoundByte.Services;
namespace SoundByte.ViewModels;

public class SoundByteViewModel : INotifyPropertyChanged
{
    private readonly SoundByteService service = new();
    public ObservableCollection<SoundByteGroup> Groups { get; set; } = [];
    public event PropertyChangedEventHandler? PropertyChanged;
    private SoundByteGroup? _selectedGroup;
    public SoundByteGroup? SelectedGroup
    {
        get => _selectedGroup;
        set
        {
            _selectedGroup = value;
            OnPropertyChanged();
        }
    }
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
       => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    public async Task Initialize()
    {
        var groups = await service.LoadAsync();
        Groups.Clear();
        foreach (var group in groups)
        {
            Groups.Add(group);
        }
        SelectedGroup = Groups[0];
    }

    public async Task SaveGroups()
    {
        await service.SaveAsync([.. Groups]);
    }
}