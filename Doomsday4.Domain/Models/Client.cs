using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Doomsday4.Domain.Models;

public class Client
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; } = null!;

    public string Surname { get; set; }

    public string PhoneNumber { get; set; } = null!;
}