namespace NLipsum.Core;

/// <summary>
///     Class FormatStrings.
/// </summary>
public static class FormatStrings
{
    /// <summary>
    ///     Gets the default.
    /// </summary>
    /// <value>The default.</value>
    private static string Default => "{0}";

    /// <summary>
    ///     Gets the specified type.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>System.String.</returns>
    public static string Get(FormatStringTypes type)
    {
        return type switch
        {
            FormatStringTypes.Default => Default,
            FormatStringTypes.ParagraphHtml => Paragraph.Html,
            FormatStringTypes.ParagraphLineBreaks => Paragraph.LineBreaks,
            FormatStringTypes.SentenceExclamation => Sentence.Exclamation,
            FormatStringTypes.SentencePhrase => Sentence.Phrase,
            FormatStringTypes.SentenceQuestion => Sentence.Question,
            _ => Default
        };
    }

    /// <summary>
    ///     Class Paragraph.
    /// </summary>
    private static class Paragraph
    {
        /// <summary>
        ///     Gets the HTML.
        /// </summary>
        /// <value>The HTML.</value>
        internal static string Html => "<p>{0}</p>";

        /// <summary>
        ///     Gets the line breaks.
        /// </summary>
        /// <value>The line breaks.</value>
        internal static string LineBreaks => "{0}" + Environment.NewLine;
    }

    /// <summary>
    ///     Class Sentence.
    /// </summary>
    private static class Sentence
    {
        /// <summary>
        ///     Gets the exclamation.
        /// </summary>
        /// <value>The exclamation.</value>
        internal static string Exclamation => "{0}!";

        /// <summary>
        ///     Gets the phrase.
        /// </summary>
        /// <value>The phrase.</value>
        internal static string Phrase => "{0}.";

        /// <summary>
        ///     Gets the question.
        /// </summary>
        /// <value>The question.</value>
        internal static string Question => "{0}?";
    }
}

/// <summary>
///     Enum FormatStringTypes
/// </summary>
public enum FormatStringTypes
{
    /// <summary>
    ///     The default
    /// </summary>
    Default = 0,

    /// <summary>
    ///     The paragraph HTML
    /// </summary>
    ParagraphHtml = 1,

    /// <summary>
    ///     The paragraph line breaks
    /// </summary>
    ParagraphLineBreaks = 2,

    /// <summary>
    ///     The sentence exclamation
    /// </summary>
    SentenceExclamation = 3,

    /// <summary>
    ///     The sentence phrase
    /// </summary>
    SentencePhrase = 4,

    /// <summary>
    ///     The sentence question
    /// </summary>
    SentenceQuestion = 5
}