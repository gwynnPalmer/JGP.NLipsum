using System.Text.RegularExpressions;
using NLipsum.Core.Models;

namespace NLipsum.Core.Generators;

/// <summary>
///     Class CharacterGenerator.
///     Implements the <see cref="NLipsum.Core.Generators.IFeatureGenerator" />
/// </summary>
/// <seealso cref="NLipsum.Core.Generators.IFeatureGenerator" />
internal class CharacterGenerator : IFeatureGenerator
{
    /// <summary>
    ///     Generates the specified map.
    /// </summary>
    /// <param name="map">The map.</param>
    /// <returns>System.String.</returns>
    public string Generate(LipsumMap map)
    {
        var lipsum = Lipsums.GetLipsum(map.LipsumText);
        var words = PrepareWords(lipsum);
        var word = words.FirstOrDefault(word => word.Length == map.Count);
        if (word != null) return word;

        var chars = lipsum
            .Where(character => char.IsLetter(character))
            .Distinct()
            .Take(map.Count)
            .ToArray();

        return new string(chars);
    }

    /// <summary>
    ///     Prepares the words.
    /// </summary>
    /// <param name="lipsum">The lipsum.</param>
    /// <returns>List&lt;System.String&gt;.</returns>
    private static List<string> PrepareWords(string lipsum)
    {
        var source = Regex
            .Split(lipsum, @"\s")
            .ToList();
        return LipsumUtilities.RemoveEmptyElements(source);
    }
}