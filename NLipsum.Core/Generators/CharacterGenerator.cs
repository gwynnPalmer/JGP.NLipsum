using NLipsum.Core.Models;

namespace NLipsum.Core.Generators;

internal class CharacterGenerator : IFeatureGenerator
{
    public List<string> Generate(LipsumMap map)
    {
        var lipsum = Lipsums.GetLipsum(map.LipsumText);
        if (map.Count > lipsum.Length)
        {
            map.Count = lipsum.Length - 1;
        }

        return new List<string>()
        {
            lipsum.Substring(0, map.Count)
        };
    }
}