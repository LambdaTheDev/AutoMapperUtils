using System;
using System.Linq.Expressions;
using AutoMapper;

namespace LambdaTheDev.AutoMapperUtils.Extensions
{
    public static class MapFromExtensions
    {
        // Just a QOL wrapper method
        public static IMappingExpression<TSource, TDestination> MapFrom<TSource, TDestination, TSourceMember, TMember>(
            this IMappingExpression<TSource, TDestination> mapper,
            Expression<Func<TDestination, TMember>> destination,
            Expression<Func<TSource, TSourceMember>> source)
        {
            return mapper.ForMember(destination, opt => opt.MapFrom(source));
        }
    }
}