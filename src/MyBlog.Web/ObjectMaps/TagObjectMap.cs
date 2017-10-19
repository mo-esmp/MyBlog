using AutoMapper;
using MyBlog.Core.Entities;
using MyBlog.Web.Areas.Admin.ViewModels;

namespace MyBlog.Web.ObjectMaps
{
    public class TagObjectMap : Profile
    {
        public TagObjectMap()
        {
            CreateMap<TagEntity, TagViewModel>();
            CreateMap<TagViewModel, TagEntity>();
        }
    }
}