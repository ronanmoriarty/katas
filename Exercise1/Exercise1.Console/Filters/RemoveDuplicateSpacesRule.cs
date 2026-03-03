namespace Exercise1.Console.Filters;

public class RemoveDuplicateSpacesRule
{
    public async IAsyncEnumerable<string> Filter(IAsyncEnumerable<string> input)
    {
        var previousTokenWasSpace = false;
        await foreach (var token in input)
        {
            if (token.IsWhiteSpace())
            {
                if (!previousTokenWasSpace)
                {
                    // We'll only output this first whitespace in a chain of whitespaces
                    yield return token;
                }

                previousTokenWasSpace = true;
            }
            else
            {
                yield return token;
                previousTokenWasSpace = false;
            }
        }
    }
}