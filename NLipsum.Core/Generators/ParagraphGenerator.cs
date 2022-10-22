using NLipsum.Core.Features;
using NLipsum.Core.Models;

namespace NLipsum.Core.Generators;

internal class ParagraphGenerator : FeatureOptionsBuilder, IFeatureGenerator
{
    private readonly SentenceGenerator _sentenceGenerator = new();

    public List<string> Generate(LipsumMap map)
    {
        var options = GetOptions(FeatureTypes.Paragraph, map.LipsumLength);
        var paragraphs = new List<string>();
        for (int i = 0; i < map.Count; i++)
        {
            var sentences = _sentenceGenerator.Generate(map);
            var joined = string.Join(options.Delimiter, sentences);
            paragraphs.Add(string.IsNullOrEmpty(options.FormatString)
                ? joined
                : options.Format(joined));
        }
        return paragraphs;
    }
}