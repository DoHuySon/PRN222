﻿using FUNewsManageSystem.Models.Account;
using FUNewsManageSystem.Models.Category;
using FUNewsManageSystem.Models.NewsArticle;
using ServiceLayer.Enums;
using ServiceLayer.Models;

namespace FUNewsManageSystem.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region =========== System Account Mapping ===========

            CreateMap<SystemAccount, AccountDTO>()
                .ForMember(
                    dest => dest.AccountRole,
                    opt =>
                        opt.MapFrom(src =>
                            src.AccountRole == 1 ? AccountRole.Staff
                            : src.AccountRole == 2 ? AccountRole.Lecturer
                            : AccountRole.Admin
                        )
                )
                .ReverseMap();

            CreateMap<AccountDTO, ViewAccountViewModel>().ReverseMap();
            CreateMap<AccountDTO, AddNewAccountViewModel>().ReverseMap();
            CreateMap<AccountDTO, UpdateAccountViewModel>().ReverseMap();
            CreateMap<AccountDTO, UpdateProfileViewModel>()
                .ForMember(x => x.ConfirmPassword, opt => opt.MapFrom(a => a.AccountPassword))
                .ReverseMap();
            #endregion

            #region =========== Category Mapping ===========
            CreateMap<CategoryDTO, CategoryViewModel>()
                .ForMember(
                    dest => dest.NewsArticleCount,
                    opt => opt.MapFrom(src => src.NewsArticles.Count)
                );
            CreateMap<Category, CategoryDTO>()
                .ForMember(
                    dest => dest.CategoryStatus,
                    opt =>
                        opt.MapFrom(src =>
                            src.IsActive == true ? CategoryStatus.Active : CategoryStatus.Inactive
                        )
                );
            CreateMap<CategoryDTO, Category>()
                .ForMember(
                    x => x.IsActive,
                    opt =>
                        opt.MapFrom(a => a.CategoryStatus == CategoryStatus.Active ? true : false)
                );
            CreateMap<CategoryDTO, AddNewCategoryViewModel>().ReverseMap();
            CreateMap<CategoryDTO, UpdateCategoryViewModel>().ReverseMap();
            CreateMap<CategoryDTO, ParentCategoryViewModel>().ReverseMap();

            #endregion

            #region =========== News Article Mapping ===========
            CreateMap<NewsArticle, NewsArticleDTO>()
                .ForMember(
                    dest => dest.NewsStatus,
                    opt =>
                        opt.MapFrom(src =>
                            src.NewsStatus == true ? NewsStatus.Active : NewsStatus.Inactive
                        )
                )
                .ForMember(
                    dest => dest.TagIds,
                    opt => opt.MapFrom(src => src.Tags.Select(x => x.TagId))
                )
                .ReverseMap();
            CreateMap<NewsArticleDTO, NewsArticle>()
                .ForMember(
                    dest => dest.NewsStatus,
                    opt => opt.MapFrom(src => src.NewsStatus == NewsStatus.Active)
                );
            CreateMap<NewsArticleDTO, NewsArticleViewModel>().ReverseMap();
            CreateMap<NewsArticleDTO, ViewNewsArticleViewModel>()
                .ForMember(
                    n => n.CategoryName,
                    opt => opt.MapFrom(src => src.Category.CategoryName)
                )
                .ForMember(
                    n => n.CreatedByName,
                    opt => opt.MapFrom(src => src.CreatedBy.AccountName)
                )
                .ForMember(
                    n => n.UpdatedByName,
                    opt => opt.MapFrom(src => src.UpdatedBy.AccountName)
                )
                .ForMember(n => n.ModifiedDate, opt => opt.MapFrom(src => src.ModifiedDate));
            CreateMap<NewsArticleDTO, AddNewsArticleViewModel>().ReverseMap();
            CreateMap<NewsArticleDTO, UpdateNewsArticleViewModel>()
                .ForMember(
                    n => n.CreatedByName,
                    opt => opt.MapFrom(src => src.CreatedBy.AccountName)
                )
                .ForMember(
                    n => n.UpdatedByName,
                    opt => opt.MapFrom(src => src.UpdatedBy.AccountName)
                )
                .ReverseMap();

            #endregion

            #region =========== Tag Mapping ===========
            CreateMap<TagDTO, Tag>().ReverseMap();

            #endregion
        }
    }
}
