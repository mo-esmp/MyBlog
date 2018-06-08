using AutoMapper;
using MyBlog.Core.Entities;
using MyBlog.Web.Models;

namespace MyBlog.Web.ObjectMaps
{
    public class ContactMessageObjectMap : Profile
    {
        public ContactMessageObjectMap()
        {
            CreateMap<ContactMessageViewModel, ContactMessageEntity>();
        }
    }
}