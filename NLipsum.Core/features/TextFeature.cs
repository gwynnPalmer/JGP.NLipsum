namespace NLipsum.Core.Features;

/// <summary>
///     Class TextFeature.
/// </summary>
public class TextFeature
{
    /// <summary>
    ///     Gets or sets the delimiter.
    /// </summary>
    /// <value>The delimiter.</value>
    public string Delimiter { get; protected set; } = " ";

    /// <summary>
    ///     Gets or sets the format string.
    /// </summary>
    /// <value>The format string.</value>
    public string FormatString { get; protected set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the minimum value.
    /// </summary>
    /// <value>The minimum value.</value>
    public int MinimumValue { get; protected set; }

    /// <summary>
    ///     Gets or sets the maximum value.
    /// </summary>
    /// <value>The maximum value.</value>
    public int MaximumValue { get; protected set; }

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

    /// <summary>
    ///     Sets the format string.
    /// </summary>
    /// <param name="formatString">The format string.</param>
    internal void SetFormatString(string formatString)
    {
        FormatString = formatString;
    }

    /// <summary>
    ///     Sets the delimiter.
    /// </summary>
    /// <param name="delimiter">The delimiter.</param>
    internal void SetDelimiter(string delimiter)
    {
        Delimiter = delimiter;
    }

    #endregion
}