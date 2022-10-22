using NLipsum.Core.Features;
using NLipsum.Core.Models;

namespace NLipsum.Core.Factories;

/// <summary>
///     Class WordFactory.
///     Implements the <see cref="NLipsum.Core.Factories.ITextFeatureFactory" />
/// </summary>
/// <seealso cref="NLipsum.Core.Factories.ITextFeatureFactory" />
internal class WordFactory : ITextFeatureFactory
{
    /// <summary>
    ///     Creates the specified length.
    /// </summary>
    /// <param name="lengths">The length.</param>
    /// <param name="formatString">The format string.</param>
    /// <returns>ITextFeature.</returns>
    public ITextFeature Create(LipsumLengths lengths, string? formatString = null)
    {
        var word = lengths switch
        {
            LipsumLengths.Short => Word.Short,
            LipsumLengths.Medium => Word.Medium,
            LipsumLengths.Long => Word.Long,
            _ => throw new ArgumentOutOfRangeException(nameof(lengths), lengths, null)
        };

        word.FormatString = formatString ?? FormatStrings.Get(FormatStringTypes.Default);
        return word;
    }
}