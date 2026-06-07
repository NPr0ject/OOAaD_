namespace GameServer.Interfaces;

public interface IAuthorizable
{
    bool CheckAccess(string objectId, string action);
}
