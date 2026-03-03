using System.Text;

namespace Exercise1.Console;

public class Tokenizer
{
    public async IAsyncEnumerable<string> Parse(Stream input)
    {
        using var streamReader = new StreamReader(input);
        string line;
        while ((line = await streamReader.ReadLineAsync()) is not null)
        {
            var stringBuilder = new StringBuilder();
            var previousCharacterIsLetter = false;
            foreach (var c in line)
            {
                if (char.IsLetter(c)) // we can add test cases with multi-digit numbers to force updating this to char.IsLetterOrDigit(), but not required for now
                {
                    stringBuilder.Append(c);
                    previousCharacterIsLetter = true;
                }
                else
                {
                    if (previousCharacterIsLetter)
                    {
                        // Reached the end of a word
                        yield return stringBuilder.ToString();
                        stringBuilder.Clear();
                    }

                    yield return c.ToString();
                    previousCharacterIsLetter = false;
                }
            }
        }
    }
}