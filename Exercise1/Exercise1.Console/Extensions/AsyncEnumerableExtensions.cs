using Exercise1.Console.Filters;

namespace Exercise1.Console.Extensions;

public static class AsyncEnumerableExtensions
{
    public static async IAsyncEnumerable<T> Filter<T>(this IAsyncEnumerable<T> asyncEnumerable,
        IFilter<T> filter)
    {
        await foreach (var item in asyncEnumerable)
        {
            if (filter.Filter(item))
            {
                yield return item;
            }
        }
    }

    public static async Task Apply<T>(this IAsyncEnumerable<T> asyncEnumerable,
        Action<T> action)
    {
        await foreach (var item in asyncEnumerable)
        {
            action(item);
        }
    }
}