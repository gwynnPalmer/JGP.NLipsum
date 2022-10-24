using NLipsum.Core.Models;

namespace NLipsum.Core.Generators;

/// <summary>
///     Interface IFeatureGenerator
/// </summary>
internal interface IFeatureGenerator
{
    /// <summary>
    ///     Generates the specified map.
    /// </summary>
    /// <param name="map">The map.</param>
    /// <returns>System.String.</returns>
    string Generate(LipsumMap map);
}