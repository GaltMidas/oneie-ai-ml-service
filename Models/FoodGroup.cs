using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace oneie_ai_ml_service.Models
{
    public class FoodGroup
    {
        [BsonId]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}