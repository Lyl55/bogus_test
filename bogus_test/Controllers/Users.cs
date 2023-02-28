using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bogus_test.Entity;
using bogus_test.Fake;
using Microsoft.AspNetCore.Mvc;

namespace bogus_test.Controllers
{
    [Route("api/[controller]")]
    public class Users : ControllerBase
    {
        private List<User> _users = FakeData.GetUsers();

        [HttpGet]
        public List<User> Get()
        {
            return _users;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _users.FirstOrDefault(x=>x.Id==id);
        }

        [HttpPost]
        public User Post([FromBody] User user)
        {
            _users.Add(user);
            return user;
        }

        [HttpPut]
        public User Put([FromBody] User user)
        {
            var editedUser = _users.FirstOrDefault(x => x.Id == user.Id);
            editedUser.Name = user.Name;
            editedUser.Surname = user.Surname;
            editedUser.Address = user.Address;
            return user;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var deletedUser = _users.FirstOrDefault(x => x.Id == id);
            _users.Remove(deletedUser);
        }
    }
}
