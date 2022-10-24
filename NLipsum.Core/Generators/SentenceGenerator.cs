using NLipsum.Core.Features;
using NLipsum.Core.Models;

namespace NLipsum.Core.Generators;

/// <summary>
///     Class SentenceGenerator.
///     Implements the <see cref="TextFeatureGeneratorBase" />
///     Implements the <see cref="NLipsum.Core.Generators.IFeatureGenerator" />
/// </summary>
/// <seealso cref="TextFeatureGeneratorBase" />
/// <seealso cref="NLipsum.Core.Generators.IFeatureGenerator" />
internal class SentenceGenerator : TextFeatureGeneratorBase, IFeatureGenerator
{
    /// <summary>
    ///     Generates the specified map.
    /// </summary>
    /// <param name="map">The map.</param>
    /// <returns>System.String.</returns>
    public string Generate(LipsumMap map)
    {
        var lipsumList = GetLipsumWordsList(map.LipsumText);
        var options = GetOptions(FeatureTypes.Sentence, map.LipsumLength, map.FormatString);

        return BuildSentences(map.Count, options, lipsumList);
    }

    /// <summary>
    ///     Generates the specified lipsum text.
    /// </summary>
    /// <param name="lipsumText">The lipsum text.</param>
    /// <param name="count">The count.</param>
    /// <param name="lipsumLength">Length of the lipsum.</param>
    /// <returns>System.String.</returns>
    internal string Generate(LipsumTexts lipsumText, int count, LipsumLengths lipsumLength)
    {
        var lipsumList = GetLipsumWordsList(lipsumText);
        var options = GetOptions(FeatureTypes.Sentence, lipsumLength);

        return BuildSentences(count, options, lipsumList);
    }

    /// <summary>
    ///     Builds the sentence.
    /// </summary>
    /// <param name="options">The options.</param>
    /// <param name="lipsumList">The lipsum list.</param>
    /// <returns>System.String.</returns>
    private static string BuildSentence(ITextFeature options, List<string> lipsumList)
    {
        var wordCount = LipsumUtilities.RandomInt(options.MinimumValue, options.MaximumValue);
        var words = new List<string>();
        for (var j = 0; j < wordCount; j++)
        {
            words.Add(LipsumUtilities.RandomElement(lipsumList));
        }

        var joined = string.Join(options.Delimiter, words);
        return joined;
    }

    /// <summary>
    ///     Builds the sentences.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <param name="options">The options.</param>
    /// <param name="lipsumList">The lipsum list.</param>
    /// <returns>System.String.</returns>
    private static string BuildSentences(int count, ITextFeature options, List<string> lipsumList)
    {
        var sentences = new List<string>();
        for (var i = 0; i < count; i++)
        {
            var sentence = BuildSentence(options, lipsumList);
            sentences.Add(string.IsNullOrEmpty(options.FormatString)
                ? sentence
                : options.Format(sentence));
        }

        return string.Join(options.Delimiter, sentences);
    }

    /// <summary>
    ///     Gets the lipsum words list.
    /// </summary>
    /// <param name="lipsumText">The lipsum text.</param>
    /// <returns>List&lt;System.String&gt;.</returns>
    private static List<string> GetLipsumWordsList(LipsumTexts lipsumText)
    {
        var lipsum = Lipsums.GetLipsum(lipsumText);
        return PrepareWords(lipsum);
    }
}