using AutoMapper;
using MyBlog.Core.Entities;
using MyBlog.Web.Models;

namespace MyBlog.Web.ObjectMaps
{
    public class CommentObjectMap : Profile
    {
        public CommentObjectMap()
        {
            CreateMap<CommentViewModel, CommentEntity>();
        }
    }
}