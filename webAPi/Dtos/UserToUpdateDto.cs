using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPi.Dtos
{
    public class UserToUpdateDto
    {
        public string Introduction { get; set; }
        public string Description { get; set; }
        public string Interests { get; set; }
        public string LookingFor { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

}
