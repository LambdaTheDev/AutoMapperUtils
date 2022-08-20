using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using AutoMapper;
using LambdaTheDev.AutoMapperUtils.Functionalities;
using NUnit.Framework;

namespace LambdaTheDev.AutoMapperUtils.Tests.ChildPropertiesMappingTests
{
    [TestFixture]
    public class ChildPropertiesMappingTest
    {
        private static readonly MapperConfiguration MapperCfg = new MapperConfiguration(mapper =>
        {
            mapper.AddProfile<TestProfile>();
        });


        [Test]
        public void BasicTest()
        {
            // Prepare test data
            LargeObjectA largeObj = new LargeObjectA
            {
                Id = 31234,
                ModelEntries = new List<ModelContainerA>
                {
                    new ModelContainerA
                    {
                        Id = 91234,
                        Model = new ModelA { Id = 7123, Info = "Test1", Something = 3f, Secret = "pass123" }
                    },
                    new ModelContainerA
                    {
                        Id = 91235,
                        Model = new ModelA { Id = 7124, Info = "Test2", Something = 7f, Secret = "pass456" }
                    }
                }
            };
            
            // Mapping
            LargeObjectADto mapped = MapperCfg.CreateMapper().Map<LargeObjectA, LargeObjectADto>(largeObj);
            
            // Validate
            ModelADto first = mapped.Models.First();
            ModelADto second = mapped.Models.Last();
            
            Assert.That(mapped.Id == largeObj.Id);
            Assert.That(first.Info == "Test1" && first.Something == 3f);
            Assert.That(second.Info == "Test2" && second.Something == 7f);
            
            Console.WriteLine(JsonSerializer.Serialize(mapped));
            Assert.That(first.Id == 7123 && second.Id == 7124);
        }
        
        
        private class TestProfile : Profile
        {
            public TestProfile()
            {
                CreateMap<ModelContainerA, ModelADto>()
                    .MapSourceMemberProperty(x => x.Model)
                    .ForMember(x => x.Id, opt => 
                        opt.MapFrom(y => y.Model.Id));
                
                
                CreateMap<ModelA, ModelADto>();
                CreateMap<LargeObjectA, LargeObjectADto>()
                    .ForMember(x => x.Models, opt => opt.MapFrom(y => y.ModelEntries));
            }
        }
    }
}