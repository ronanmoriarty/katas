namespace Exercise1.Console.Filters;

public interface IFilter<T>
{
    bool Filter(T input);
}