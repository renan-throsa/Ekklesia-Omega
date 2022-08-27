using Ekklesia.Entities.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Ekklesia.Entities.Filters
{
    public class BaseFilter<TEntity, TObject> where TEntity : IEntity where TObject : IObject<TEntity>
    {
        private const int DEFAULT_ROWS_PER_PAGE = 10;
        private const string PT_BR = "pt-BR";
        private IQueryable<TEntity>? _query;

        public List<OrderRule> OrderBy { get; set; }
        public List<FilterRule> FilterBy { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        private int TotalCount { get; set; }
        private int PagesTotal { get; set; }
        private int SkipSize { get; set; }


        public BaseFilter(int pageNumber = 1, int pageSize = DEFAULT_ROWS_PER_PAGE)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            FilterBy = new List<FilterRule>();
            OrderBy = new List<OrderRule>();
        }


        public BaseFilter<TEntity, TObject> OnQuery(IQueryable<TEntity> query)
        {
            _query = query;
            return this;
        }

        public BaseFilter<TEntity, TObject> WithFiltering()
        {
            if (this._query == null || FilterBy.Count == 0) return this;

            PropertyInfo[] properties = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            if (!properties.Any()) return this;

            foreach (var filter in FilterBy)
            {
                var property = properties.FirstOrDefault(p => p.Name.ToLower().Equals(filter.Field.ToLower()));
                if (property == null)
                {
                    throw new InvalidOperationException(string.Format("Property {0} not found on object {1}.", filter.Field, typeof(TEntity).Name));
                }
                //May throw ArgumentException
                var predicate = BuildBinaryExpression(filter, property);
                _query = _query.Where(predicate);

            }
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rule"></param>
        /// <param name="property"></param>
        /// <returns>Set of conditions that resolve to true or false.</returns>
        /// <exception cref="ArgumentException"></exception>
        private Expression<Func<TEntity, bool>> BuildBinaryExpression(FilterRule rule, PropertyInfo property)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "x");
            Expression propertyAccess = Expression.MakeMemberAccess(parameter, property);
            ConstantExpression argument = BuildConstant(rule, property);

            Expression expr = (rule.Type) switch
            {
                FilterType.Equal => Expression.Equal(propertyAccess, argument),
                FilterType.GreaterThan => Expression.GreaterThan(propertyAccess, argument),
                FilterType.GreaterThanOrEqual => Expression.GreaterThanOrEqual(propertyAccess, argument),
                FilterType.LessThan => Expression.LessThan(propertyAccess, argument),
                FilterType.LessThanOrEqual => Expression.LessThanOrEqual(propertyAccess, argument),
                FilterType.NotEqual => Expression.NotEqual(propertyAccess, argument),
                FilterType.Like => Expression.Call(propertyAccess, typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) })!, argument),
                _ => throw new ArgumentException("Invalid string value for command"),
            };

            return Expression.Lambda<Func<TEntity, bool>>(expr, parameter);
        }

        private Expression<Func<TEntity, object>> BuildUnaryExpression(PropertyInfo property)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "x"); // (x) =>
            Expression propertyAccess = Expression.MakeMemberAccess(parameter, property); // => x.property              
            UnaryExpression unaryExpression = Expression.Convert(propertyAccess, typeof(object));
            Expression<Func<TEntity, object>> predicate = Expression.Lambda<Func<TEntity, object>>(unaryExpression, parameter); // (x) => x.property
            return predicate;
        }

        private ConstantExpression BuildConstant(FilterRule rule, PropertyInfo property)
        {
            if (property.PropertyType == typeof(String))
            {
                return Expression.Constant(rule.Arg);
            }
            if (property.PropertyType.IsEnum)
            {
                return Expression.Constant(Enum.Parse(property.PropertyType, rule.Arg));
            }
            if (property.PropertyType == typeof(ObjectId))
            {
                return Expression.Constant(ObjectId.Parse(rule.Arg));
            }
            if (property.PropertyType == typeof(DateTime))
            {
                var date = Convert.ToDateTime(rule.Arg, new CultureInfo(PT_BR));
                return Expression.Constant(date);
            }
            if (property.PropertyType == typeof(int) || property.PropertyType == typeof(float))
            {
                var r = float.Parse(rule.Arg);
                return Expression.Constant(float.Parse(rule.Arg));
            }

            return Expression.Constant(rule.Arg);
        }

        public BaseFilter<TEntity, TObject> WithPagination()
        {
            if (this._query == null) return this;
            TotalCount = _query.Count();
            PagesTotal = (int)Math.Ceiling((double)TotalCount / (double)PageSize);
            SkipSize = (PageNumber - 1) * PageSize;
            return this;
        }

        public BaseFilter<TEntity, TObject> WithSorting()
        {
            if (this._query == null) return this;
            if (OrderBy.Count == 0)
            {
                this._query.OrderBy(x => x.Id);
                return this;
            }

            PropertyInfo[] properties = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            if (!properties.Any()) return this;


            foreach (var order in OrderBy)
            {
                PropertyInfo? property = properties.FirstOrDefault(p => p.Name.ToLower().Equals(order.Field.ToLower()));
                if (property == null)
                {
                    throw new InvalidOperationException(string.Format("Property {0} not found on object {1}.", order.Field, typeof(TEntity).Name));
                }

                Expression<Func<TEntity, object>> predicate = BuildUnaryExpression(property);

                if (order.Direction == OrderType.Ascending)
                {
                    _query = _query.OrderBy(predicate);
                }
                else
                {
                    _query = _query.OrderByDescending(predicate);
                }
            }
            return this;
        }

        public FilterResult<TEntity, TObject> Build(Func<IEnumerable<TEntity>, IEnumerable<TObject>> mapper)
        {
            if (this._query == null) new FilterResult<TEntity, TObject>();
            var filterResult = new FilterResult<TEntity, TObject>()
            {
                Data = mapper(_query.Skip(SkipSize).Take(PageSize)),
                Page = PageNumber,
                PerPage = PageSize,
                Pages = PagesTotal,
                Total = TotalCount
            };

            return filterResult;
        }

        public virtual object Clone()
        {
            return MemberwiseClone();
        }



    }
}
