using AutoMapper;
using BookStore.Application.Features.Books;
using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookListVm>().ReverseMap();
        }

    }
}
