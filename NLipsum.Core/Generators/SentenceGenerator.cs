using NLipsum.Core.Features;
using NLipsum.Core.Models;

namespace NLipsum.Core.Generators;

internal class SentenceGenerator : FeatureOptionsBuilder, IFeatureGenerator
{
    private readonly WordGenerator _wordGenerator = new();

    public List<string> Generate(LipsumMap map)
    {
        var options = GetOptions(FeatureTypes.Sentence, map.LipsumLength);
        var sentences = new List<string>();
        for (var i = 0; i < map.Count; i++)
        {
            var selection = _wordGenerator.Generate(map);
            var wordCount = GetRandomSentenceLength(options);
            var words = LipsumUtilities.RandomElements(selection, wordCount);
            var joined = string.Join(options.Delimiter, words);
            sentences.Add(string.IsNullOrEmpty(options.FormatString)
                ? joined
                : options.Format(joined));
        }
        return sentences;
    }

    private int GetRandomSentenceLength(ITextFeature options)
    {
        return LipsumUtilities.RandomInt(options.MinimumValue, options.MaximumValue);
    }
}