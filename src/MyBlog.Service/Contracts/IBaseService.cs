using System.Threading.Tasks;

namespace MyBlog.Service.Contracts
{
    public interface IBaseService
    {
        bool Commit();

        Task<bool> CommitAsync();

        void Rollback();
    }
}