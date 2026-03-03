// See https://aka.ms/new-console-template for more information

using Exercise1.Console;
using Exercise1.Console.Extensions;
using Exercise1.Console.Filters;

var filePath = Path.GetFullPath(args[0]);
await using var stream = new FileStream(Path.Combine(filePath), FileMode.Open);

var tokens = new Tokenizer().Parse(stream);

await tokens
    .Filter(new MiddleLetterFilter('a', 'e', 'i', 'o', 'u'))
    .Filter(new MinimumLetterCountFilter(3))
    .Filter(new ContainsLetterFilter('t'))
    .Apply(Console.Write);
