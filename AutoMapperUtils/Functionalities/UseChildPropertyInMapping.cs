using System;
using System.Linq.Expressions;
using AutoMapper;
using LambdaTheDev.AutoMapperUtils.Extensions;

namespace LambdaTheDev.AutoMapperUtils.Functionalities
{
    // This functionality is useful when you are trying to map a single property values into DTO
    public static class UseChildPropertyInMapping
    {
        public static IMappingExpression<TSource, TDestination> MapSourceMemberProperty<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mapper,
            Expression<Func<TSource, object?>> property)
        {
            throw new NotImplementedException();
            
            // First ignore all source properties
            Type sourceType = typeof(TSource);
            foreach (var srcProperty in sourceType.GetProperties())
                mapper.DoNotValidateSrcMember(srcProperty.Name);
            
            // Then include members from property & return
            return mapper.IncludeMembers(property);
        }
    }
}