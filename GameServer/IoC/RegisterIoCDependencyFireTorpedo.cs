using GameServer.Commands;
using GameServer.Interfaces;
using GameServer.IoC;
using GameServer.Models;

namespace GameServer.IoC;

public class RegisterIoCDependencyFireTorpedo : ICommand
{
    public void Execute()
    {
        Ioc.Register("Commands.FireTorpedo", (args) =>
        {
            var game = (IGame)args[0];
            var shipId = (string)args[1];
            var direction = (Vector)args[2];
            return new FireTorpedoCommand(game, shipId, direction);
        });

        Ioc.Register("Game.Repository", (args) =>
        {
            return new Repository();
        });

        Ioc.Register("Game.New", (args) =>
        {
            var repository = (IRepository)Ioc.Resolve("Game.Repository");
            return new Game(repository);
        });

        Ioc.Register("Game.Authorizable", (args) =>
        {
            var game = (IGame)args[0];
            return new Authorizable(game);
        });
    }
}
