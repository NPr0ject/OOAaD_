using GameServer.Models;
using Xunit;

namespace GameServer.Tests.Models;

public class GameTests
{
    private readonly Game _game;

    public GameTests()
    {
        _game = new Game(new Repository());
    }

    [Fact]
    public void AddObject_StoresObjectInRepository()
    {
        var obj = new GameObject("ship1");

        _game.AddObject(obj);

        var result = _game.GetObject("ship1");
        Assert.Equal("ship1", result.Id);
    }

    [Fact]
    public void GetObject_ThrowsForMissingId()
    {
        Assert.Throws<KeyNotFoundException>(() => _game.GetObject("missing"));
    }

    [Fact]
    public void RemoveObject_DeletesFromRepository()
    {
        var obj = new GameObject("ship1");
        _game.AddObject(obj);

        _game.RemoveObject("ship1");

        Assert.Throws<KeyNotFoundException>(() => _game.GetObject("ship1"));
    }
}
