using GameServer.Models;
using Xunit;

namespace GameServer.Tests.Models;

public class GameObjectTests
{
    [Fact]
    public void GetProperty_ReturnsStoredValue()
    {
        var obj = new GameObject("ship1");
        obj.SetProperty("position", new Vector(1, 2));

        var result = obj.GetProperty<Vector>("position");

        Assert.Equal(new Vector(1, 2), result);
    }

    [Fact]
    public void GetProperty_ThrowsForMissingKey()
    {
        var obj = new GameObject("ship1");

        Assert.Throws<KeyNotFoundException>(() => obj.GetProperty<Vector>("missing"));
    }

    [Fact]
    public void HasProperty_ReturnsTrueForExisting()
    {
        var obj = new GameObject("ship1");
        obj.SetProperty("key", "value");

        Assert.True(obj.HasProperty("key"));
    }

    [Fact]
    public void HasProperty_ReturnsFalseForMissing()
    {
        var obj = new GameObject("ship1");

        Assert.False(obj.HasProperty("missing"));
    }
}
