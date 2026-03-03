using Exercise1.Console.Filters;
using NUnit.Framework;

namespace Exercise1.Tests.Filters;

[TestFixture]
public class DuplicateSpacesRuleTests
{
    [TestCase(new[]{" ", " "}, new[]{" "})]
    [TestCase(new[]{" ", " ", " "}, new[]{" "})]
    [TestCase(new[]{"Hello", " ", " ", "world"}, new[]{"Hello", " ", "world"})]
    [TestCase(new[]{"Hello", " ", " ", "world", " "}, new[]{"Hello", " ", "world", " "})]
    [TestCase(new[]{"Hello", " ", " ", "\r\n", "world", " "}, new[]{"Hello", " ", "\r\n", "world", " "})]
    public async Task AcceptedTokensAreIncluded(string[] inputTokens, string[] expectedTokens)
    {
        var asyncEnumerable = GenerateAsyncEnumerable(inputTokens);

        var results = await new DuplicateSpacesRule().Filter(asyncEnumerable).ToListAsync();

        Assert.That(results, Is.EquivalentTo(expectedTokens));
    }

    private async IAsyncEnumerable<string> GenerateAsyncEnumerable(string[] inputs)
    {
        foreach (var input in inputs)
        {
            yield return input;
        }
    }
}