using System;
using System.Linq.Expressions;
using AutoMapper;

namespace LambdaTheDev.AutoMapperUtils.Extensions
{
    // Quicker implementations for ignoring AutoMapper members
    public static class IgnoreExtensionMethods
    {
        public static IMappingExpression<TSource, TDestination> IgnoreMember<TSource, TDestination, TMember>(
            this IMappingExpression<TSource, TDestination> mapper,
            Expression<Func<TDestination, TMember>> ignoredMember)
        {
            return mapper.ForMember(ignoredMember, opt => opt.Ignore());
        }

        public static IMappingExpression<TSource, TDestination> IgnoreMember<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mapper, string ignoredMemberName)
        {
            return mapper.ForMember(ignoredMemberName, opt => opt.Ignore());
        }

        public static IMappingExpression<TSource, TDestination> DoNotValidateSrcMember<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mapper,
            Expression<Func<TSource, object?>> ignoredMember)
        {
            return mapper.ForSourceMember(ignoredMember, x => x.DoNotValidate());
        }
        
        public static IMappingExpression<TSource, TDestination> DoNotValidateSrcMember<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mapper, string ignoredSrcMemberName)
        {
            return mapper.ForSourceMember(ignoredSrcMemberName, opt => opt.DoNotValidate());
        }
    }
}