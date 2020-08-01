
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RouletteApi.Models
{
    public class UserAlbum
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string idAlbum { get; set; }
        public string idUser { get; set; }
        public string idSong { get; set; }
        public string title { get; set; }
        public bool isFavorite { get; set; }
        public bool isHide { get; set; }
        public bool isInapropiate { get; set; }
        public bool isDeleted { get; set; }
    }
}
