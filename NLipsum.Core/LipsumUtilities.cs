using System.Text;
using System.Xml;

namespace NLipsum.Core;

/// <summary>
///     Class LipsumUtilities.
/// </summary>
public static class LipsumUtilities
{
    /// <summary>
    ///     Gets the text from raw XML.
    /// </summary>
    /// <param name="rawXml">The raw XML.</param>
    /// <returns>StringBuilder.</returns>
    public static StringBuilder GetTextFromRawXml(string rawXml)
    {
        var text = new StringBuilder();
        var data = LoadXmlDocument(rawXml);
        var node = data.DocumentElement?.SelectSingleNode("text");

        if (node != null) text.Append(node.InnerText);
        return text;
    }

    /// <summary>
    ///     Randoms the element.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <returns>System.String.</returns>
    public static string RandomElement(List<string> source)
    {
        return source[RandomInt(0, source.Count)];
    }

    /// <summary>
    ///     Randoms the elements.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="count">The count.</param>
    /// <returns>List&lt;System.String&gt;.</returns>
    public static List<string> RandomElements(List<string> source, int count)
    {
        var result = new List<string>();
        for (var i = 0; i < count; i++)
        {
            result.Add(RandomElement(source));
        }

        return result;
    }

    /// <summary>
    ///     Randoms the int.
    /// </summary>
    /// <param name="minimum">The minimum.</param>
    /// <param name="maximum">The maximum.</param>
    /// <returns>System.Int32.</returns>
    public static int RandomInt(int minimum, int maximum)
    {
        var random = new Random();
        return random.Next(minimum, maximum);
    }

    /// <summary>
    ///     Removes the empty elements.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <returns>List&lt;System.String&gt;.</returns>
    public static List<string> RemoveEmptyElements(List<string> source)
    {
        var results = new List<string>();
        var length = source.Count;

        for (var i = 0; i < length; i++)
        {
            if (!string.IsNullOrWhiteSpace(source[i]))
            {
                results.Add(source[i]);
            }
        }

        return results;
    }

    /// <summary>
    ///     Loads the XML document.
    /// </summary>
    /// <param name="rawXml">The raw XML.</param>
    /// <returns>XmlDocument.</returns>
    private static XmlDocument LoadXmlDocument(string rawXml)
    {
        var document = new XmlDocument();
        document.LoadXml(rawXml);
        return document;
    }
}