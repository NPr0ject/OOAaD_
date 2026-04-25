using System.Linq;

namespace GameServer.Models;

public class Vector : IEquatable<Vector>
{
    private readonly int[] _components;

    public Vector(params int[] components)
    {
        if (components == null || components.Length == 0)
        {
            throw new ArgumentException("Vector must have at least one component.");
        }

        _components = components;
    }

    public int Dimensions => _components.Length;

    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= _components.Length)
            {
                throw new IndexOutOfRangeException();
            }
            return _components[index];
        }
    }

    public static Vector operator +(Vector a, Vector b)
    {
        if (a.Dimensions != b.Dimensions)
        {
            throw new ArgumentException("Vectors must have the same number of dimensions.");
        }

        var result = new int[a.Dimensions];
        for (int i = 0; i < a.Dimensions; i++)
        {
            result[i] = a[i] + b[i];
        }

        return new Vector(result);
    }

    public bool Equals(Vector? other)
    {
        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (ReferenceEquals(other, null))
        {
            return false;
        }

        if (Dimensions != other.Dimensions)
        {
            return false;
        }

        return _components.SequenceEqual(other._components);
    }

    public override bool Equals(object? obj) => Equals(obj as Vector);

    public static bool operator ==(Vector a, Vector b)
    {
        return object.Equals(a, b);
    }

    public static bool operator !=(Vector a, Vector b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return _components.Aggregate(17, (hash, component) => hash * 31 + component);
    }

    public override string ToString()
    {
        return $"({string.Join(", ", _components)})";
    }
}
