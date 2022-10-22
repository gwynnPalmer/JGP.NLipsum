using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using NLipsum.Core.Features;

namespace NLipsum.Core;

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
    ///     Gets or sets the length of the lipsum.
    /// </summary>
    /// <value>The length of the lipsum.</value>
    [Required]
    [JsonPropertyName("lipsumLength")]
    public LipsumLength LipsumLength { get; set; } = LipsumLength.Medium;

    /// <summary>
    ///     Gets or sets the lipsum text.
    /// </summary>
    /// <value>The lipsum text.</value>
    [Required]
    [JsonPropertyName("lipsumText")]
    public LipsumText LipsumText { get; set; } = LipsumText.LoremIpsum;

    /// <summary>
    ///     Gets or sets the type of the text.
    /// </summary>
    /// <value>The type of the text.</value>
    [Required]
    [JsonPropertyName("featureType")]
    public FeatureType FeatureType { get; set; } = FeatureType.Paragraphs;
}

/// <summary>
///     Enum LipsumLength
/// </summary>
public enum LipsumLength
{
    /// <summary>
    ///     The short
    /// </summary>
    Short = 0,

    /// <summary>
    ///     The medium
    /// </summary>
    Medium = 1,

    /// <summary>
    ///     The long
    /// </summary>
    Long = 2
}

/// <summary>
///     Enum LipsumText
/// </summary>
public enum LipsumText
{
    /// <summary>
    ///     The child harold
    /// </summary>
    ChildHarold = 0,

    /// <summary>
    ///     The decameron
    /// </summary>
    Decameron = 1,

    /// <summary>
    ///     The faust
    /// </summary>
    Faust = 2,

    /// <summary>
    ///     The in der fremde
    /// </summary>
    InDerFremde = 3,

    /// <summary>
    ///     The le bateau ivre
    /// </summary>
    LeBateauIvre = 4,

    /// <summary>
    ///     The le masque
    /// </summary>
    LeMasque = 5,

    /// <summary>
    ///     The lorem ipsum
    /// </summary>
    LoremIpsum = 6,

    /// <summary>
    ///     The nagyon faj
    /// </summary>
    NagyonFaj = 7,

    /// <summary>
    ///     The omagyar
    /// </summary>
    Omagyar = 8,

    /// <summary>
    ///     The robinsono kruso
    /// </summary>
    RobinsonoKruso = 9,

    /// <summary>
    ///     The raven
    /// </summary>
    TheRaven = 10,

    /// <summary>
    ///     The tierray luna
    /// </summary>
    TierrayLuna = 11
}