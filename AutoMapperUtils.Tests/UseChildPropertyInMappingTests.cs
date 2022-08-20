using System;
using AutoMapper;
using LambdaTheDev.AutoMapperUtils.Functionalities;
using NUnit.Framework;

namespace LambdaTheDev.AutoMapperUtils.Tests
{
    [TestFixture]
    public partial class UseChildPropertyInMappingTests
    {
        private static readonly MapperConfiguration MapperCfg = new MapperConfiguration(mapper =>
        {
            mapper.AddProfile<TestProfile>();
        });


        [Test]
        public void BasicTest()
        {
            // Prepare data
            ModelContainer container = new ModelContainer
            {
                Id = 9123,
                MutualFloat = 1.234f,
                Model = new Model { Id = 7321, MutualFloat = 4.321f, Something = "Cool thing", Secret = "Where are you looking at?" }
            };
            
            // Map to model DTO
            ModelDto mapped = MapperCfg.CreateMapper().Map<ModelContainer, ModelDto>(container);
            
            // Asset that data are valid
            Assert.That(mapped.Id == 7321);
            Assert.That(mapped.MutualFloat == 4.321f);
            Assert.That(mapped.Something == "Cool thing");
        }

        [Test]
        public void CheckIfItIsNotHeavy()
        {
            int heavyMethodInvokeTimes = 0;
            
            // Some test data
            ModelContainer container = new ModelContainer
            {
                Id = 9123,
                MutualFloat = 1.234f,
                Model = new Model
                    { Id = 7321, MutualFloat = 4.321f, Something = "Cool thing", Secret = "Where are you looking at?" }
            };
            
            // Sub to callback
            UseChildPropertyInMapping.Callback += () => heavyMethodInvokeTimes++;
            
            // Perform mappings
            IMapper mapper = MapperCfg.CreateMapper();
            mapper.Map<ModelContainer, ModelDto>(container);
            mapper.Map<ModelContainer, ModelDto>(container);
            mapper.Map<ModelContainer, ModelDto>(container);
            mapper.Map<ModelContainer, ModelDto>(container);
            
            Assert.That(heavyMethodInvokeTimes < 2);
            Console.WriteLine(heavyMethodInvokeTimes);
        }
    }
}