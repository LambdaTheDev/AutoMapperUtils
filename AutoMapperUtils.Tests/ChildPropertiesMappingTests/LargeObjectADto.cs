using System.Collections.Generic;

namespace LambdaTheDev.AutoMapperUtils.Tests.ChildPropertiesMappingTests
{
    public class LargeObjectADto
    {
        public int Id { get; set; }
        public List<ModelADto> Models { get; set; } = null!;
    }
}