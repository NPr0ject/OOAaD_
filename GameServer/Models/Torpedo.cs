using GameServer.Interfaces;

namespace GameServer.Models;

public class Torpedo : IMovingObject, IGameObject
{
    private Vector _position;

    public string Id { get; }
    public IDictionary<string, object> Properties { get; }
    public Vector Position => _position;
    public Vector Velocity { get; }

    public Torpedo(string id, Vector position, Vector velocity)
    {
        Id = id;
        _position = position;
        Velocity = velocity;
        Properties = new Dictionary<string, object>();
    }

    public void Move(Vector newPosition)
    {
        _position = newPosition;
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
