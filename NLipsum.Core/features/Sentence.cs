namespace NLipsum.Core.Features;

/// <summary>
///     Class Sentence.
///     Implements the <see cref="TextFeature" />
/// </summary>
/// <seealso cref="TextFeature" />
public class Sentence : TextFeature
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Sentence" /> class.
    /// </summary>
    public Sentence() : this(Medium.MinimumValue, Medium.MaximumValue)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Sentence" /> class.
    /// </summary>
    /// <param name="minimum">The minimum.</param>
    /// <param name="maximum">The maximum.</param>
    /// <param name="formatString">The format string.</param>
    public Sentence(int minimum, int maximum, string? formatString = null)
    {
        MinimumWords = minimum;
        MaximumWords = maximum;
        FormatString = formatString ?? FormatStrings.Sentence.Phrase;
    }

    /// <summary>
    ///     Gets the short.
    /// </summary>
    /// <value>The short.</value>
    public static Sentence Short => new(2, 8);

    /// <summary>
    ///     Gets the medium.
    /// </summary>
    /// <value>The medium.</value>
    public static Sentence Medium => new(3, 20);

    /// <summary>
    ///     Gets the long.
    /// </summary>
    /// <value>The long.</value>
    public static Sentence Long => new(6, 40);

    /// <summary>
    ///     Gets or sets the maximum words.
    /// </summary>
    /// <value>The maximum words.</value>
    public int MaximumWords
    {
        get => MaximumValue;

        set => MaximumValue = value;
    }

    /// <summary>
    ///     Gets or sets the minimum words.
    /// </summary>
    /// <value>The minimum words.</value>
    public int MinimumWords
    {
        get => MinimumValue;

        set => MinimumValue = value;
    }

    #region OVERRIDES & ESSENTIALS

    /// <summary>
    ///     Formats the specified text.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>System.String.</returns>
    public override string Format(string text)
    {
        var result = base.Format(text);
        if (result.Length > 1)
        {
            result = result.Substring(0, 1).ToUpper() + result.Substring(1);
        }

        return result;
    }

    #endregion
}