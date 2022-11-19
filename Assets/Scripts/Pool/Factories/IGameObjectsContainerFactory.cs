using System.Collections.Generic;


public interface IGameObjectsContainerFactory<T> : IFactory<T>
{
    IEnumerable<T> CreatedObjects { get; }
}