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
    public Word() : this(Medium.MinimumCharacters, Medium.MaximumCharacters)
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
        MinimumCharacters = minimum;
        MaximumCharacters = maximum;
        FormatString = formatString ?? FormatStrings.Default;
    }

    /// <summary>
    ///     Gets or sets the minimum characters.
    /// </summary>
    /// <value>The minimum characters.</value>
    public int MinimumCharacters
    {
        get => MinimumValue;

        set => MinimumValue = value;
    }

    /// <summary>
    ///     Gets or sets the maximum characters.
    /// </summary>
    /// <value>The maximum characters.</value>
    public int MaximumCharacters
    {
        get => MaximumValue;

        set => MaximumValue = value;
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