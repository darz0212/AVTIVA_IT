using MongoDB.Bson;
using MongoDB.Driver;
using RouletteApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace RouletteApi.Repositories
{
    public class UserAlbumCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<UserAlbum> collection;

        public UserAlbumCollection()
        {
            collection = _repository.db.GetCollection<UserAlbum>("UserAlbums");
        }

        public List<UserAlbum> GetAllUsers()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

        public List<UserAlbum> GetAllAlbumUser(string id)
        {
            return collection.Find(x => x.idUser == id).ToList();
        }

        public UserAlbum GetUserSongsByIdUser(string idUser)
        {
            var result = collection.Find(x => x.idUser == idUser).FirstOrDefault();
            return result;
        }

        public string InsertUsers(UserAlbum user)
        {
            var result = collection.Find(x => x.idUser == user.idUser && x.idAlbum == user.idAlbum && x.idSong == user.idSong).FirstOrDefault();
            if(result == null)
                collection.InsertOne(user);
            else
            {
                var filter = Builders<UserAlbum>.Filter.Eq(x => new { x.idUser , x.idAlbum, x.idSong }, new { user.idUser,user.idAlbum ,user.idSong});
                if(filter != null)
                    collection.ReplaceOne(filter, user);
            }
            return user.id;
        }

        public string UpdateUsers(UserAlbum user, string id)
        {
            var filter = Builders<UserAlbum>.Filter.Eq(x => new { x.idUser, x.idAlbum, x.idSong }, new { user.idUser, user.idAlbum, user.idSong });
            user.id = id;
            if (filter != null)
                collection.ReplaceOne(filter, user);
            return user.id;
        }
    }
}
