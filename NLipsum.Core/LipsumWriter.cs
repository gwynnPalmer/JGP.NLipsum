using System.Text;
using NLipsum.Core.Features;

namespace NLipsum.Core;

/// <summary>
///     Interface ILipsumWriter
/// </summary>
public interface ILipsumWriter
{
    /// <summary>
    ///     Writes the specified map.
    /// </summary>
    /// <param name="map">The map.</param>
    /// <returns>System.String.</returns>
    string Write(LipsumMap map);
}

/// <summary>
///     Class LipsumWriter.
/// </summary>
public class LipsumWriter : ILipsumWriter
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="LipsumWriter" /> class.
    /// </summary>
    public LipsumWriter()
    {
    }

    /// <summary>
    ///     Writes the specified map.
    /// </summary>
    /// <param name="map">The map.</param>
    /// <returns>System.String.</returns>
    public string Write(LipsumMap map)
    {
        var lipsum = GetLipsum(map.LipsumText);
        var generator = new LipsumGenerator(lipsum, false);
        return map.FeatureType switch
        {
            FeatureType.Characters or FeatureType.Words => generator.GenerateLipsum(map.Count, map.FeatureType,
                FormatStrings.Paragraph.LineBreaks),
            FeatureType.Sentences => GenerateSentences(map, generator),
            FeatureType.Paragraphs => GenerateParagraphs(map, generator),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    /// <summary>
    ///     Concatenates the text.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>System.String.</returns>
    private static string ConcatenateText(List<string> text)
    {
        var builder = new StringBuilder();
        foreach (var line in text)
        {
            builder.Append(line);
        }

        return builder.ToString();
    }

    /// <summary>
    ///     Generates the paragraphs.
    /// </summary>
    /// <param name="map">The map.</param>
    /// <param name="generator">The generator.</param>
    /// <returns>System.String.</returns>
    private static string GenerateParagraphs(LipsumMap map, LipsumGenerator generator)
    {
        var paragraph = GetParagraph(map.LipsumLength);
        paragraph.SetFormatString(FormatStrings.Paragraph.LineBreaks);
        var text = generator.GenerateParagraphs(map.Count, paragraph);
        return ConcatenateText(text);
    }

    /// <summary>
    ///     Generates the sentences.
    /// </summary>
    /// <param name="map">The map.</param>
    /// <param name="generator">The generator.</param>
    /// <returns>System.String.</returns>
    private static string GenerateSentences(LipsumMap map, LipsumGenerator generator)
    {
        var sentence = GetSentence(map.LipsumLength);
        sentence.SetFormatString(FormatStrings.Sentence.Phrase);
        var text = generator.GenerateSentences(map.Count, sentence);
        return ConcatenateText(text);
    }

    /// <summary>
    ///     Gets the lipsum.
    /// </summary>
    /// <param name="lipsumText">The lipsum text.</param>
    /// <returns>System.String.</returns>
    private static string GetLipsum(LipsumText lipsumText)
    {
        var lipsum = lipsumText switch
        {
            LipsumText.ChildHarold => Lipsums.ChildHarold,
            LipsumText.Decameron => Lipsums.Decameron,
            LipsumText.Faust => Lipsums.Faust,
            LipsumText.InDerFremde => Lipsums.InDerFremde,
            LipsumText.LeBateauIvre => Lipsums.LeBateauIvre,
            LipsumText.LeMasque => Lipsums.LeMasque,
            LipsumText.LoremIpsum => Lipsums.LoremIpsum,
            LipsumText.NagyonFaj => Lipsums.NagyonFaj,
            LipsumText.Omagyar => Lipsums.Omagyar,
            LipsumText.RobinsonoKruso => Lipsums.RobinsonoKruso,
            LipsumText.TheRaven => Lipsums.TheRaven,
            LipsumText.TierrayLuna => Lipsums.TierrayLuna,
            _ => throw new ArgumentOutOfRangeException()
        };
        return lipsum;
    }

    /// <summary>
    ///     Gets the paragraph.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <returns>Paragraph.</returns>
    private static Paragraph GetParagraph(LipsumLength length)
    {
        return length switch
        {
            LipsumLength.Short => Paragraph.Short,
            LipsumLength.Medium => Paragraph.Medium,
            LipsumLength.Long => Paragraph.Long,
            _ => throw new ArgumentOutOfRangeException(nameof(length), length, null)
        };
    }

    /// <summary>
    ///     Gets the sentence.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <returns>Sentence.</returns>
    private static Sentence GetSentence(LipsumLength length)
    {
        return length switch
        {
            LipsumLength.Short => Sentence.Short,
            LipsumLength.Medium => Sentence.Medium,
            LipsumLength.Long => Sentence.Long,
            _ => throw new ArgumentOutOfRangeException(nameof(length), length, null)
        };
    }
}