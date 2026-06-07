using GameServer.Interfaces;

namespace GameServer.Models;

public class Game : IGame
{
    public IRepository Repository { get; }

    public Game(IRepository repository)
    {
        Repository = repository;
    }

    public void AddObject(IGameObject gameObject)
    {
        Repository.Set(gameObject.Id, gameObject);
    }

    public IGameObject GetObject(string id)
    {
        var obj = Repository.Get(id);
        if (obj == null)
        {
            throw new KeyNotFoundException($"Game object with id '{id}' not found");
        }
        return (IGameObject)obj;
    }

    public void RemoveObject(string id)
    {
        Repository.Remove(id);
    }
}
