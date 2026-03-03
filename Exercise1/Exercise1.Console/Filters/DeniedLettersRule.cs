namespace Exercise1.Console.Filters;

public class DeniedLettersRule(char deniedLetter) : IFilter<string>
{
    private readonly char _deniedLetterInUpperCase = char.ToUpperInvariant(deniedLetter);

    public bool Filter(string input)
    {
        return input is null || !input
            .ToUpperInvariant()
            .Contains(_deniedLetterInUpperCase);
    }
}