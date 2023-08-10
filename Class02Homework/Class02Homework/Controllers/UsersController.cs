using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Class02Homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet] //http://localhost:[port]/api/users
        public ActionResult<List<string>> GetAllUsers()
        {
            return StatusCode(StatusCodes.Status200OK, StaticDb.UserNames);
            //or we can do that in another shorter way
            //return Ok(StaticDb.UserNames);
        }

        [HttpGet("{userId}")] //http://localhost:[port]/api/users/2
        public ActionResult<string> GetUserById(int userId)
        {
            if(userId < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Invalid UserId! UserId can`t be negative!");
                //or it can be done in a shorter way
                //return BadRequest("Invalid UserId! UserId can`t be negative!");
            }
            
            if(userId >= StaticDb.UserNames.Count)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"There is no user with ID {userId}");
                //or it can be done in a shorter way
                //return NotFound($"There is no user with ID {userId}");
            }

            return StaticDb.UserNames[userId];
        }

    }
}
