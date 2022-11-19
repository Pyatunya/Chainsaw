public interface IStorage
{
    T Load<T>(string key);

    void Save<T>(string key, T saveObject);

    bool Exists(string key);

    void DeleteSave(string path);
}