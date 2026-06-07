using GameServer.Interfaces;
using GameServer.Models;
using Xunit;

namespace GameServer.Tests.Models;

public class RepositoryTests
{
    [Fact]
    public void SetAndGet_ReturnsStoredValue()
    {
        var repository = new Repository();
        var obj = new GameObject("ship1");

        repository.Set("ship1", obj);
        var result = repository.Get("ship1");

        Assert.Equal(obj, result);
    }

    [Fact]
    public void Get_ReturnsNullForMissingKey()
    {
        var repository = new Repository();

        var result = repository.Get("missing");

        Assert.Null(result);
    }

    [Fact]
    public void Remove_DeletesKey()
    {
        var repository = new Repository();
        repository.Set("key", "value");

        var removed = repository.Remove("key");

        Assert.True(removed);
        Assert.Null(repository.Get("key"));
    }

    [Fact]
    public void Contains_ReturnsTrueForExistingKey()
    {
        var repository = new Repository();
        repository.Set("key", "value");

        Assert.True(repository.Contains("key"));
    }

    [Fact]
    public void Contains_ReturnsFalseForMissingKey()
    {
        var repository = new Repository();

        Assert.False(repository.Contains("missing"));
    }
}
