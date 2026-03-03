namespace Exercise1.Console.Filters;

public class DeniedLettersInMiddleRule(params IEnumerable<char> deniedMiddleCharacters) : IFilter<string>
{
    private readonly IEnumerable<char> _deniedMiddleCharactersInUpperCase = deniedMiddleCharacters.Select(char.ToUpperInvariant);

    public bool Filter(string input)
    {
        var upperCaseInput = input.ToUpperInvariant();
        var indices = new List<int>();
        if (input.Length % 2 == 0)
        {
            indices.Add(input.Length / 2); // 4 -> 2
            indices.Add(input.Length / 2 - 1); // 4 -> 1
        }
        else
        {
            indices.Add(input.Length / 2); // 4 -> 2
        }

        return indices.All(index => !_deniedMiddleCharactersInUpperCase.Contains(upperCaseInput[index]));
    }
}