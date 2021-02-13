using Core.DataAccess.EntityFrameWork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {
        public List<RentDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                var result = from re in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars
                            on re.CarId equals c.Id
                             join cu in context.Customers
                             on re.CustomerId equals cu.CustomerId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join u in context.Users
                             on cu.UserId equals u.UserId
                             select new RentDetailDto
                             {
                                 RentalId = re.Id,
                                 CarName = b.BrandName,
                                 CustomerName = cu.CompanyName,
                                 UserName = u.FirstName + " " + u.LastName,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
