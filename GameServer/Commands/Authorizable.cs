using GameServer.Interfaces;

namespace GameServer.Commands;

public class Authorizable : IAuthorizable
{
    private readonly IGame _game;

    public Authorizable(IGame game)
    {
        _game = game;
    }

    public bool CheckAccess(string objectId, string action)
    {
        if (!_game.Repository.Contains(objectId))
        {
            return false;
        }

        var gameObject = _game.GetObject(objectId);
        if (!gameObject.HasProperty("owner"))
        {
            return false;
        }

        return true;
    }
}
