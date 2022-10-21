using NLipsum.Core;
using NLipsum.Core.Features;
using NUnit.Framework;

namespace NLipsum.Tests;

[TestFixture]
public class LipsumTests
{
    #region Constructor tests

    [Test]
    public void TestLoadXml()
    {
        var template = "<root><text>{0}</text></root>";
        var expectedText = "Lorem ipsum dolor sit amet";
        var formatted = string.Format(template, expectedText);

        var lipsum = new LipsumGenerator(formatted, true);
        Assert.AreEqual(lipsum.LipsumText.ToString(), expectedText);
    }

    [Test]
    public void TestLoadPlainText()
    {
        var expectedText = "Lorem ipsum dolor sit amet";

        var lipsum = new LipsumGenerator(expectedText, false);
        Assert.AreEqual(lipsum.LipsumText.ToString(), expectedText);
    }

    [Test]
    public void DefaultConstructorContainsLoremIpsum()
    {
        var expected = Lipsums.LoremIpsum;
        var generator = new LipsumGenerator();
        Assert.AreEqual(expected, generator.LipsumText.ToString());
    }

    #endregion

    #region Words

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

        Assert.AreEqual(wordsInRawText, wordsPrepared.Count);
        CollectionAssert.AreEqual(wordsPrepared, expectedArray);
    }

    [Test]
    public void TestGenerateWords()
    {
        var rawText = "lorem ipsum dolor sit amet consetetur";

        var lipsum = new LipsumGenerator(rawText, false);

        var wordCount = 4;

        var generatedWords = lipsum.GenerateWords(wordCount);

        Assert.AreEqual(wordCount, generatedWords.Count);

        for (var i = 0; i < wordCount; i++)
        {
            StringAssert.Contains(generatedWords[i], rawText);
        }
    }

    #endregion

    #region Sentences

    [Test]
    public void TestGenerateSentences()
    {
        var rawText = Lipsums.LoremIpsum;
        var lipsum = new LipsumGenerator(rawText, false);

        var desiredSentenceCount = 5;
        var generatedSentences = lipsum.GenerateSentences(desiredSentenceCount, Sentence.Medium);

        Assert.AreEqual(desiredSentenceCount, generatedSentences.Count,
            "Retrieved sentence count mismatch.");

        for (var i = 0; i < desiredSentenceCount; i++)
        {
            Assert.IsNotNull(generatedSentences[i],
                string.Format("Generated sentence [{0}] is null.", i));
            Assert.IsNotEmpty(generatedSentences[i]);
        }
    }

    [Test]
    public void TestSentenceCapitalizationAndPunctuation()
    {
        var rawText = "this";
        var lipsum = new LipsumGenerator(rawText, false);
        var generatedSentences = lipsum.GenerateSentences(1, new Sentence(1, 1));
        var desiredSentence = "This.";
        Assert.AreEqual(desiredSentence, generatedSentences[0]);
    }

    #endregion

    #region Paragraphs

    [Test]
    public void TestGenerateParagraphs()
    {
        var rawText = Lipsums.LoremIpsum;
        var lipsum = new LipsumGenerator(rawText, false);

        var desiredParagraphCount = 5;
        var generatedParagraphs = lipsum.GenerateParagraphs(desiredParagraphCount, Paragraph.Medium);


        Assert.AreEqual(desiredParagraphCount, generatedParagraphs.Count, "Retrieved sentence count mismatch.");

        for (var i = 0; i < desiredParagraphCount; i++)
        {
            Assert.IsNotNull(generatedParagraphs[i],
                string.Format("Generated paragraph [{0}] is null.", i));
            Assert.IsNotEmpty(generatedParagraphs[i]);
        }
    }

    #endregion

    #region Characters

    [Test]
    public void TestGenerateCharacters()
    {
        var rawText = "lorem ipsum dolor sit amet consetetur";
        var desiredCharacterCount = 10;
        var expectedText = rawText.Substring(0, desiredCharacterCount);

        var lipsum = new LipsumGenerator(rawText, false);

        var charsRetrieved = lipsum.GenerateCharacters(desiredCharacterCount);

        // This should only retrieve one string
        Assert.AreEqual(1, charsRetrieved.Count);

        var generatedString = charsRetrieved[0];
        Assert.IsNotNull(generatedString);
        Assert.IsNotEmpty(generatedString);

        Assert.AreEqual(expectedText, generatedString);
    }

    #endregion

    #region Utilities Tests

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

        CollectionAssert.DoesNotContain(returnedArray, "");
        CollectionAssert.AllItemsAreNotNull(returnedArray);
        CollectionAssert.AllItemsAreInstancesOfType(returnedArray, typeof(string));
        Assert.AreEqual(expectedLength, returnedArray.Count);
        CollectionAssert.AreEqual(expectedArray, returnedArray);
    }

    #endregion

    #region Static Method Tests

    [Test]
    public void TestGenerateNoParams()
    {
        var rawText = Lipsums.LoremIpsum;
        var generated = LipsumGenerator.Generate(1);

        // What can I test to make sure this is working properly?
        // Null and empty don't seem like valid tests.

        Assert.IsNotNull(generated);
        Assert.IsNotEmpty(generated);
    }

    [Test]
    public void TestGenerateHtmlNoParams()
    {
        var rawText = Lipsums.LoremIpsum;
        var generated = LipsumGenerator.GenerateHtml(1);

        // What can I test to make sure this is working properly?
        // Null and empty don't seem like valid tests.

        Assert.IsNotNull(generated);
        Assert.IsNotEmpty(generated);
        StringAssert.StartsWith("<p>", generated);
        StringAssert.EndsWith("</p>", generated);
    }

    #endregion

    /*
     * I realize there are some tests lacking
     * Feel free to write them.
     */
}