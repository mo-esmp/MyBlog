using AutoMapper;
using MyBlog.Core.Entities;
using MyBlog.Web.Areas.Admin.ViewModels;

namespace MyBlog.Web.ObjectMaps
{
    public class PostObjectMap : Profile
    {
        public PostObjectMap()
        {
            CreateMap<PostEntity, PostViewModel>();
            CreateMap<PostViewModel, PostEntity>();
        }
    }
}