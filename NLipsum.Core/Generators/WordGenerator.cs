using NLipsum.Core.Features;
using NLipsum.Core.Models;

namespace NLipsum.Core.Generators;

/// <summary>
///     Class WordGenerator.
///     Implements the <see cref="TextFeatureGeneratorBase" />
///     Implements the <see cref="NLipsum.Core.Generators.IFeatureGenerator" />
/// </summary>
/// <seealso cref="TextFeatureGeneratorBase" />
/// <seealso cref="NLipsum.Core.Generators.IFeatureGenerator" />
internal class WordGenerator : TextFeatureGeneratorBase, IFeatureGenerator
{
    /// <summary>
    ///     Generates the specified map.
    /// </summary>
    /// <param name="map">The map.</param>
    /// <returns>List&lt;System.String&gt;.</returns>
    public string Generate(LipsumMap map)
    {
        var options = GetOptions(FeatureTypes.Word, map.LipsumLength, map.FormatString);
        var lipsum = Lipsums.GetLipsum(map.LipsumText);
        var lipsumList = PrepareWords(lipsum);

        var words = new List<string>();
        for (var i = 0; i < map.Count; i++)
        {
            var word = GetSuitableWord(lipsumList, options);
            words.Add(word);
        }

        return string.Join(" ", words);
    }

    /// <summary>
    ///     Gets the suitable word.
    /// </summary>
    /// <param name="lipsumList">The lipsum list.</param>
    /// <param name="options">The options.</param>
    /// <returns>System.String.</returns>
    private static string GetSuitableWord(List<string> lipsumList, ITextFeature options)
    {
        var word = LipsumUtilities.RandomElement(lipsumList);
        if (word.Length >= options.MinimumValue && word.Length <= options.MaximumValue)
        {
            return word;
        }

        while (word.Length < options.MinimumValue || word.Length > options.MaximumValue)
        {
            word = LipsumUtilities.RandomElement(lipsumList);
        }

        return word;
    }
}