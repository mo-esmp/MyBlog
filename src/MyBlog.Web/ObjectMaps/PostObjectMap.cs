using AutoMapper;
using MyBlog.Core.Entities;
using MyBlog.Web.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Web.ObjectMaps
{
    public class PostObjectMap : Profile
    {
        public PostObjectMap()
        {
            CreateMap<PostViewModel, PostEntity>()
                .ForMember(dest => dest.PostTags, opt => opt.MapFrom(new PostTagResolver()));

            CreateMap<PostEntity, PostViewModel>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src =>
                    string.Join(',', src.PostTags.Select(pt => pt.TagId))));

            CreateMap<PostEntity, PostEditViewModel>()
                .ForMember(dest => dest.Post, opt => opt.MapFrom(src => src))
                /*.ForMember(dest => dest.Tags, opt => opt.ResolveUsing(src =>
                {
                    return src.PostTags.Select(t => new KeyValuePair<int, string>(t.Tag.Id, t.Tag.Name));
                }));*/
                .ForMember(dest => dest.Tags, opt =>
                    opt.MapFrom(src => src.PostTags.Select(t => new KeyValuePair<int, string>(t.Tag.Id, t.Tag.Name))));

            CreateMap<PostEntity, PostSummaryViewModel>();
        }

        private class PostTagResolver : IValueResolver<PostViewModel, PostEntity, ICollection<PostTagEntity>>
        {
            public ICollection<PostTagEntity> Resolve(PostViewModel src, PostEntity dest,
                ICollection<PostTagEntity> destMember,
                ResolutionContext context)
            {
                if (string.IsNullOrEmpty(src.Tags))
                    return null;

                var postTags = src.Tags
                    .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(id => new PostTagEntity {TagId = int.Parse(id), PostId = src.Id});

                return postTags.ToList();
            }
        }
    }
}