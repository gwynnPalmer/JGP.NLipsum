using NLipsum.Core.Features;
using NLipsum.Core.Models;

namespace NLipsum.Core.Factories;

/// <summary>
///     Class ParagraphFactory.
///     Implements the <see cref="NLipsum.Core.Factories.ITextFeatureFactory" />
/// </summary>
/// <seealso cref="NLipsum.Core.Factories.ITextFeatureFactory" />
internal class ParagraphFactory : ITextFeatureFactory
{
    /// <summary>
    ///     Creates the specified length.
    /// </summary>
    /// <param name="lengths">The length.</param>
    /// <param name="formatString">The format string.</param>
    /// <returns>ITextFeature.</returns>
    public ITextFeature Create(LipsumLengths lengths, string? formatString = null)
    {
        var paragraph = lengths switch
        {
            LipsumLengths.Short => Paragraph.Short,
            LipsumLengths.Medium => Paragraph.Medium,
            LipsumLengths.Long => Paragraph.Long,
            _ => throw new ArgumentOutOfRangeException(nameof(lengths), lengths, null)
        };

        paragraph.FormatString = formatString ?? FormatStrings.Get(FormatStringTypes.Default);
        return paragraph;
    }
}