using System.Text;
using NLipsum.Core.Features;
using NLipsum.Core.Models;

namespace NLipsum.Core.Generators;

/// <summary>
///     Class ParagraphGenerator.
///     Implements the <see cref="TextFeatureGeneratorBase" />
///     Implements the <see cref="NLipsum.Core.Generators.IFeatureGenerator" />
/// </summary>
/// <seealso cref="TextFeatureGeneratorBase" />
/// <seealso cref="NLipsum.Core.Generators.IFeatureGenerator" />
internal class ParagraphGenerator : TextFeatureGeneratorBase, IFeatureGenerator
{
    /// <summary>
    ///     The sentence generator
    /// </summary>
    private readonly SentenceGenerator _sentenceGenerator = new();

    /// <summary>
    ///     Generates the specified map.
    /// </summary>
    /// <param name="map">The map.</param>
    /// <returns>System.String.</returns>
    public string Generate(LipsumMap map)
    {
        var options = GetOptions(FeatureTypes.Paragraph, map.LipsumLength, map.FormatString);
        var paragraphs = new List<string>();
        for (var i = 0; i < map.Count; i++)
        {
            var sentenceCount = LipsumUtilities.RandomInt(options.MinimumValue, options.MaximumValue);
            var sentences = _sentenceGenerator.Generate(map.LipsumText, sentenceCount, map.LipsumLength);
            var joined = string.Join(options.Delimiter, sentences);
            paragraphs.Add(string.IsNullOrEmpty(options.FormatString)
                ? joined
                : options.Format(joined));
        }

        var stringBuilder = new StringBuilder();
        foreach (var paragraph in paragraphs)
        {
            stringBuilder.AppendLine(paragraph);
        }

        return stringBuilder.ToString();
    }
}