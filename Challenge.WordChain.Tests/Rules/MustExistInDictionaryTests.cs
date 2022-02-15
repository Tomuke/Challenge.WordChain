using System;
using Challenge.WordChain.Dictionaries;
using Challenge.WordChain.Rules;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Challenge.WordChain.Tests.Rules;

[TestClass]
public class MustExistInDictionaryTests
{
    private IWordDictionary _dictionary;

    public MustExistInDictionaryTests()
    {
        var dictionary = new Mock<IWordDictionary>();

        dictionary.Setup(x => x.Words).Returns(new string[]
        {
            "cat",
            "dog"
        });

        this._dictionary = dictionary.Object;
    }

    [TestMethod]
    public void GivenNullDictionary_ThrowsArgumentNullException()
    {
        Action act = () => new MustExistInDictionary(null);
        
        act.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void GivenStartWordThatDoesNotExistInDictionary_IsInvalid()
    {
        var rule = new MustExistInDictionary(this._dictionary);

        var result = rule.IsValid("not_a_real_word", "dog");

        result.Should().BeFalse();
    }

    [TestMethod]
    public void GivenEndWordThatDoesNotExistInDictionary_IsInvalid()
    {
        var rule = new MustExistInDictionary(this._dictionary);

        var result = rule.IsValid("dog", "not_a_real_word");

        result.Should().BeFalse();
    }

    [TestMethod]
    public void GivenStartAndEndWordsThatDoesExistInDictionary_IsValid()
    {
        var rule = new MustExistInDictionary(this._dictionary);

        var result = rule.IsValid("cat", "dog");

        result.Should().BeTrue();
    }
}
