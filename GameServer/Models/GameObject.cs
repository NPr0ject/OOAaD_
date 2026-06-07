namespace GameServer.Models;

public class GameObject : Interfaces.IGameObject
{
    public string Id { get; }
    public IDictionary<string, object> Properties { get; }

    public GameObject(string id)
    {
        Id = id;
        Properties = new Dictionary<string, object>();
    }

    public T GetProperty<T>(string key)
    {
        if (!Properties.ContainsKey(key))
        {
            throw new KeyNotFoundException($"Property '{key}' not found on object '{Id}'");
        }

        return (T)Properties[key];
    }

    public void SetProperty(string key, object value)
    {
        Properties[key] = value;
    }

    public bool HasProperty(string key)
    {
        return Properties.ContainsKey(key);
    }
}
