using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly string _filePath = "users.txt";

        // GET api/Users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!System.IO.File.Exists(_filePath))
                return NotFound();

            foreach (string line in System.IO.File.ReadLines(_filePath))
            {
                User? user = JsonSerializer.Deserialize<User>(line);
                if (user != null && user.UserId == id)
                    return Ok(user);
            }
            return NotFound();
        }

        // POST api/Users
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            int numberOfUsers = System.IO.File.Exists(_filePath)
                ? System.IO.File.ReadLines(_filePath).Count()
                : 0;

            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(_filePath, userJson + Environment.NewLine);

            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
        }

        // POST api/Users/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogIn loginUser)
        {
            if (!System.IO.File.Exists(_filePath))
                return Unauthorized();

            foreach (string line in System.IO.File.ReadLines(_filePath))
            {
                User? user = JsonSerializer.Deserialize<User>(line);
                if (user != null && user.Email == loginUser.Email && user.Password == loginUser.Password)
                    return Ok(user);
            }
            return Unauthorized();
        }

        // PUT api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User updatedUser)
        {
            if (!System.IO.File.Exists(_filePath))
                return NotFound();

            List<string> lines = System.IO.File.ReadAllLines(_filePath).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                User? current = JsonSerializer.Deserialize<User>(lines[i]);
                if (current != null && current.UserId == id)
                {
                    updatedUser.UserId = id;
                    lines[i] = JsonSerializer.Serialize(updatedUser);
                    System.IO.File.WriteAllLines(_filePath, lines);
                    return Ok(updatedUser);
                }
            }
            return NotFound();
        }

        // DELETE api/Users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}