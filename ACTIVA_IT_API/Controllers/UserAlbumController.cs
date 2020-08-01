using Microsoft.AspNetCore.Mvc;
using RouletteApi.Models;
using RouletteApi.Repositories;

namespace RouletteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAlbumController : Controller
    {
        private UserAlbumCollection db = new UserAlbumCollection();

        [HttpGet]
        public IActionResult GetAllUserAlbums()
        {
            return Ok(db.GetAllUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserAlbumById(string idUser)
        {
            var result = db.GetUserSongsByIdUser(idUser);
            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateUserAlbum([FromBody] UserAlbum user)
        {
            if (user == null)
                return BadRequest();

            db.InsertUsers(user);

            return Created("Created", user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUserAlbum(string id, [FromBody] UserAlbum user)
        {
            if (user == null)
                return BadRequest();

            db.UpdateUsers(user, id);

            return Created("Created", user);
        }
    }
}
