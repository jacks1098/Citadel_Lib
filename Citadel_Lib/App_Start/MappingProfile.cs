using AutoMapper;
using Citadel_Lib.Dto;
using Citadel_Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citadel_Lib.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<User, UserDto>();
            Mapper.CreateMap<Book, BookDto>();
            Mapper.CreateMap<Author, AuthorDto>();
            Mapper.CreateMap<Rental, RentalDto>();
            Mapper.CreateMap<CategoryType, CategoryTypeDto>();

            Mapper.CreateMap<UserDto, User>()
                .ForMember(x => x.Id, y => y.Ignore());
            Mapper.CreateMap<BookDto, Book>()
                .ForMember(x => x.Id, y => y.Ignore());
            Mapper.CreateMap<AuthorDto, Author>()
                 .ForMember(x => x.Id, y => y.Ignore());
            Mapper.CreateMap<RentalDto, Rental>()
                .ForMember(x => x.Id, y => y.Ignore());
            Mapper.CreateMap<CategoryTypeDto, CategoryType>()
                .ForMember(x => x.Id, y => y.Ignore());
        }
    }
}