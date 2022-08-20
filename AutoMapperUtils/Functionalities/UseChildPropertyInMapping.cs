using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using AutoMapper;
using LambdaTheDev.AutoMapperUtils.Utils;

namespace LambdaTheDev.AutoMapperUtils.Functionalities
{
    // This functionality is useful when you are trying to map a single property values into DTO
    public static class UseChildPropertyInMapping
    {
        // An event used only for internal testing purposes
        internal static event Action? Callback;
        
        
        public static IMappingExpression<TSource, TDestination> MapSourceMemberProperty<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mapper,
            Expression<Func<TSource, object?>> property)
        {
            // Prepare data about involved types
            PropertyInfo expressionPropertyInfo = ExpressionUtils.GetExpressionPropertyInfo(property);
            Type sourceType = typeof(TSource);
            Type childType = expressionPropertyInfo.PropertyType;
            
            // Get mutual properties to a list
            List<string> mutualProperties = new List<string>(4);
            TypeUtils.GetMutualProperties(sourceType, childType, mutualProperties);

            // Include all property members
            mapper.IncludeMembers(property);
            
            // Now change ForMembers to use new instead of old ones
            foreach (var mutualProperty in mutualProperties)
            {
                mapper.ForMember(mutualProperty, opt => 
                    opt.MapFrom(expressionPropertyInfo.Name + "." + mutualProperty));
            }

            // Invoke test event & return mapper
            Callback?.Invoke();
            return mapper;
        }
    }
}