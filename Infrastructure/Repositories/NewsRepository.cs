using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class NewsRepository:GenericRepository<News>,INewsRepository
    {
        private readonly DataContext _context;

        public NewsRepository(DataContext context) : base(context)
        {
            _context = context;
        }
     
    }
}
