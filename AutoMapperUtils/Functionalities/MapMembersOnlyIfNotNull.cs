using System;
using AutoMapper;
using LambdaTheDev.AutoMapperUtils.Resolvers;

namespace LambdaTheDev.AutoMapperUtils.Functionalities
{
    // This is used by me in Update-like DTOs -> All properties that can be updated are nullable, and
    //  mapping updates only those fields which aren't null (nullable value types also supported!)
    public static class MapMembersOnlyIfNotNull
    {
        // Raw method used to apply this functionality on a single property
        public static IMappingExpression<TSource, TDestination> MapMemberIfNotNull<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mapper,
            string destinationMember,
            string? sourceMember = null)
        {
            // Check if source type contains suitable property
            Type sourceType = typeof(TSource);
            if (sourceMember == null) sourceMember = destinationMember;
            if (sourceType.GetProperty(sourceMember) == null) return mapper;

            // Perform mapping using custom resolver
            return mapper.ForMember(destinationMember, opt => 
                opt.MapFrom<MapIfNotNullMemberValueResolver<TSource, TDestination>, object?>(sourceMember));
        }
        
        // This method applies this functionality on entire model
        // It literally iterates through all source properties & applies method above
        // Note: If someone has a better name for this method, inform me
        public static IMappingExpression<TSource, TDestination> CreateMappingsOnlyIfNotNull<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mapper)
        {
            foreach (var property in typeof(TDestination).GetProperties())
                mapper.MapMemberIfNotNull(property.Name);

            return mapper;
        }
    }
}