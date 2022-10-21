namespace NLipsum.Core.Features;

/// <summary>
///     Class Paragraph.
///     Implements the <see cref="TextFeature" />
/// </summary>
/// <seealso cref="TextFeature" />
public class Paragraph : TextFeature
{
    /// <summary>
    ///     The sentence options
    /// </summary>
    private Sentence _sentenceOptions = Sentence.Medium;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Paragraph" /> class.
    /// </summary>
    public Paragraph() : this(Medium.MinimumSentences, Medium.MaximumSentences)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Paragraph" /> class.
    /// </summary>
    /// <param name="minimum">The minimum.</param>
    /// <param name="maximum">The maximum.</param>
    /// <param name="formatString">The format string.</param>
    public Paragraph(int minimum, int maximum, string? formatString = null)
    {
        MinimumSentences = minimum;
        MaximumSentences = maximum;
        FormatString = formatString ?? FormatStrings.Default;
    }

    /// <summary>
    ///     Gets the short.
    /// </summary>
    /// <value>The short.</value>
    public static Paragraph Short => new(2, 8);

    /// <summary>
    ///     Gets the medium.
    /// </summary>
    /// <value>The medium.</value>
    public static Paragraph Medium => new(3, 20);

    /// <summary>
    ///     Gets the long.
    /// </summary>
    /// <value>The long.</value>
    public static Paragraph Long => new(6, 40);

    /// <summary>
    ///     Gets or sets the maximum sentences.
    /// </summary>
    /// <value>The maximum sentences.</value>
    public int MaximumSentences
    {
        get => MaximumValue;

        set => MaximumValue = value;
    }

    /// <summary>
    ///     Gets or sets the minimum sentences.
    /// </summary>
    /// <value>The minimum sentences.</value>
    public int MinimumSentences
    {
        get => MinimumValue;

        set => MinimumValue = value;
    }
}