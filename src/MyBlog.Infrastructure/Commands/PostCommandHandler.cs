using MediatR;
using MyBlog.Core.Commands;
using MyBlog.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Commands
{
    public class PostCommandHandler : IAsyncRequestHandler<PostAddCommand>
    {
        private readonly DataContext _context;

        public PostCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task Handle(PostAddCommand message)
        {
            throw new NotImplementedException();
        }
    }
}