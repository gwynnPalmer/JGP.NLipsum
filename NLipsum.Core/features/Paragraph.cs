namespace NLipsum.Core.Features;

/// <summary>
///     Class Paragraph.
///     Implements the <see cref="TextFeature" />
/// </summary>
/// <seealso cref="TextFeature" />
public class Paragraph : TextFeature
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Paragraph" /> class.
    /// </summary>
    public Paragraph() : this(Medium.MinimumValue, Medium.MaximumValue)
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
        MinimumValue = minimum;
        MaximumValue = maximum;
        FormatString = formatString ?? FormatStrings.Get(FormatStringTypes.Default);
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
}