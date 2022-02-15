using System;
using Challenge.WordChain.Dictionaries;
using Challenge.WordChain.Rules;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Challenge.WordChain.Tests.Rules;

[TestClass]
public class MustHaveEqualNumberOfCharactersTests
{
    [TestMethod]
    public void GivenStartWordSameAsEndWord_IsInvalid()
    {
        var rule = new MustHaveEqualNumberOfCharacters();

        var result = rule.IsValid("long", "longer");

        result.Should().BeFalse();
    }

    [TestMethod]
    public void GivenStartWordIsDifferentFromEndWord_IsValid()
    {
        var rule = new MustHaveEqualNumberOfCharacters();

        var result = rule.IsValid("same", "same");

        result.Should().BeTrue();
    }
}
