using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContent _context;

        public PostRepository(ApplicationDbContext context){
          _context = context;
        }
    }
}