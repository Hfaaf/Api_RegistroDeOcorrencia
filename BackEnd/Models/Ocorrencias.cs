using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ANU.Models;

public class Ocorrencias
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; private set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string ResponsavelId { get; private set; }

    public string Regiao { get; private set; }
    public string Type { get; private set; }
    public DateTime Date { get; private set; }

    public Ocorrencias(string responsavelId, string regiao, string type, DateTime date)
    {
        ResponsavelId = responsavelId;
        Regiao = regiao;
        Type = type;
        Date = date;
    }
}
