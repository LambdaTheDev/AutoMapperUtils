using System;
using System.Linq.Expressions;
using System.Reflection;

namespace LambdaTheDev.AutoMapperUtils.Utils
{
    // Utility method for Expressions
    public static class ExpressionUtils
    {
        // Returns prop name for Expression, for example for x => x.User it returns User
        public static PropertyInfo GetExpressionPropertyInfo<TType, TProperty>(Expression<Func<TType, TProperty>> expr)
        {
            MemberExpression? member = expr.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException("method");

            PropertyInfo? propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException("field");
            
            return propInfo;
        }
    }
}