using AutoMapper;
using bookStore.Domain.Models;
using bookStoreApi.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace bookStoreApi.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Book, BookReadDto>();
            //CreateMap<BookCreateDto, Book>().ForCtorParam(i => i.Image,(src => Convert.FromBase64String(src.Image)));

            CreateMap<BookCreateDto, Book>().ForMember(i=>i.Image,
                opt => opt.MapFrom(src => Convert.FromBase64String(src.Image)));

            CreateMap<BookUpdateDto, Book>().ForMember(i => i.Image,
                opt => opt.MapFrom(src => Convert.FromBase64String(src.Image)));

            CreateMap<Author, AuthorReadDto>();
            CreateMap<AuthorCreateDto, Author>().ForMember(i => i.Image,
                opt => opt.MapFrom(src => Convert.FromBase64String(src.Image)));

            CreateMap<Printing, PrintingReadDto>();
            CreateMap<PrintingCreateDto, Printing>();
        }
    }
}
