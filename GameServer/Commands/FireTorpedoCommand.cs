using GameServer.Interfaces;
using GameServer.IoC;
using GameServer.Models;

namespace GameServer.Commands;

public class FireTorpedoCommand : ICommand
{
    private readonly IGame _game;
    private readonly string _shipId;
    private readonly Vector _direction;

    public FireTorpedoCommand(IGame game, string shipId, Vector direction)
    {
        _game = game;
        _shipId = shipId;
        _direction = direction;
    }

    public void Execute()
    {
        var authorizable = (IAuthorizable)Ioc.Resolve("Game.Authorizable", _game, _shipId);
        if (!authorizable.CheckAccess(_shipId, "fire"))
        {
            throw new UnauthorizedAccessException($"Ship '{_shipId}' is not authorized to fire");
        }

        var ship = _game.GetObject(_shipId);
        var shipPosition = ship.GetProperty<Vector>("position");

        var torpedoId = $"torpedo_{_shipId}_{Guid.NewGuid():N}";
        var torpedo = new Torpedo(torpedoId, shipPosition, _direction);

        _game.AddObject(torpedo);

        var moveCommand = (ICommand)Ioc.Resolve("Operations.move.Start", new Dictionary<string, object>
        {
            ["movableObject"] = torpedo,
            ["position"] = shipPosition + _direction
        });
        moveCommand.Execute();
    }
}
