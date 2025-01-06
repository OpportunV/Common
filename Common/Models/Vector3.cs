using System.Numerics;

namespace Common.Models;

public record Vector3<T>(T X, T Y, T Z) where T : INumber<T>
{
    public static Vector3<T> Zero => new(T.Zero, T.Zero, T.Zero);

    public T Dot(Vector3<T> other)
    {
        return X * other.X + Y * other.Y + Z * other.Z;
    }

    public Vector3<T> Cross(Vector3<T> other)
    {
        return new Vector3<T>(Y * other.Z - Z * other.Y, Z * other.X - X * other.Z, X * other.Y - Y * other.X);
    }

    public T LengthSquared()
    {
        return Dot(this);
    }

    public static Vector3<T> operator +(Vector3<T> v1, Vector3<T> v2)
    {
        return new Vector3<T>(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    }

    public static Vector3<T> operator -(Vector3<T> v1, Vector3<T> v2)
    {
        return new Vector3<T>(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
    }

    public static Vector3<T> operator *(Vector3<T> v, T scalar)
    {
        return new Vector3<T>(v.X * scalar, v.Y * scalar, v.Z * scalar);
    }
}