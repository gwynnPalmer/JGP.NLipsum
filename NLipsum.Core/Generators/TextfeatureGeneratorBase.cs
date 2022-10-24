using System.Text.RegularExpressions;
using NLipsum.Core.Factories;
using NLipsum.Core.Features;
using NLipsum.Core.Models;

namespace NLipsum.Core.Generators;

/// <summary>
///     Class TextFeatureGeneratorBase.
/// </summary>
internal class TextFeatureGeneratorBase
{
    /// <summary>
    ///     Gets the options.
    /// </summary>
    /// <param name="featureType">Type of the feature.</param>
    /// <param name="lipsumLength">Length of the lipsum.</param>
    /// <param name="formatStringType">Type of the format string.</param>
    /// <returns>ITextFeature.</returns>
    protected ITextFeature GetOptions(FeatureTypes featureType, LipsumLengths lipsumLength,
        FormatStringTypes? formatStringType = null)
    {
        return formatStringType == null
            ? TextFeatureFactory
                .GetInstance(featureType)
                .Create(lipsumLength)
            : TextFeatureFactory
                .GetInstance(featureType)
                .Create(lipsumLength, FormatStrings.Get(formatStringType.Value));
    }

    /// <summary>
    ///     Prepares the words.
    /// </summary>
    /// <param name="lipsum">The lipsum.</param>
    /// <returns>List&lt;System.String&gt;.</returns>
    protected static List<string> PrepareWords(string lipsum)
    {
        var source = Regex
            .Split(lipsum, @"\s")
            .ToList();
        return LipsumUtilities.RemoveEmptyElements(source);
    }
}