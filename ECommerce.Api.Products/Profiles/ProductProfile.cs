using System.Data.Common;
using System;

namespace ECommerce.Api.Products.Profiles
{
    public class ProductProfile : AutoMapper.Profile
    {
        public ProductProfile()
        {
            CreateMap<Data.Product, Models.Product>();
        }
    }
}