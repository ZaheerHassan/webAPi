using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPi.Data;

namespace webAPi.Repositories
{
    public class BaseRepository
    {
        protected readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }
    }
}
