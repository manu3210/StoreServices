using AutoMapper;
using StoreServices.Api.Book.Application;
using StoreServices.Api.Book.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreServices.Api.Book.Tests
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<BookMaterial, BookDto>();
        }
    }
}
