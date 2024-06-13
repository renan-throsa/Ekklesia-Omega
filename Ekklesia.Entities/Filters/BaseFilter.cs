using Ekklesia.Entities.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ekklesia.Entities.Filters
{
    public sealed class BaseFilter<TEntity, TObject> where TEntity : IEntity where TObject : IObject<TEntity>
    {
        private const int DEFAULT_ROWS_PER_PAGE = 10;
        private const string DESC = "DESC";
        private const string ASC = "ASC";
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
                    throw new ArgumentNullException(string.Format("Property {0} not found on object {1}.", filter.Field, typeof(TEntity).Name));
                }
                //May throw ArgumentException
                var predicate = BuildPredicates(filter, property);
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
        private Expression<Func<TEntity, bool>> BuildPredicates(FilterRule rule, PropertyInfo property)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "x");
            Expression propertyAccess = Expression.MakeMemberAccess(parameter, property);
            ConstantExpression argument = BuildConstantExpression(rule, property);

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

        private ConstantExpression BuildConstantExpression(FilterRule rule, PropertyInfo property)
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
            if (FilterBy.Count == 0)
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
                    throw new InvalidOperationException(string.Format("Propiedade de nome {0} n?o econtrado no objeto {1}.", order.Field, typeof(TEntity).Name));
                }

                ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "x");
                Expression propertyAccess = Expression.MakeMemberAccess(parameter, property);
                Expression<Func<TEntity, object>> orderByValue = x => propertyAccess;
                _query = _query.OrderBy(orderByValue);
            }
            return this;
        }

        public FilterResult<TEntity, TObject> Build(Func<IEnumerable<TEntity>, IEnumerable<TObject>> mapper)
        {
            var filterResult = new FilterResult<TEntity, TObject>();
            if (this._query == null) return filterResult;
            var pageInfo = new PageInfo { Page = PageNumber, PerPage = PageSize, Pages = PagesTotal, Total = TotalCount };
            filterResult.PageInfo = pageInfo;
            filterResult.Data = mapper(_query.Skip(SkipSize).Take(PageSize));
            return filterResult;
        }


        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

    }
}
