namespace Core.Contracts;


public interface IEntity<T>
{
    T Id { get; init; }
}

