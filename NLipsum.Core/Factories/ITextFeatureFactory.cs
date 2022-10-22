using NLipsum.Core.Features;
using NLipsum.Core.Models;

namespace NLipsum.Core.Factories;

/// <summary>
///     Interface ITextFeatureFactory
/// </summary>
public interface ITextFeatureFactory
{
    /// <summary>
    ///     Creates the specified length.
    /// </summary>
    /// <param name="lengths">The length.</param>
    /// <param name="formatString">The format string.</param>
    /// <returns>ITextFeature.</returns>
    ITextFeature Create(LipsumLengths lengths, string? formatString = null);
}