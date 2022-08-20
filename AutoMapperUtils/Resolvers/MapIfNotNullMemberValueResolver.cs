using AutoMapper;

namespace LambdaTheDev.AutoMapperUtils.Resolvers
{
    // This resolver applies source member only if it's not null (reference & value nullables supported!)
    // Simple, but took me 1 day to find out that I should do it this way
    public class MapIfNotNullMemberValueResolver<TSource, TDestination> : IMemberValueResolver<TSource, TDestination, object?, object?>
    {
        public object? Resolve(TSource _, TDestination __, object? srcMember, object? destMember, ResolutionContext ___)
        {
            if (srcMember == null) return destMember;
            return srcMember;
        }
    }
}