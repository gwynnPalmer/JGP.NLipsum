using FluentAssertions;
using FluentAssertions.Execution;
using NLipsum.Core;
using NLipsum.Core.Features;
using NUnit.Framework;

namespace NLipsum.Tests;

/// <summary>
///     Defines test class LipsumTests.
/// </summary>
[TestFixture]
public class LipsumTests
{
    /// <summary>
    ///     Defines the test method TestLoadXml.
    /// </summary>
    [Test]
    public void TestLoadXml()
    {
        var template = "<root><text>{0}</text></root>";
        var expectedText = "Lorem ipsum dolor sit amet";
        var formatted = string.Format(template, expectedText);
        var lipsum = new LipsumGenerator(formatted, true);

        lipsum.LipsumText.ToString().Should().Be(expectedText);
    }

    /// <summary>
    ///     Defines the test method TestLoadPlainText.
    /// </summary>
    [Test]
    public void TestLoadPlainText()
    {
        var expectedText = "Lorem ipsum dolor sit amet";
        var lipsum = new LipsumGenerator(expectedText, false);

        lipsum.LipsumText.ToString().Should().Be(expectedText);
    }

    /// <summary>
    ///     Defines the test method DefaultConstructorContainsLoremIpsum.
    /// </summary>
    [Test]
    public void DefaultConstructorContainsLoremIpsum()
    {
        var expected = Lipsums.LoremIpsum;
        var generator = new LipsumGenerator();
        expected.Should().Be(generator.LipsumText.ToString());
    }

    /// <summary>
    ///     Defines the test method TestPrepareWords.
    /// </summary>
    [Test]
    public void TestPrepareWords()
    {
        var rawText = "lorem ipsum dolor sit amet consetetur";
        string[] expectedArray =
        {
            "lorem", "ipsum", "dolor", "sit", "amet", "consetetur"
        };
        var wordsInRawText = 6;

        var lipsum = new LipsumGenerator(rawText, false);
        var wordsPrepared = lipsum.PreparedWords;

        using (new AssertionScope())
        {
            wordsPrepared.Should().HaveCount(wordsInRawText);
            wordsPrepared.Should().BeEquivalentTo(expectedArray);
        }
    }

    /// <summary>
    ///     Defines the test method TestGenerateWords.
    /// </summary>
    [Test]
    public void TestGenerateWords()
    {
        var rawText = "lorem ipsum dolor sit amet consetetur";
        var lipsum = new LipsumGenerator(rawText, false);
        var wordCount = 4;
        var generatedWords = lipsum.GenerateWords(wordCount);

        using (new AssertionScope())
        {
            generatedWords.Should().HaveCount(wordCount);

            for (var i = 0; i < wordCount; i++)
            {
                rawText.Should().Contain(generatedWords[i]);
            }
        }
    }

    /// <summary>
    ///     Defines the test method TestGenerateSentences.
    /// </summary>
    [Test]
    public void TestGenerateSentences()
    {
        var rawText = Lipsums.LoremIpsum;
        var lipsum = new LipsumGenerator(rawText, false);

        var desiredSentenceCount = 5;
        var generatedSentences = lipsum.GenerateSentences(desiredSentenceCount, Sentence.Medium);


        using (new AssertionScope())
        {
            desiredSentenceCount.Should().Be(generatedSentences.Count);
            for (var i = 0; i < desiredSentenceCount; i++)
            {
                generatedSentences[i].Should().NotBeNull().And.NotBeEmpty();
            }
        }
    }

    /// <summary>
    ///     Defines the test method TestSentenceCapitalizationAndPunctuation.
    /// </summary>
    [Test]
    public void TestSentenceCapitalizationAndPunctuation()
    {
        var rawText = "this";
        var lipsum = new LipsumGenerator(rawText, false);
        var generatedSentences = lipsum.GenerateSentences(1, new Sentence(1, 1));
        var desiredSentence = "This.";

        generatedSentences[0].Should().Be(desiredSentence);
    }

    /// <summary>
    ///     Defines the test method TestGenerateParagraphs.
    /// </summary>
    [Test]
    public void TestGenerateParagraphs()
    {
        var rawText = Lipsums.LoremIpsum;
        var lipsum = new LipsumGenerator(rawText, false);

        var desiredParagraphCount = 5;
        var generatedParagraphs = lipsum.GenerateParagraphs(desiredParagraphCount, Paragraph.Medium);

        using (new AssertionScope())
        {
            desiredParagraphCount.Should().Be(generatedParagraphs.Count);
            for (var i = 0; i < desiredParagraphCount; i++)
            {
                generatedParagraphs[i].Should().NotBeNull().And.NotBeEmpty();
            }
        }
    }

    /// <summary>
    ///     Defines the test method TestGenerateCharacters.
    /// </summary>
    [Test]
    public void TestGenerateCharacters()
    {
        var rawText = "lorem ipsum dolor sit amet consetetur";
        var desiredCharacterCount = 10;
        var expectedText = rawText.Substring(0, desiredCharacterCount);

        var lipsum = new LipsumGenerator(rawText, false);

        var charsRetrieved = lipsum.GenerateCharacters(desiredCharacterCount);

        using (new AssertionScope())
        {
            charsRetrieved.Should().HaveCount(1);

            charsRetrieved[0].Should().NotBeNull().And.NotBeEmpty();
            charsRetrieved[0].Should().Be(expectedText);
        }
    }

    /// <summary>
    ///     Defines the test method TestRemoveEmptyElements.
    /// </summary>
    [Test]
    public void TestRemoveEmptyElements()
    {
        string[] arrayWithEmpties =
        {
            "", "lorem", "ipsum", null, string.Empty, "xxx"
        };

        string[] expectedArray =
        {
            "lorem", "ipsum", "xxx"
        };

        var expectedLength = 3;

        var returnedArray = LipsumUtilities.RemoveEmptyElements(arrayWithEmpties.ToList());

        using (new AssertionScope())
        {
            returnedArray.Should().HaveCount(expectedLength);
            returnedArray.Should().BeEquivalentTo(expectedArray);
            returnedArray.Should().NotContain(string.Empty);
            foreach (var s in returnedArray)
            {
                s.Should().NotBeNullOrEmpty();
            }
        }
    }

    /// <summary>
    ///     Defines the test method TestGenerateNoParams.
    /// </summary>
    [Test]
    public void TestGenerateNoParams()
    {
        var generated = LipsumGenerator.Generate(1);

        // What can I test to make sure this is working properly?
        // Null and empty don't seem like valid tests.
        generated.Should().NotBeNull().And.NotBeEmpty();
    }

    /// <summary>
    ///     Defines the test method TestGenerateHtmlNoParams.
    /// </summary>
    [Test]
    public void TestGenerateHtmlNoParams()
    {
        var generated = LipsumGenerator.GenerateHtml(1);

        // What can I test to make sure this is working properly?
        // Null and empty don't seem like valid tests.

        using (new AssertionScope())
        {
            generated.Should().NotBeNull().And.NotBeEmpty();
            generated.Should().StartWith("<p>");
            generated.Should().EndWith("</p>");
        }
    }

    /*
     * I realize there are some tests lacking
     * Feel free to write them.
     */
}