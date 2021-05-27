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
            // Model -> Dto
            Mapper.CreateMap<User, UserDto>();

            Mapper.CreateMap<Book, BookDto>()
                .ForMember(x => x.AuthorDto, y => y.MapFrom(z => Mapper.Map<Author, AuthorDto>(z.Author)))
                .ForMember(x => x.CategoryTypeDto, y => y.MapFrom(z => Mapper.Map<CategoryType, CategoryTypeDto>(z.CategoryType)));
          
            Mapper.CreateMap<Author, AuthorDto>();

            Mapper.CreateMap<Rental, RentalDto>()
                .ForMember(x => x.BookDto, y => y.MapFrom(z => Mapper.Map<Book, BookDto>(z.Book)))
                .ForMember(x => x.UserDto, y => y.MapFrom(z => Mapper.Map<User, UserDto>(z.User)));
               
            Mapper.CreateMap<CategoryType, CategoryTypeDto>();

       



            // Dto -> Model
            Mapper.CreateMap<UserDto, User>()
                .ForMember(x => x.Id, y => y.Ignore());

            Mapper.CreateMap<BookDto, Book>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.Author, y => y.MapFrom(z => Mapper.Map<AuthorDto, Author>(z.AuthorDto)))
                .ForMember(x => x.CategoryType, y => y.MapFrom(z => Mapper.Map<CategoryTypeDto, CategoryType>(z.CategoryTypeDto)));
            
            Mapper.CreateMap<AuthorDto, Author>()
                 .ForMember(x => x.Id, y => y.Ignore());

            Mapper.CreateMap<RentalDto, Rental>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.Book, y => y.MapFrom(z => Mapper.Map<BookDto, Book>(z.BookDto)))
                .ForMember(x => x.User, y => y.MapFrom(z => Mapper.Map<UserDto, User>(z.UserDto)));
               
            Mapper.CreateMap<CategoryTypeDto, CategoryType>()
                .ForMember(x => x.Id, y => y.Ignore());
        }
    }
}