namespace NLipsum.Core.Features;

/// <summary>
///     Class Word.
///     Implements the <see cref="TextFeature" />
/// </summary>
/// <seealso cref="TextFeature" />
public class Word : TextFeature
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Word" /> class.
    /// </summary>
    public Word() : this(Medium.MinimumValue, Medium.MaximumValue)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Word" /> class.
    /// </summary>
    /// <param name="minimum">The minimum.</param>
    /// <param name="maximum">The maximum.</param>
    /// <param name="formatString">The format string.</param>
    public Word(int minimum, int maximum, string? formatString = null)
    {
        MinimumValue = minimum;
        MaximumValue = maximum;
        FormatString = formatString ?? FormatStrings.Get(FormatStringTypes.Default);
    }

    /// <summary>
    ///     Gets the short.
    /// </summary>
    /// <value>The short.</value>
    public static Word Short => new(1, 3);

    /// <summary>
    ///     Gets the medium.
    /// </summary>
    /// <value>The medium.</value>
    public static Word Medium => new(4, 8);

    /// <summary>
    ///     Gets the long.
    /// </summary>
    /// <value>The long.</value>
    public static Word Long => new(10, 25);
}