namespace Exercise1.Console.Filters;

public class MinimumLettersRule(int minimumNumberOfLetters) : IFilter<string>
{
    private const string SpecialCharacters = "!\"£$%^&*()[]{};:'@#~\\|,<.>/?\n ";
    public bool Filter(string input)
    {
        if (input == null)
        {
            return false;
        }

        if (SpecialCharacters.Contains(input) || input == Environment.NewLine)
        {
            return true;
        }

        return input.Length >= minimumNumberOfLetters;
    }
}