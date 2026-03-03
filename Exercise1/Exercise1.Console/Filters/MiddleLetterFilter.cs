namespace Exercise1.Console.Filters;

public class MiddleLetterFilter(params IEnumerable<char> deniedMiddleCharacters) : IFilter<string>
{
    public bool Filter(string input)
    {
        IList<int> indices = new List<int>();
        if (input.Length % 2 == 0)
        {
            indices.Add(input.Length / 2); // 4 -> 2
            indices.Add(input.Length / 2 - 1); // 4 -> 1
        }
        else
        {
            indices.Add(input.Length / 2); // 4 -> 2
        }

        return indices.All(index => !deniedMiddleCharacters.Contains(input[index]));
    }
}