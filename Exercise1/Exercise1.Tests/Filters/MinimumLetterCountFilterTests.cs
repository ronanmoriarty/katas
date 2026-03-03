using Exercise1.Console.Filters;
using NUnit.Framework;

namespace Exercise1.Tests.Filters;

[TestFixture]
public class MinimumLetterCountFilterTests
{
    [TestCase("hat", 3, true)]
    [TestCase("ha", 3, false)]
    [TestCase("hat", 4, false)]
    [TestCase(null, 1, false)]
    public void OnlyReturnsTrueWhenMinimumNumberOfLettersFound(string input,
        int minimumNumberOfLetters,
        bool expected)
    {
        var result = new MinimumLetterCountFilter(minimumNumberOfLetters).Filter(input);
        Assert.That(result, Is.EqualTo(expected));
    }
}