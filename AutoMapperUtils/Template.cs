using System;
using System.Linq.Expressions;
using AutoMapper;

namespace LambdaTheDev.AutoMapperUtils
{
    // Just some function templates
    internal static class Template
    {
        public static IMappingExpression<TSource, TDestination> MappingWithDest<TSource, TDestination, TMember>(
            this IMappingExpression<TSource, TDestination> mapper,
            Expression<Func<TDestination, TMember>> destinationMember)
        {
            return mapper;
        }
        
        public static IMappingExpression<TSource, TDestination> SyntaxTests<TSource, TDestination, TMember>(
            this IMappingExpression<TSource, TDestination> mapper,
            Expression<Func<TDestination, TMember>> destinationMember)
        {
            return mapper.ForMember("Abc", opt => opt.MapFrom(""));
        }
    }
}