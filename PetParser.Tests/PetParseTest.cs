using System.Collections.Generic;
using Xunit;
using Moq;
using PetParser.Models;
using PetParser.Services;
using PetParser.ViewModels;

namespace PetParser.Tests
{
    // Very basic demonstration of xUnit testing framework
    public class PetParserUnitTest
    {

        TestDataGenerator _dataGen;

        public PetParserUnitTest()
        {
            _dataGen = new TestDataGenerator();
        }

        [Fact]
        public async void TestCatsOnly()
        {
            TestIndividualLists(_dataGen.catsOnly, _dataGen.catsOnlyResult);
        }

        [Fact]
        public async void TestMixed()
        {
            TestIndividualLists(_dataGen.mixed, _dataGen.mixedResult);
        }

        [Fact]
        public async void TestDogsOnly()
        {
            TestIndividualLists(_dataGen.dogsOnly, _dataGen.dogsOnlyResult);
        }

        [Fact]
        public async void TestNoPets()
        {
            TestIndividualLists(_dataGen.noPets, _dataGen.noPetsResult);
        }


        private async void TestIndividualLists(IList<Person> a, IList<GenderPetViewModel> b)
        {
            var mockPetHttpHandler = new Mock<IPetHttpHandler>();
            mockPetHttpHandler
                .Setup(x => x.GetPetsAsync())
                .ReturnsAsync(a);

            PetParse testPet = new PetParse(mockPetHttpHandler.Object);
            var results = await testPet.ParsePetListAsync();

            // List class doesn't override Equals operator - comparing lists manually to save time
            for (int i = 0; i < b.Count; i++)
            {
                Assert.True(b[i].Gender == results[i].Gender);
                Assert.True(b[i].PetName.Count == results[i].PetName.Count);
                for (int j = 0; j < b[i].PetName.Count; j++)
                {
                    Assert.True(b[i].PetName[j] == results[i].PetName[j]);
                }
            }


        }
    }
}
