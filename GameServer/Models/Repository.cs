using GameServer.Interfaces;

namespace GameServer.Models;

public class Repository : IRepository
{
    private readonly Dictionary<string, object> _storage = new();

    public object? Get(string key)
    {
        _storage.TryGetValue(key, out var value);
        return value;
    }

    public void Set(string key, object value)
    {
        _storage[key] = value;
    }

    public bool Remove(string key)
    {
        return _storage.Remove(key);
    }

    public bool Contains(string key)
    {
        return _storage.ContainsKey(key);
    }
}
