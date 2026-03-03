using Exercise1.Console.Filters;
using NUnit.Framework;

namespace Exercise1.Tests.Filters;

[TestFixture]
public class DeniedLettersInMiddleRuleTests
{
    [TestCase("hat", "a", false)]
    [TestCase("hit", "a", true)]
    [TestCase("hiet", "a", true)]
    [TestCase("hiet", "i", false)]
    [TestCase("hiet", "e", false)]
    [TestCase("cat", "aeiou", false)]
    [TestCase("cat", "aeiou", false)]
    [TestCase("dog", "aeiou", false)]
    [TestCase("mouse", "aeiou", false)]
    [TestCase("abc", "aeiou", true)]
    [TestCase("abcd", "aeiou", true)]
    public void OnlyReturnsTrueWhenDeniedCharactersNotFoundInMiddle(string input,
        string deniedMiddleCharacters,
        bool expected)
    {
        var result = new DeniedLettersInMiddleRule(deniedMiddleCharacters.ToCharArray()).Filter(input);
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [TestCase("ORANGE", "aeiou", false)]
    [TestCase("MARMALADE", "aeiou", false)]
    public void IsCaseInsensitive(string input,
        string deniedMiddleCharacters,
        bool expected)
    {
        var result = new DeniedLettersInMiddleRule(deniedMiddleCharacters.ToCharArray()).Filter(input);
        Assert.That(result, Is.EqualTo(expected));
    }
}