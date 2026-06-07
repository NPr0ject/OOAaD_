using GameServer.Commands;
using GameServer.Interfaces;
using GameServer.Models;
using Xunit;

namespace GameServer.Tests.Commands;

public class AuthorizableTests
{
    [Fact]
    public void CheckAccess_ReturnsTrueWhenObjectHasOwner()
    {
        var repo = new Repository();
        var game = new Game(repo);
        var ship = new GameObject("ship1");
        ship.SetProperty("owner", "player1");
        game.AddObject(ship);

        var authorizable = new Authorizable(game);

        Assert.True(authorizable.CheckAccess("ship1", "fire"));
    }

    [Fact]
    public void CheckAccess_ReturnsFalseWhenObjectNotFound()
    {
        var game = new Game(new Repository());
        var authorizable = new Authorizable(game);

        Assert.False(authorizable.CheckAccess("missing", "fire"));
    }

    [Fact]
    public void CheckAccess_ReturnsFalseWhenNoOwnerProperty()
    {
        var repo = new Repository();
        var game = new Game(repo);
        var obj = new GameObject("obj1");
        game.AddObject(obj);

        var authorizable = new Authorizable(game);

        Assert.False(authorizable.CheckAccess("obj1", "fire"));
    }
}
