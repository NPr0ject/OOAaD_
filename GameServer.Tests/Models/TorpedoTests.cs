using GameServer.Models;
using Xunit;

namespace GameServer.Tests.Models;

public class TorpedoTests
{
    [Fact]
    public void Move_UpdatesPosition()
    {
        var torpedo = new Torpedo("t1", new Vector(0, 0), new Vector(1, 1));

        torpedo.Move(new Vector(1, 1));

        Assert.Equal(new Vector(1, 1), torpedo.Position);
    }

    [Fact]
    public void Constructor_SetsProperties()
    {
        var position = new Vector(5, 10);
        var velocity = new Vector(1, 0);

        var torpedo = new Torpedo("t1", position, velocity);

        Assert.Equal("t1", torpedo.Id);
        Assert.Equal(position, torpedo.Position);
        Assert.Equal(velocity, torpedo.Velocity);
    }
}
