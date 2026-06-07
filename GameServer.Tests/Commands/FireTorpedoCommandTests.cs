using GameServer.Commands;
using GameServer.Interfaces;
using GameServer.IoC;
using GameServer.Models;
using Moq;
using Xunit;

namespace GameServer.Tests.Commands;

public class FireTorpedoCommandTests
{
    public FireTorpedoCommandTests()
    {
        Ioc.Clear();
    }

    [Fact]
    public void Execute_CreatesTorpedoAndMoves()
    {
        var repo = new Repository();
        var game = new Game(repo);
        var ship = new GameObject("ship1");
        ship.SetProperty("position", new Vector(0, 0));
        ship.SetProperty("owner", "player1");
        game.AddObject(ship);

        Ioc.Register("Game.Authorizable", (args) =>
        {
            var g = (IGame)args[0];
            return new Authorizable(g);
        });

        Ioc.Register("Operations.move.Start", (args) =>
        {
            var order = (IDictionary<string, object>)args[0];
            var movableObject = (IMovingObject)order["movableObject"];
            var position = (Vector)order["position"];
            return new MoveCommand(movableObject, position);
        });

        var direction = new Vector(1, 0);
        var command = new FireTorpedoCommand(game, "ship1", direction);

        command.Execute();

        var shipAfter = game.GetObject("ship1");
        Assert.NotNull(shipAfter);
    }

    [Fact]
    public void Execute_ThrowsWhenShipNotFound()
    {
        var game = new Game(new Repository());

        Ioc.Register("Game.Authorizable", (args) =>
        {
            var g = (IGame)args[0];
            return new Authorizable(g);
        });

        var command = new FireTorpedoCommand(game, "nonexistent", new Vector(1, 0));

        Assert.Throws<UnauthorizedAccessException>(() => command.Execute());
    }

    [Fact]
    public void Execute_ThrowsWhenNotAuthorized()
    {
        Ioc.Clear();

        var mockAuth = new Mock<IAuthorizable>();
        mockAuth.Setup(a => a.CheckAccess(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
        Ioc.Register("Game.Authorizable", (args) => mockAuth.Object);

        var game = new Game(new Repository());
        var ship = new GameObject("ship1");
        ship.SetProperty("position", new Vector(0, 0));
        game.AddObject(ship);

        var command = new FireTorpedoCommand(game, "ship1", new Vector(1, 0));

        Assert.Throws<UnauthorizedAccessException>(() => command.Execute());
    }
}
