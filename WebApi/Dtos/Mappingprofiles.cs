﻿using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
     public class Mappingprofiles : Profile
    {
        public Mappingprofiles()
        {
            CreateMap<Product, ProductDto>();
        }

    }
}
