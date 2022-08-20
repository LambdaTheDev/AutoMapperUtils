using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace LambdaTheDev.AutoMapperUtils.Utils
{
    // Utility methods for Type class
    public static class TypeUtils
    {
        // Returns mutual property names for two types
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetMutualProperties(Type a, Type b, List<string> buffer)
        {
            GetMutualProperties(a, b, buffer, out _, out _);
        }
        
        // Returns mutual property names for two types
        public static void GetMutualProperties(Type a, Type b, List<string> buffer, out PropertyInfo[] aProperties, out PropertyInfo[] bProperties)
        {
            // Get properties
            buffer.Clear();
            aProperties = a.GetProperties();
            bProperties = b.GetProperties();
            
            // Loop for expected props
            foreach (var aProp in aProperties)
            {
                foreach (var bProp in bProperties)
                {
                    if (bProp.Name == aProp.Name)
                    {
                        buffer.Add(aProp.Name);
                        break;
                    }
                }
            }
        }
    }
}