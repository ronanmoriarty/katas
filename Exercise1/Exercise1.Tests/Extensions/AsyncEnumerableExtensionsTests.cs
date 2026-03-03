using Exercise1.Console.Extensions;
using Exercise1.Console.Filters;
using NSubstitute;
using NUnit.Framework;

namespace Exercise1.Tests.Extensions;

[TestFixture]
public class AsyncEnumerableExtensionsTests
{
    [Test]
    public async Task RejectedTokensAreExcluded()
    {
        var inputs = new[] {"Hello", " ", "world", "!"};
        var filter = Substitute.For<IFilter<string>>();
        filter.Filter(Arg.Any<string>()).Returns(false);
        var asyncEnumerable = GenerateAsyncEnumerable(inputs);

        var results = await asyncEnumerable.Filter(filter).ToListAsync();

        Assert.That(results, Is.Empty);
    }

    [Test]
    public async Task AcceptedTokensAreIncluded()
    {
        var inputs = new[] {"Hello", " ", "world", "!"};
        var filter = Substitute.For<IFilter<string>>();
        filter.Filter(Arg.Any<string>()).Returns(true);
        var asyncEnumerable = GenerateAsyncEnumerable(inputs);

        var results = await asyncEnumerable.Filter(filter).ToListAsync();

        Assert.That(results, Is.EquivalentTo(inputs));
    }

    [Test]
    public async Task ApplyRunsActionForEachToken()
    {
        var inputs = new[] {"Hello", " ", "world", "!"};
        var actualActionArgs = new List<string>();
        var action = Substitute.For<Action<string>>();
        action
            .When(act => act.Invoke(Arg.Any<string>()))
            .Do(callInfo => actualActionArgs.Add(callInfo.Arg<string>()));
        var asyncEnumerable = GenerateAsyncEnumerable(inputs);

        await asyncEnumerable.Apply(action);

        Assert.That(actualActionArgs, Is.EquivalentTo(inputs));
    }

    private async IAsyncEnumerable<string> GenerateAsyncEnumerable(string[] inputs)
    {
        foreach (var input in inputs)
        {
            yield return input;
        }
    }
}