using Exercise1.Console.Filters;
using NUnit.Framework;

namespace Exercise1.Tests.Filters;

[TestFixture]
public class HasMinimumNumberOfLettersRuleTests
{
    [TestCase("hat", 3, true)]
    [TestCase("ha", 3, false)]
    [TestCase("hat", 4, false)]
    [TestCase(null, 1, false)]
    public void OnlyReturnsTrueWhenMinimumNumberOfLettersFound(string input,
        int minimumNumberOfLetters,
        bool expected)
    {
        var result = new HasMinimumNumberOfLettersRule(minimumNumberOfLetters).Filter(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCaseSource(nameof(GetSpecialCharacterTestCases))]
    public void SpecialCharactersAreExempt(string input)
    {
        var result = new HasMinimumNumberOfLettersRule(3).Filter(input);
        Assert.That(result, Is.True);
    }

    internal static IEnumerable<TestCaseData> GetSpecialCharacterTestCases()
    {
        return "!\"£$%^&*()[]{};:'@#~\\|,<.>/?\n "
            .ToCharArray()
            .Select(c => new TestCaseData(c.ToString()))
            .Concat([new TestCaseData("\r\n")]);
    }
}