namespace NLipsum.Core.Features;

/// <summary>
///     Class TextFeature.
/// </summary>
public class TextFeature : ITextFeature
{
    /// <summary>
    ///     Gets or sets the delimiter.
    /// </summary>
    /// <value>The delimiter.</value>
    public string Delimiter { get; set; } = " ";

    /// <summary>
    ///     Gets or sets the format string.
    /// </summary>
    /// <value>The format string.</value>
    public string FormatString { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the minimum value.
    /// </summary>
    /// <value>The minimum value.</value>
    public int MinimumValue { get; set; }

    /// <summary>
    ///     Gets or sets the maximum value.
    /// </summary>
    /// <value>The maximum value.</value>
    public int MaximumValue { get; set; }

    #region DOMAIN METHODS

    /// <summary>
    ///     Formats the specified text.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>System.String.</returns>
    public virtual string Format(string text)
    {
        return string.Format(FormatString, text);
    }

    #endregion
}