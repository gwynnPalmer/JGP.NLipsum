using System.Text;
using System.Text.RegularExpressions;
using NLipsum.Core.Features;

namespace NLipsum.Core;

/// <summary>
///     Class LipsumGenerator.
/// </summary>
public class LipsumGenerator
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="LipsumGenerator" /> class.
    /// </summary>
    public LipsumGenerator()
    {
        LipsumText = new StringBuilder(Lipsums.LoremIpsum);
        PreparedWords = PrepareWords();
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="LipsumGenerator" /> class.
    /// </summary>
    /// <param name="rawData">The raw data.</param>
    /// <param name="isXml">if set to <c>true</c> [is XML].</param>
    public LipsumGenerator(string rawData, bool isXml)
    {
        LipsumText = isXml
            ? LipsumUtilities.GetTextFromRawXml(rawData)
            : new StringBuilder(rawData);

        PreparedWords = PrepareWords();
    }

    /// <summary>
    ///     Gets the lipsum text.
    /// </summary>
    /// <value>The lipsum text.</value>
    public StringBuilder LipsumText { get; }

    /// <summary>
    ///     Gets the prepared words.
    /// </summary>
    /// <value>The prepared words.</value>
    public List<string> PreparedWords { get; }

    #region CHARACTERS

    /// <summary>
    ///     Generates the characters.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <returns>List&lt;System.String&gt;.</returns>
    public List<string> GenerateCharacters(int count)
    {
        var result = new List<string>();

        if (count >= LipsumText.Length)
        {
            count = LipsumText.Length - 1;
        }

        var chars = LipsumText
            .ToString()
            .Substring(0, count)
            .ToCharArray();

        result.Add(new string(chars));
        return result;
    }

    #endregion

    #region GENERAL/TOP LEVEL GENERATORS

    /// <summary>
    ///     Generates the lipsum.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <returns>System.String.</returns>
    public string GenerateLipsum(int count)
    {
        return GenerateLipsum(count, FeatureType.Paragraphs, FormatStrings.Paragraph.LineBreaks);
    }

    /// <summary>
    ///     Generates the lipsum.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <param name="feature">The feature.</param>
    /// <param name="formatString">The format string.</param>
    /// <returns>System.String.</returns>
    public string GenerateLipsum(int count, FeatureType feature, string formatString)
    {
        var results = new StringBuilder();

        var data = feature switch
        {
            FeatureType.Paragraphs => GenerateParagraphs(count, formatString),
            FeatureType.Sentences => GenerateSentences(count, formatString),
            FeatureType.Words => GenerateWords(count),
            FeatureType.Characters => GenerateCharacters(count),
            _ => throw new NotImplementedException("Sorry, this is not yet implemented.")
        };

        foreach (var st in data)
        {
            results.Append(st);
        }

        return results.ToString();
    }

    /// <summary>
    ///     Generates the lipsum HTML.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <returns>System.String.</returns>
    public string GenerateLipsumHtml(int count)
    {
        return GenerateLipsum(count, FeatureType.Paragraphs, FormatStrings.Paragraph.Html);
    }

    #endregion

    #region STATIC GENERATORS

    /// <summary>
    ///     Generates the specified count.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <returns>System.String.</returns>
    public static string Generate(int count)
    {
        return Generate(count, Lipsums.LoremIpsum);
    }

    /// <summary>
    ///     Generates the specified count.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <param name="rawText">The raw text.</param>
    /// <returns>System.String.</returns>
    public static string Generate(int count, string rawText)
    {
        return Generate(count, FormatStrings.Paragraph.LineBreaks, rawText);
    }

    /// <summary>
    ///     Generates the specified count.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <param name="formatString">The format string.</param>
    /// <param name="rawText">The raw text.</param>
    /// <returns>System.String.</returns>
    public static string Generate(int count, string formatString, string rawText)
    {
        return Generate(count, FeatureType.Paragraphs, formatString, rawText);
    }

    /// <summary>
    ///     Generates the specified count.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <param name="feature">The feature.</param>
    /// <param name="formatString">The format string.</param>
    /// <param name="rawText">The raw text.</param>
    /// <returns>System.String.</returns>
    public static string Generate(int count, FeatureType feature, string formatString, string rawText)
    {
        var generator = new LipsumGenerator(rawText, false);
        return generator.GenerateLipsum(count, feature, formatString);
    }

    /// <summary>
    ///     Generates the HTML.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <returns>System.String.</returns>
    public static string GenerateHtml(int count)
    {
        return Generate(count, FormatStrings.Paragraph.Html, Lipsums.LoremIpsum);
    }

    #endregion

    #region PARAGRAPHS

    /// <summary>
    ///     Generates the paragraphs.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <param name="formatString">The format string.</param>
    /// <returns>List&lt;System.String&gt;.</returns>
    public List<string> GenerateParagraphs(int count, string formatString)
    {
        var options = Paragraph.Medium;
        options.SetFormatString(formatString);
        return GenerateParagraphs(count, options);
    }

    /// <summary>
    ///     Generates the paragraphs.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <param name="options">The options.</param>
    /// <returns>List&lt;System.String&gt;.</returns>
    public List<string> GenerateParagraphs(int count, Paragraph options)
    {
        var paragraphs = new List<string>();
        for (var i = 0; i < count; i++)
        {
            var sentences =
                GenerateSentences(LipsumUtilities.RandomInt(options.MinimumSentences, options.MaximumSentences));

            var joined = string.Join(options.Delimiter, sentences);

            paragraphs.Add(string.IsNullOrEmpty(options.FormatString)
                ? joined
                : options.Format(joined));
        }

        return paragraphs;
    }

    #endregion

    #region SENTENCES

    /// <summary>
    ///     Generates the sentences.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <returns>List&lt;System.String&gt;.</returns>
    public List<string> GenerateSentences(int count)
    {
        return GenerateSentences(count, FormatStrings.Sentence.Phrase);
    }

    /// <summary>
    ///     Generates the sentences.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <param name="formatString">The format string.</param>
    /// <returns>List&lt;System.String&gt;.</returns>
    public List<string> GenerateSentences(int count, string formatString)
    {
        var options = Sentence.Medium;
        options.SetFormatString(formatString);
        return GenerateSentences(count, options);
    }

    /// <summary>
    ///     Generates the sentences.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <param name="options">The options.</param>
    /// <returns>List&lt;System.String&gt;.</returns>
    public List<string> GenerateSentences(int count, Sentence options)
    {
        var sentences = new List<string>();
        for (var i = 0; i < count; i++)
        {
            var words = GenerateWords(LipsumUtilities.RandomInt(options.MinimumWords, options.MaximumWords));
            var joined = string.Join(options.Delimiter, words);
            sentences.Add(string.IsNullOrEmpty(options.FormatString)
                ? joined
                : options.Format(joined));
        }

        return sentences;
    }

    #endregion

    #region WORDS

    /// <summary>
    ///     Generates the words.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <returns>List&lt;System.String&gt;.</returns>
    public List<string> GenerateWords(int count)
    {
        var words = new List<string>();
        for (var i = 0; i < count; i++)
        {
            words.Add(RandomWord());
        }

        return words;
    }

    /// <summary>
    ///     Randoms the word.
    /// </summary>
    /// <returns>System.String.</returns>
    public string RandomWord()
    {
        return LipsumUtilities.RandomElement(PreparedWords);
    }

    /// <summary>
    ///     Prepares the words.
    /// </summary>
    /// <returns>List&lt;System.String&gt;.</returns>
    private List<string> PrepareWords()
    {
        return LipsumUtilities.RemoveEmptyElements(Regex.Split(LipsumText.ToString(), @"\s").ToList());
    }

    #endregion
}