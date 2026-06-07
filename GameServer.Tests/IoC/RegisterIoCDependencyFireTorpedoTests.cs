using GameServer.Commands;
using GameServer.Interfaces;
using GameServer.IoC;
using GameServer.Models;
using Xunit;

namespace GameServer.Tests.IoC;

public class RegisterIoCDependencyFireTorpedoTests
{
    [Fact]
    public void Execute_RegistersCommandsFireTorpedo()
    {
        Ioc.Clear();
        var command = new RegisterIoCDependencyFireTorpedo();

        command.Execute();

        var game = (IGame)Ioc.Resolve("Game.New");
        Assert.NotNull(game);
        Assert.NotNull(game.Repository);
    }

    [Fact]
    public void Execute_RegistersGameRepository()
    {
        Ioc.Clear();
        var command = new RegisterIoCDependencyFireTorpedo();

        command.Execute();

        var repo = (IRepository)Ioc.Resolve("Game.Repository");
        Assert.NotNull(repo);
    }

    [Fact]
    public void Execute_RegistersGameAuthorizable()
    {
        Ioc.Clear();
        var command = new RegisterIoCDependencyFireTorpedo();

        command.Execute();

        var game = (IGame)Ioc.Resolve("Game.New");
        var authorizable = (IAuthorizable)Ioc.Resolve("Game.Authorizable", game, "ship1");
        Assert.NotNull(authorizable);
    }

    [Fact]
    public void Execute_RegistersCommandsFireTorpedoStrategy()
    {
        Ioc.Clear();
        var command = new RegisterIoCDependencyFireTorpedo();

        command.Execute();

        var game = (IGame)Ioc.Resolve("Game.New");
        var ship = new GameObject("ship1");
        ship.SetProperty("position", new Vector(0, 0));
        ship.SetProperty("owner", "player1");
        game.AddObject(ship);

        var fireCommand = (ICommand)Ioc.Resolve("Commands.FireTorpedo", game, "ship1", new Vector(1, 0));
        Assert.NotNull(fireCommand);
        Assert.IsType<FireTorpedoCommand>(fireCommand);
    }
}
