using SoundByte.Models;
using System.Globalization;

namespace SoundByte.Converters;

public class SoundByteColorConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return (SoundbyteColors)value! switch
        {
            SoundbyteColors.White => Colors.White,
            SoundbyteColors.Black => Colors.Black,
            SoundbyteColors.RoyalBlue => Colors.RoyalBlue,
            SoundbyteColors.HotPink => Colors.HotPink,
            SoundbyteColors.Firebrick => Colors.Firebrick,
            SoundbyteColors.Gold => Colors.Gold,
            SoundbyteColors.Lime => Colors.Lime,
            SoundbyteColors.Maroon => Colors.Maroon,
            SoundbyteColors.Navy => Colors.Navy,
            SoundbyteColors.Olive => Colors.Olive,
            SoundbyteColors.Orchid => Colors.Orchid,
            SoundbyteColors.Plum => Colors.Plum,
            SoundbyteColors.SlateGray => Colors.SlateGray,
            SoundbyteColors.Tan => Colors.Tan,
            SoundbyteColors.Turquoise => Colors.Turquoise,
            _ => Colors.White
        };
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}