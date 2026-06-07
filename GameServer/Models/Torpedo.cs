using GameServer.Interfaces;

namespace GameServer.Models;

public class Torpedo : IMovingObject
{
    private Vector _position;

    public string Id { get; }
    public Vector Position => _position;
    public Vector Velocity { get; }

    public Torpedo(string id, Vector position, Vector velocity)
    {
        Id = id;
        _position = position;
        Velocity = velocity;
    }

    public void Move(Vector newPosition)
    {
        _position = newPosition;
    }
}
