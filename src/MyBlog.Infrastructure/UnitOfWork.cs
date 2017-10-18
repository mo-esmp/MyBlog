using MyBlog.Core;
using MyBlog.Infrastructure.Data;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public async ValueTask<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}