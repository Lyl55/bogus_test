using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using bogus_test.Entity;

namespace bogus_test.Fake
{
    public static class FakeData
    {
        private static List<User> _users;

        public static List<User> GetUsers()
        {
            _users = new Faker<User>().RuleFor(u=>u.Id,f=>f.IndexFaker).
                RuleFor(u=>u.Name,f=>f.Name.FirstName()).
                RuleFor(u=>u.Surname,f=>f.Name.LastName()).
                RuleFor(u=>u.Address,f=>f.Address.FullAddress()).
                Generate(100);
            return _users;
        }
    }
}
