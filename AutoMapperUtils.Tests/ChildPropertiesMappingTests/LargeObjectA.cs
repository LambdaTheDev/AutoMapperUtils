using System.Collections.Generic;

namespace LambdaTheDev.AutoMapperUtils.Tests.ChildPropertiesMappingTests
{
    public class LargeObjectA
    {
        public int Id { get; set; }
        public List<ModelContainerA> ModelEntries { get; set; } = new List<ModelContainerA>();
    }
}