namespace Exercise1.Console.Filters;

public class ContainsLetterFilter(char deniedLetter) : IFilter<string>
{
    public bool Filter(string input)
    {
        return input is null || !input.Contains(deniedLetter);
    }
}