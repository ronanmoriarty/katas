namespace Exercise1.Console.Filters;

public class MiddleLetterFilter(params IEnumerable<char> deniedMiddleCharacters)
{
    public bool Filter(string input)
    {
        int index = input.Length / 2;
        return !deniedMiddleCharacters.Contains(input[index]);
    }
}