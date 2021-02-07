using Core.DataAccess.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
      
            public List<CarDetailDto> GetCarDetailDtos()
        {
            using (CarContext context = new CarContext())
            {
                var result = from p in context.Cars
                            join c in context.Colors
                            on p.ColorId equals c.ColorId
                            join d in context.Brands
                            on p.BrandId equals d.BrandId
                            select new CarDetailDto
                            {
                                BrandName = d.BrandName,
                                ColorName = c.ColorName,
                                DailPrice = p.DailyPrice,
                                
                            };
                return result.ToList();
            }
        }

      
    }
}
