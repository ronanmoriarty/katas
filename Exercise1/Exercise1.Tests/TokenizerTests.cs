using System.Text;
using Exercise1.Console;
using NUnit.Framework;

namespace Exercise1.Tests;

[TestFixture]
public class TokenizerTests
{
    [TestCase("Hello, World!", new[] { "Hello", ",", " ", "World", "!" })]
    public async Task CanParseStreamIntoTokens(string input, string[] expected)
    {
        using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(input));

        var asyncEnumerable = new Tokenizer().Parse(memoryStream);

        var result = await asyncEnumerable.ToListAsync(CancellationToken.None);
        Assert.That(result, Is.EquivalentTo(expected));
    }
}