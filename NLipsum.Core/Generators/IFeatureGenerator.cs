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
    /// <returns>List&lt;System.String&gt;.</returns>
    List<string> Generate(LipsumMap map);
}