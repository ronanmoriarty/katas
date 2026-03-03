namespace Exercise1.Console.Filters;

public class ContainsLetterFilter(char deniedLetter)
{
    public bool Filter(string input)
    {
        return input is null || !input.Contains(deniedLetter);
    }
}