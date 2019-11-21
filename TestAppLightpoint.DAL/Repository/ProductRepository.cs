using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TestAppLightpoint.DAL.EF;
using TestAppLightpoint.DAL.Entities;
using TestAppLightpoint.DAL.Interface;

namespace TestAppLightpoint.DAL.Repository
{
    public class ProductRepository : CommonRepository<Product>
    {
        public ProductRepository(IUnitOfWork uow) : base(uow)
        {
        }

    }
}
