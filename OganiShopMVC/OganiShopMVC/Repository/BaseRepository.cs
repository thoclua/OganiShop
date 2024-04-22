using Microsoft.EntityFrameworkCore;
using OganiShopMVC.Data;
using OganiShopMVC.DataTransferObject;
using OganiShopMVC.Models;
using System.Linq.Expressions;

namespace OganiShopMVC.Repository
{
	public interface IBaseRepository<T> where T : Base
	{
		DataTablesResponseDTO<T> BuildResponseForDataTableLibrary(Expression<Func<T, bool>> filter, string columName = "id", bool columASC = false, int start = 1, int draw = 0, int length = 10, string includeProperty = "");

		ViewDTO<T> GetAll();
		ViewDTO<T> GetById(int Id);
		ViewDTO<T> Save(int Id, T entity);
		ViewDTO<T> Delete(int Id);
	}
	public class BaseRepository<T> : IBaseRepository<T> where T : Base
	{
		protected ApplicationDbContext _db;
		protected DbSet<T> _dbset;

		public BaseRepository(ApplicationDbContext context)                                         //ctor -> contructor
		{
			_db = context;
			_dbset = context.Set<T>();
		}

		public virtual DataTablesResponseDTO<T> BuildResponseForDataTableLibrary(Expression<Func<T, bool>> filter, string columName = "id", bool columASC = false, int start = 1, int draw = 0, int length = 10, string includeProperty = "")
		{
			var result = new DataTablesResponseDTO<T>();

			var dataRows = _dbset.AsQueryable();
			if (!string.IsNullOrEmpty(includeProperty))
			{
				dataRows = _dbset.Include(includeProperty).AsQueryable();
			}
			if (filter != null)
			{
				dataRows = dataRows.Where(filter);
			}
			var totalRows = dataRows.Count();
			dataRows = dataRows.Skip(start).Take(length);
			var propertyInfo = typeof(T).GetProperty(columName);
			var parameter = Expression.Parameter(typeof(T), "p");
			var property = Expression.Property(parameter, propertyInfo);
			var lambda = Expression.Lambda<Func<T, object>>(Expression.Convert(property, typeof(object)), parameter);
			if (columASC == false)
			{
				dataRows = dataRows.OrderByDescending(lambda);
			}
			else
			{
				dataRows = dataRows.OrderBy(lambda);
			}
			result.data = dataRows.ToList();
			result.recordsTotal = totalRows;
			result.recordsFiltered = totalRows;
			result.draw = draw;
			return result;
		}

		public ViewDTO<T> Delete(int Id)
		{
			var result = new ViewDTO<T>();
			if (Id > 0)
			{
				var deleted = _dbset.Find(Id);
				if (deleted != null)
				{
					_dbset.Remove(deleted);
					_db.SaveChanges();
					result.Message = "Xóa dữ liệu thành công!";
					result.StatusCode = 200;
				}
			}
			return result;
		}

		public ViewDTO<T> GetAll()
		{
			var result = new ViewDTO<T>();
			result.DataRows = _dbset.AsQueryable().ToList();
			return result;
		}

		public ViewDTO<T> GetById(int Id)
		{

			var result = new ViewDTO<T>();
			var dataItem = _dbset.Find(Id);

			if (dataItem != null)
			{
				result.DataRows.Add(dataItem);
				result.StatusCode = 200;
				result.Message = "Tìm kiếm theo Id thành công!";
			}

			return result;
		}

		public ViewDTO<T> Save(int Id  , T entity)
		{
			var result = new ViewDTO<T>();
			if (Id == 0)
			{
                
                _dbset.Add(entity);
				_db.SaveChanges();
				result.StatusCode = 200;
				result.Message = "Thêm mới thành công!";
			}
			else if (Id > 0)
			{
				_dbset.Update(entity);
				_db.SaveChanges();
				result.StatusCode = 200;
				result.Message = "Cập nhật thành công!";
			}

			return result;
		}
	}
}
