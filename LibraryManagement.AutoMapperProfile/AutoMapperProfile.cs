using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.BLL.Data;
using LibraryManagement.DAL.Data;

namespace LibraryManagement.AutoMapperProfile
{
    public class AutoMapperProfile : Profile 
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDTO>();
        }
    }
}
