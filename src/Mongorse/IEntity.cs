using MongoDB.Bson.Serialization.Attributes;

namespace Mongorse;

public interface IEntity<TId> where TId : IComparable<TId>, IEquatable<TId>
{
    [BsonId]
    TId Id { get; set; }
}

public interface IEntity : IEntity<string>
{
}