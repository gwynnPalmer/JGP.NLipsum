namespace NLipsum.Core.Features;

/// <summary>
///     Interface ITextFeature
/// </summary>
public interface ITextFeature
{
    /// <summary>
    ///     Gets or sets the delimiter.
    /// </summary>
    /// <value>The delimiter.</value>
    string Delimiter { get; set; }

    /// <summary>
    ///     Gets or sets the format string.
    /// </summary>
    /// <value>The format string.</value>
    string FormatString { get; set; }

    /// <summary>
    ///     Gets or sets the minimum value.
    /// </summary>
    /// <value>The minimum value.</value>
    int MinimumValue { get; set; }

    /// <summary>
    ///     Gets or sets the maximum value.
    /// </summary>
    /// <value>The maximum value.</value>
    int MaximumValue { get; set; }

    /// <summary>
    ///     Formats the specified text.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>System.String.</returns>
    string Format(string text);
}