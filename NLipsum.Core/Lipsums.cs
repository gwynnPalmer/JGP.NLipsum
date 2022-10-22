using NLipsum.Core.Models;

namespace NLipsum.Core;

/// <summary>
///     Class Lipsums.
/// </summary>
public static class Lipsums
{
    /// <summary>
    ///     Gets the lipsum.
    /// </summary>
    /// <param name="lipsumText">The lipsum text.</param>
    /// <returns>System.String.</returns>
    public static string GetLipsum(LipsumTexts lipsumText)
    {
        var lipsum = lipsumText switch
        {
            LipsumTexts.ChildHarold => ChildHarold,
            LipsumTexts.Decameron => Decameron,
            LipsumTexts.Faust => Faust,
            LipsumTexts.InDerFremde => InDerFremde,
            LipsumTexts.LeBateauIvre => LeBateauIvre,
            LipsumTexts.LeMasque => LeMasque,
            LipsumTexts.LoremIpsum => LoremIpsum,
            LipsumTexts.NagyonFaj => NagyonFaj,
            LipsumTexts.Omagyar => Omagyar,
            LipsumTexts.RobinsonoKruso => RobinsonoKruso,
            LipsumTexts.TheRaven => TheRaven,
            LipsumTexts.TierrayLuna => TierrayLuna,
            _ => throw new ArgumentOutOfRangeException()
        };
        return lipsum;
    }

    /// <summary>
    ///     Gets the child harold.
    /// </summary>
    /// <value>The child harold.</value>
    private static string ChildHarold => LipsumUtilities.GetTextFromRawXml(Resources.childharold).ToString();

    /// <summary>
    ///     Gets the decameron.
    /// </summary>
    /// <value>The decameron.</value>
    private static string Decameron => LipsumUtilities.GetTextFromRawXml(Resources.decameron).ToString();

    /// <summary>
    ///     Gets the faust.
    /// </summary>
    /// <value>The faust.</value>
    private static string Faust => LipsumUtilities.GetTextFromRawXml(Resources.faust).ToString();

    /// <summary>
    ///     Gets the in der fremde.
    /// </summary>
    /// <value>The in der fremde.</value>
    private static string InDerFremde => LipsumUtilities.GetTextFromRawXml(Resources.inderfremde).ToString();

    /// <summary>
    ///     Gets the le bateau ivre.
    /// </summary>
    /// <value>The le bateau ivre.</value>
    private static string LeBateauIvre => LipsumUtilities.GetTextFromRawXml(Resources.lebateauivre).ToString();

    /// <summary>
    ///     Gets the le masque.
    /// </summary>
    /// <value>The le masque.</value>
    private static string LeMasque => LipsumUtilities.GetTextFromRawXml(Resources.lemasque).ToString();

    /// <summary>
    ///     Gets the lorem ipsum.
    /// </summary>
    /// <value>The lorem ipsum.</value>
    private static string LoremIpsum => LipsumUtilities.GetTextFromRawXml(Resources.loremipsum).ToString();

    /// <summary>
    ///     Gets the nagyon faj.
    /// </summary>
    /// <value>The nagyon faj.</value>
    private static string NagyonFaj => LipsumUtilities.GetTextFromRawXml(Resources.nagyonfaj).ToString();

    /// <summary>
    ///     Gets the omagyar.
    /// </summary>
    /// <value>The omagyar.</value>
    private static string Omagyar => LipsumUtilities.GetTextFromRawXml(Resources.omagyar).ToString();

    /// <summary>
    ///     Gets the robinsono kruso.
    /// </summary>
    /// <value>The robinsono kruso.</value>
    private static string RobinsonoKruso => LipsumUtilities.GetTextFromRawXml(Resources.robinsonokruso).ToString();

    /// <summary>
    ///     Gets the raven.
    /// </summary>
    /// <value>The raven.</value>
    private static string TheRaven => LipsumUtilities.GetTextFromRawXml(Resources.theraven).ToString();

    /// <summary>
    ///     Gets the tierray luna.
    /// </summary>
    /// <value>The tierray luna.</value>
    private static string TierrayLuna => LipsumUtilities.GetTextFromRawXml(Resources.tierrayluna).ToString();
}