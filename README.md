# Katas

## Exercise 1 Notes
I'm not a fan of premature optimisation, or trying to predict too many scenarios we might want to cater for in future (YAGNI), but in the context of recent conversations, I decided it would be quite interesting to tackle this from the perspective of potentially being able to handle very large files, even though the file in question is quite small in this case.

In the interests of time, I haven't been as defensive as I would normally be, i.e. I haven't considered many failure scenarios in unit tests. I've added some minimal null checking, but that's about it - it felt like a distraction from the main task.

After doing the filters and the tokenizer in typical TDD fashion, I then changed tack to focus on combining the parts and the output generated, as a sanity check for the work to that point. That highlighted gaps in tests for the `MinimumLettersRule` around special characters and line endings, which I then added.

The generated output also highlighted all the additional spacing left when sequential words are removed. This needed a slightly different approach, as all the filters up to this point were able to consider each token _in isolation_, whereas now we had to _compare_ the current token with previous tokens. I'm sure there's a refactoring I can do there to get it all chained together nicely, but I'd already spent enough time on it.

I wrote the code in Program.cs in TDD fashion, i.e. wrote the code in syntax I'd like to exist, and then decided how to make that syntax compile. That's where the `AsyncEnumerableExtensions` came from.

I wrote the tests for `AsyncEnumerableExtensions` using the process:
- comment out the code I wrote in `AsyncEnumerableExtensions`
- write tests to force me to uncomment the different parts I wrote previously
I took a similar approach for the `DuplicateSpacesRule`. So it's a TDD of sorts, but not strict TDD. I didn't get the design benefits of TDD in the tests (i.e. considering the design from the perspective of the consumer), but I got that benefit when I wrote the desired syntax in `Program.cs`.

## Deliberately Not Implemented
I didn't remove spaces at the start of lines. It would have been a similar exercise to the `DuplicateSpacesRule` (i.e. comparing space token with previous line ending tokens, vs comparing space tokens with previous space tokens) so didn't feel like it would have given any great insights.
I decided that keeping line endings and all other punctuation was important (especially as the punctuation in the input was quite unusual to start with)
I haven't fully tested the interaction of all these components with each other - that's something I'd want to consider in a real system.
