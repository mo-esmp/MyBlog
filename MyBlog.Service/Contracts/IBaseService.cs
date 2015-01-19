namespace MyBlog.Service.Contracts
{
    public interface IBaseService
    {
        bool Commit();

        void Rollback();
    }
}