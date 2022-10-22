using System.Text.RegularExpressions;
using NLipsum.Core.Models;

namespace NLipsum.Core.Generators;

/// <summary>
///     Class WordGenerator.
///     Implements the <see cref="NLipsum.Core.Generators.FeatureOptionsBuilder" />
///     Implements the <see cref="NLipsum.Core.Generators.IFeatureGenerator" />
/// </summary>
/// <seealso cref="NLipsum.Core.Generators.FeatureOptionsBuilder" />
/// <seealso cref="NLipsum.Core.Generators.IFeatureGenerator" />
internal class WordGenerator : FeatureOptionsBuilder, IFeatureGenerator
{
    /// <summary>
    ///     Generates the specified map.
    /// </summary>
    /// <param name="map">The map.</param>
    /// <returns>List&lt;System.String&gt;.</returns>
    public List<string> Generate(LipsumMap map)
    {
        var lipsum = Lipsums.GetLipsum(map.LipsumText);
        var lipsumList = PrepareWords(lipsum);
        return Generate(map.Count, lipsumList);
    }

    /// <summary>
    ///     Generates the specified count.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <param name="preparedWords">The prepared words.</param>
    /// <returns>List&lt;System.String&gt;.</returns>
    private List<string> Generate(int count, List<string> preparedWords)
    {
        var words = new List<string>();
        for (var i = 0; i < count; i++)
        {
            var randomWord = LipsumUtilities.RandomElement(preparedWords);
            words.Add(randomWord);
        }

        return words;
    }

    /// <summary>
    ///     Prepares the words.
    /// </summary>
    /// <param name="lipsum">The lipsum.</param>
    /// <returns>List&lt;System.String&gt;.</returns>
    private List<string> PrepareWords(string lipsum)
    {
        var source = Regex
            .Split(lipsum, @"\s")
            .ToList();
        return LipsumUtilities.RemoveEmptyElements(source);
    }
}