using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using NLipsum.Core.Features;

namespace NLipsum.Core.Models;

/// <summary>
///     Class LipsumMap.
/// </summary>
public class LipsumMap
{
    /// <summary>
    ///     Gets or sets the count.
    /// </summary>
    /// <value>The count.</value>
    [Required]
    [JsonPropertyName("count")]
    public int Count { get; set; } = 1;

    /// <summary>
    ///     Gets or sets the format string.
    /// </summary>
    /// <value>The format string.</value>
    [Required]
    [JsonPropertyName("formatString")]
    public FormatStringTypes FormatString { get; set; } = FormatStringTypes.Default;

    /// <summary>
    ///     Gets or sets the length of the lipsum.
    /// </summary>
    /// <value>The length of the lipsum.</value>
    [Required]
    [JsonPropertyName("lipsumLength")]
    public LipsumLengths LipsumLengths { get; set; } = LipsumLengths.Medium;

    /// <summary>
    ///     Gets or sets the lipsum text.
    /// </summary>
    /// <value>The lipsum text.</value>
    [Required]
    [JsonPropertyName("lipsumTexts")]
    public LipsumTexts LipsumTexts { get; set; } = LipsumTexts.LoremIpsum;

    /// <summary>
    ///     Gets or sets the type of the text.
    /// </summary>
    /// <value>The type of the text.</value>
    [Required]
    [JsonPropertyName("featureTypes")]
    public FeatureTypes FeatureTypes { get; set; } = FeatureTypes.Paragraph;
}