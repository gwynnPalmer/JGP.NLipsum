using System.Text;
using NLipsum.Core.Factories;
using NLipsum.Core.Features;
using NLipsum.Core.Models;

namespace NLipsum.Core.Writers;

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
        var lipsum = Lipsums.GetLipsum(map.LipsumTexts);
        var generator = new LipsumGenerator(lipsum, false);
        return map.FeatureTypes switch
        {
            FeatureTypes.Character or FeatureTypes.Word => generator.GenerateLipsum(map.Count, map.FeatureTypes, FormatStrings.Get(map.FormatString)),
            FeatureTypes.Sentence => GenerateSentences(map, generator),
            FeatureTypes.Paragraph => GenerateParagraphs(map, generator),
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
        var factory = TextFeatureFactory.GetInstance(map.FeatureTypes);
        var paragraph = (Paragraph)factory.Create(map.LipsumLengths, FormatStrings.Get(map.FormatString));
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
        var factory = TextFeatureFactory.GetInstance(map.FeatureTypes);
        var sentence = (Sentence)factory.Create(map.LipsumLengths, FormatStrings.Get(map.FormatString));
        var text = generator.GenerateSentences(map.Count, sentence);
        return ConcatenateText(text);
    }
}