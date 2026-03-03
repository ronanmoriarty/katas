namespace Exercise1.Console.Filters;

public class DeniedLettersRule(char deniedLetter) : IFilter<string>
{
    public bool Filter(string input)
    {
        var deniedLetterInUpperCase = new string([deniedLetter])
            .ToUpperInvariant()[0];
        return input is null || !input
            .ToUpperInvariant()
            .Contains(deniedLetterInUpperCase);
    }
}