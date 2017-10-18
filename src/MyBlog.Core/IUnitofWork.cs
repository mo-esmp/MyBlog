using System.Threading.Tasks;

namespace MyBlog.Core
{
    public interface IUnitOfWork
    {
        ValueTask<int> CommitAsync();
    }
}