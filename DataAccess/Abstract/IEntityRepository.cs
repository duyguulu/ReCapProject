using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
	public interface IEntityRepository<T> where T:class, IEntity
	{
		List<T> GetAll(Expression<Func<T, bool>> filter = null); //bu kısmı neden böyle yazdığımızı anlayamadım? T,bool?
		T Get(Expression<Func<T, bool>> filter = null);
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}
