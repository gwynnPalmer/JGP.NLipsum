using NLipsum.Core.Features;

namespace NLipsum.Core.Factories;

/// <summary>
///     Class TextFeatureFactory.
/// </summary>
public static class TextFeatureFactory
{
    /// <summary>
    ///     Gets the instance.
    /// </summary>
    /// <param name="featureTypes">Type of the feature.</param>
    /// <returns>ITextFeatureFactory.</returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public static ITextFeatureFactory GetInstance(FeatureTypes featureTypes)
    {
        return featureTypes switch
        {
            FeatureTypes.Character => throw new NotImplementedException(),
            FeatureTypes.Paragraph => new ParagraphFactory(),
            FeatureTypes.Sentence => new SentenceFactory(),
            FeatureTypes.Word => new WordFactory(),
            _ => throw new ArgumentOutOfRangeException(nameof(featureTypes), featureTypes, null)
        };
    }
}