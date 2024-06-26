﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.DataAccessLayer.Abstract;
using Travela.DataAccessLayer.Context;
using Travela.DataAccessLayer.Repositories;
using Travela.EntityLayer.Concrete;

namespace Travela.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(TravelaContext ctx) : base(ctx) //buradaki base(ctx) işareti sayesinde nesne newlememin önüne geçiyor.
        {
            
        }

        public int GetCategoryCount()
        {
            var context = new TravelaContext();
            var value = context.Categories.Count();
            return value;
        }
    }
}
