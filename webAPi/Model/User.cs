using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPi.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}
