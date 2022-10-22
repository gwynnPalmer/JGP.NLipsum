using NLipsum.Core.Factories;
using NLipsum.Core.Features;
using NLipsum.Core.Models;

namespace NLipsum.Core.Generators;

/// <summary>
///     Class FeatureOptionsBuilder.
/// </summary>
internal class FeatureOptionsBuilder
{
    /// <summary>
    ///     Gets the options.
    /// </summary>
    /// <param name="featureType">Type of the feature.</param>
    /// <param name="lipsumLength">Length of the lipsum.</param>
    /// <returns>ITextFeature.</returns>
    protected ITextFeature GetOptions(FeatureTypes featureType, LipsumLengths lipsumLength)
    {
        return TextFeatureFactory
            .GetInstance(featureType)
            .Create(lipsumLength);
    }
}