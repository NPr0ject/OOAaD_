namespace GameServer.Interfaces;

public interface IGame
{
    IRepository Repository { get; }
    void AddObject(IGameObject gameObject);
    IGameObject GetObject(string id);
    void RemoveObject(string id);
}
