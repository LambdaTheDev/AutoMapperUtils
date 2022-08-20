namespace LambdaTheDev.AutoMapperUtils.Tests.MappingOnlyIfNotNullTests
{
    public class TestUserA
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Bio { get; set; } = "";
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public string Secret { get; set; } = "Something";
        public float OtherValue { get; set; } = 325.525234f;
    }
}