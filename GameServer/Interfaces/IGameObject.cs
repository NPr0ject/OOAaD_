namespace GameServer.Interfaces;

public interface IGameObject
{
    string Id { get; }
    IDictionary<string, object> Properties { get; }
    T GetProperty<T>(string key);
    void SetProperty(string key, object value);
    bool HasProperty(string key);
}
