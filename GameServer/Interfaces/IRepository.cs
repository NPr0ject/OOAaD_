namespace GameServer.Interfaces;

public interface IRepository
{
    object? Get(string key);
    void Set(string key, object value);
    bool Remove(string key);
    bool Contains(string key);
}
