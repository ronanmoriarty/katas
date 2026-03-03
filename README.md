# Katas

## Exercise 1 Notes

To generate output:
```
cd Exercise1
dotnet build
dotnet test
Exercise1.Console\bin\Debug\net10.0\Exercise1.Console.exe input.txt
```

## Caveats

I'm not a fan of premature optimisation, or trying to predict too many scenarios we might want to cater for in future (YAGNI), but in the context of recent conversations, I decided it would be quite interesting to tackle this from the perspective of potentially being able to handle very large files, even though the file in question is quite small in this case.

In the interests of time, I haven't been as defensive as I would normally be, i.e. I haven't considered many failure scenarios in unit tests. I've added some minimal null checking, but that's about it - it felt like a distraction from the main task.

I didn't remove spaces at the start of lines. It would have been a similar exercise to the `DuplicateSpacesRule` (i.e. comparing space token with previous line ending tokens, vs comparing space tokens with previous space tokens) so didn't feel like it would have given any great insights.

I haven't tested the overall interaction of all these components with each other (i.e. how they're all connected in `Program.cs`) though that's something I would want to do in a real system.
