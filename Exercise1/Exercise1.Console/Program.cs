// See https://aka.ms/new-console-template for more information

using Exercise1.Console;
using Exercise1.Console.Extensions;
using Exercise1.Console.Filters;

var filePath = Path.GetFullPath(args[0]);
await using var stream = new FileStream(Path.Combine(filePath), FileMode.Open);

var tokens = new Tokenizer().Parse(stream);

var filteredTokens = tokens
    .Filter(new DeniedLettersInMiddleRule('a', 'e', 'i', 'o', 'u'))
    .Filter(new MinimumLettersRule(3))
    .Filter(new DeniedLettersRule('t'));

var duplicateSpacesRule = new DuplicateSpacesRule();
var sanitizedTokens = duplicateSpacesRule.Filter(filteredTokens);

await sanitizedTokens
    .Apply(Console.Write);
