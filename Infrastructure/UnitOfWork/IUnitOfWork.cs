using Infrastructure.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        public INewsRepository NewsRepository { get; set; }
        public IAuthorRepository AuthorRepository { get; set; }
        Task<int> CompleteAsync();
        void Dispose();
    }
}
