using System.Text;
using System.Text.RegularExpressions;
using NLipsum.Core.Features;
using NLipsum.Core.Models;

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
        LipsumText = new StringBuilder(Lipsums.GetLipsum(LipsumTexts.LoremIpsum));
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

    #region GENERAL/TOP LEVEL GENERATORS

    /// <summary>
    ///     Generates the lipsum.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <returns>System.String.</returns>
    public string GenerateLipsum(int count)
    {
        return GenerateLipsum(count, FeatureTypes.Paragraph, FormatStrings.Get(FormatStringTypes.ParagraphLineBreaks));
    }

    /// <summary>
    ///     Generates the lipsum.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <param name="feature">The feature.</param>
    /// <param name="formatString">The format string.</param>
    /// <returns>System.String.</returns>
    public string GenerateLipsum(int count, FeatureTypes feature, string formatString)
    {
        var results = new StringBuilder();

        var data = feature switch
        {
            FeatureTypes.Paragraph => GenerateParagraphs(count, formatString),
            FeatureTypes.Sentence => GenerateSentences(count, formatString),
            FeatureTypes.Word => GenerateWords(count),
            FeatureTypes.Character => GenerateCharacters(count),
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
        return GenerateLipsum(count, FeatureTypes.Paragraph, FormatStrings.Get(FormatStringTypes.ParagraphHtml));
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
        return Generate(count, Lipsums.GetLipsum(LipsumTexts.LoremIpsum));
    }

    /// <summary>
    ///     Generates the specified count.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <param name="rawText">The raw text.</param>
    /// <returns>System.String.</returns>
    public static string Generate(int count, string rawText)
    {
        return Generate(count, FormatStrings.Get(FormatStringTypes.ParagraphLineBreaks), rawText);
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
        return Generate(count, FeatureTypes.Paragraph, formatString, rawText);
    }

    /// <summary>
    ///     Generates the specified count.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <param name="feature">The feature.</param>
    /// <param name="formatString">The format string.</param>
    /// <param name="rawText">The raw text.</param>
    /// <returns>System.String.</returns>
    public static string Generate(int count, FeatureTypes feature, string formatString, string rawText)
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
        return Generate(count, FormatStrings.Get(FormatStringTypes.ParagraphHtml), Lipsums.GetLipsum(LipsumTexts.LoremIpsum));
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
        options.FormatString = formatString;
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
                GenerateSentences(LipsumUtilities.RandomInt(options.MinimumValue, options.MaximumValue));

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
        return GenerateSentences(count, FormatStrings.Get(FormatStringTypes.SentencePhrase));
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
        options.FormatString = formatString;
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
            var words = GenerateWords(LipsumUtilities.RandomInt(options.MinimumValue, options.MaximumValue));
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
}