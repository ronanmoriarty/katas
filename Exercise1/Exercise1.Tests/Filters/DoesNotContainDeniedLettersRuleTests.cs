using Exercise1.Console.Filters;
using NUnit.Framework;

namespace Exercise1.Tests.Filters;

[TestFixture]
public class DoesNotContainDeniedLettersRuleTests
{
    [TestCase("hat", 'a', false)]
    [TestCase("hat", 'b', true)]
    [TestCase(null, 'b', true)]
    public void OnlyReturnsTrueWhenDeniedCharacterNotFound(string input,
        char deniedCharacter,
        bool expected)
    {
        var result = new DoesNotContainDeniedLettersRule(deniedCharacter).Filter(input);
        Assert.That(result, Is.EqualTo(expected));
    }
}