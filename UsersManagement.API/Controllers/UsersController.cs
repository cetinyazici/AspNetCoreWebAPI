using Microsoft.AspNetCore.Mvc;
using UsersManagement.API.Fake;
using UsersManagement.API.Model;

namespace UsersManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private List<User> _users = FakeData.GetUsers(100);

        [HttpGet]
        public List<User> GetAllUsers()
        {
            return _users;
        }

        [HttpGet("{id}")]
        public User GetUserById(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        [HttpPost]
        public User CreateUser([FromBody] User user)
        {
            _users.Add(user);
            return user;
        }

        [HttpPut]
        public User UpdateUser([FromBody] User user)
        {
            var editedUser = _users.FirstOrDefault(user => user.Id == user.Id);
            editedUser.FirstName = user.FirstName;
            editedUser.LastName = user.LastName;
            editedUser.Address = user.Address;
            return user;
        }

        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            var deletedUser = _users.FirstOrDefault(u => u.Id == id);
            _users.Remove(deletedUser);
        }
    }
}
