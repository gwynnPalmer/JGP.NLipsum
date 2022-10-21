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
    public static string Default => "{0}";

    /// <summary>
    ///     Class Paragraph.
    /// </summary>
    public static class Paragraph
    {
        /// <summary>
        ///     Gets the HTML.
        /// </summary>
        /// <value>The HTML.</value>
        public static string Html => "<p>{0}</p>";

        /// <summary>
        ///     Gets the line breaks.
        /// </summary>
        /// <value>The line breaks.</value>
        public static string LineBreaks => "{0}" + Environment.NewLine;
    }

    /// <summary>
    ///     Class Sentence.
    /// </summary>
    public static class Sentence
    {
        /// <summary>
        ///     Gets the exclamation.
        /// </summary>
        /// <value>The exclamation.</value>
        public static string Exclamation => "{0}!";

        /// <summary>
        ///     Gets the phrase.
        /// </summary>
        /// <value>The phrase.</value>
        public static string Phrase => "{0}.";

        /// <summary>
        ///     Gets the question.
        /// </summary>
        /// <value>The question.</value>
        public static string Question => "{0}?";
    }
}