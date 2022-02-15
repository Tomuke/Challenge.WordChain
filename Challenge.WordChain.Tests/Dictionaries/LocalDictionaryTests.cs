using System;
using Challenge.WordChain.Dictionaries;
using Challenge.WordChain.Rules;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Challenge.WordChain.Tests.Rules;

[TestClass]
public class LocalDictionaryTests
{
    [TestMethod]
    public void GivenStartWordSameAsEndWord_IsInvalid()
    {
        var rule = new LocalDictionary();

        var result = rule.IsValid("dog", "dog");

        result.Should().BeFalse();
    }

    [TestMethod]
    public void GivenStartWordIsDifferentFromEndWord_IsValid()
    {
        var rule = new MustBeDifferentWords();

        var result = rule.IsValid("dog", "cat");

        result.Should().BeTrue();
    }
}
