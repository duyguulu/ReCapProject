using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDbContext> , ICarDal
	{
		public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
		{
			using (ReCapDbContext context = new ReCapDbContext())
			{
				var result = from c in context.Cars
							 join co in context.Colors
							 on c.ColorId equals co.ColorId
							 join b in context.Brands
							 on c.BrandId equals b.BrandId
							 select new CarDetailDto
							 //{
							 // CarId = c.Id,
							 // CarName = c.CarName,
							 // BrandName = b.BrandName,
							 // ColorName = co.ColorName,
							 // DailyPrice = c.DailyPrice,
							 // BrandId= b.BrandId,
							 // ColorId= co.ColorId
							 //};
							 {
								 CarId = c.Id,
								 BrandId = c.BrandId,
								 ColorId = c.ColorId,
								 CarName = c.CarName,
								 BrandName = b.BrandName,
								 ColorName = co.ColorName,
								 ModelYear = c.ModelYear,
								 DailyPrice = c.DailyPrice,
								 Descriptions = c.Descriptions,
								 CarImage = (from i in context.CarImages
											 where (c.Id == i.CarId)
											 select new CarImage { CarImageId = i.CarImageId, CarId = c.Id, DateT = i.DateT, ImagePath = i.ImagePath }).ToList()
							 };

				return filter == null ? result.ToList() : result.Where(filter).ToList();
			}
		}
		//public List<CarDetailDto> GetCarsByBrandId(int brandId)
		//{
		//	return this.GetCarDetails().FindAll(car => car.BrandId == brandId);
		//}

		//public List<CarDetailDto> GetCarsByColorId(int colorId)
		//{
		//	return this.GetCarDetails().FindAll(car => car.ColorId == colorId);

		//}


	}
}
