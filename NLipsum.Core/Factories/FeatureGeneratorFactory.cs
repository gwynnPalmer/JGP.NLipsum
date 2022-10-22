using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLipsum.Core.Features;
using NLipsum.Core.Generators;

namespace NLipsum.Core.Factories
{
    internal class FeatureGeneratorFactory
    {
        public static IFeatureGenerator GetInstance(FeatureTypes featureTypes)
        {
            return featureTypes switch
            {
                FeatureTypes.Character => new CharacterGenerator(),
                FeatureTypes.Paragraph => new ParagraphGenerator(),
                FeatureTypes.Sentence => new SentenceGenerator(),
                FeatureTypes.Word => new WordGenerator(),
                _ => throw new ArgumentOutOfRangeException(nameof(featureTypes), featureTypes, null)
            };
        }
    }
}
