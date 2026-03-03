namespace Exercise1.Console.Filters;

public class MinimumLetterCountFilter(int minimumNumberOfLetters)
{
    public bool Filter(string input)
    {
        return input.Length >= 3;
    }
}