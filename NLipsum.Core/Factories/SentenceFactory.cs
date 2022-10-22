using NLipsum.Core.Features;
using NLipsum.Core.Models;

namespace NLipsum.Core.Factories;

/// <summary>
///     Class SentenceFactory.
///     Implements the <see cref="NLipsum.Core.Factories.ITextFeatureFactory" />
/// </summary>
/// <seealso cref="NLipsum.Core.Factories.ITextFeatureFactory" />
internal class SentenceFactory : ITextFeatureFactory
{
    /// <summary>
    ///     Creates the specified length.
    /// </summary>
    /// <param name="lengths">The length.</param>
    /// <param name="formatString">The format string.</param>
    /// <returns>ITextFeature.</returns>
    public ITextFeature Create(LipsumLengths lengths, string? formatString = null)
    {
        var sentence = lengths switch
        {
            LipsumLengths.Short => Sentence.Short,
            LipsumLengths.Medium => Sentence.Medium,
            LipsumLengths.Long => Sentence.Long,
            _ => throw new ArgumentOutOfRangeException(nameof(lengths), lengths, null)
        };

        sentence.FormatString = formatString ?? FormatStrings.Get(FormatStringTypes.SentencePhrase);
        return sentence;
    }
}