using MediatR;
using System;

namespace MyBlog.Core.Commands
{
    public class PostAddCommand : IRequest
    {
        public Type Post { get; set; }
    }
}