namespace Spoon.NuGet.Core.Domain.Primitives;

/// <summary>
/// Class ValueObject.
/// </summary>
public abstract class ValueObject : IEquatable<ValueObject>
{
    /// <summary>
    /// Gets the atomic values.
    /// </summary>
    /// <returns>IEnumerable&lt;System.Object&gt;.</returns>
    public abstract IEnumerable<object> GetAtomicValues();

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns><see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
    public bool Equals(ValueObject? other)
    {
        return other is not null && this.ValuesAreEqual(other);
    }

    /// <summary>
    /// Equalses the specified object.
    /// </summary>
    /// <param name="obj">The object.</param>
    /// <returns>bool.</returns>
    public override bool Equals(object? obj)
    {
        return obj is ValueObject other && this.ValuesAreEqual(other);
    }

    /// <summary>
    /// Gets the hash code.
    /// </summary>
    /// <returns>int.</returns>
    public override int GetHashCode()
    {
        return this.GetAtomicValues()
            .Aggregate(
                default(int),
                HashCode.Combine);
    }

    /// <summary>
    /// Valueses the are equal.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns>bool.</returns>
    private bool ValuesAreEqual(ValueObject other)
    {
        return this.GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }
}