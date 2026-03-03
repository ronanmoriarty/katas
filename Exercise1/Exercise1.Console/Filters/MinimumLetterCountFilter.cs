namespace Exercise1.Console.Filters;

public class MinimumLetterCountFilter(int minimumNumberOfLetters) : IFilter<string>
{
    public bool Filter(string input)
    {
        return input?.Length >= minimumNumberOfLetters;
    }
}