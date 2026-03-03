# Katas

## Exercise 1 Notes
I'm not a fan of premature optimisation, or trying to predict too many scenarios we might want to cater for in future (YAGNI), but in the context of recent conversations, I decided it would be quite interesting to tackle this from the perspective of potentially being able to handle very large files, even though the file in question is quite small in this case.

In the interests of time, I haven't been as defensive as I would normally be, i.e. I haven't considered many failure scenarios in unit tests. I've added some minimal null checking, but that's about it - it felt like a distraction from the main task.

## Deliberately Not Implemented
I didn't remove spaces at the start of lines. It would have been a similar exercise to the `DuplicateSpacesRule` (i.e. comparing space token with previous line ending tokens, vs comparing space tokens with previous space tokens) so didn't feel like it would have given any great insights.
I decided that keeping line endings and all other punctuation was important (especially as the punctuation in the input was quite unusual to start with)
I haven't fully tested the interaction of all these components with each other - that's something I'd want to consider in a real system.
