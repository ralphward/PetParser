using System.Collections;
using System.Collections.Generic;
using PetParser.Models;
using PetParser.ViewModels;

namespace PetParser.Tests
{
    public class TestDataGenerator
    {
        public IList<Person> catsOnly;
        public IList<Person> mixed;
        public IList<Person> dogsOnly;
        public IList<Person> noPets;
        public IList<GenderPetViewModel> catsOnlyResult;
        public IList<GenderPetViewModel> mixedResult;
        public IList<GenderPetViewModel> dogsOnlyResult;
        public IList<GenderPetViewModel> noPetsResult;

        public TestDataGenerator()
        {
            // Test Input data
            catsOnly = new List<Person>()
            {
                new Person
                {Name = "Bill",Age = 26,Gender = Sex.Male,Pets = new List<Pet>
                    {new Pet{Name = "Silvester",Type = PetType.Cat}}
                },
                new Person
                {Name = "Ted",Age = 28,Gender = Sex.Male,Pets = new List<Pet>
                    {new Pet{Name = "TopCat",Type = PetType.Cat}}
                }
            };

            mixed = new List<Person>()
            {
                new Person
                {Name = "Arthur Dent",Age = 26,Gender = Sex.Male,Pets = new List<Pet>
                    {new Pet{Name = "Marvin the Paranoid Android",Type = PetType.Cat}}
                },
                new Person
                {Name = "Trillian",Age = 28,Gender = Sex.Female,Pets = new List<Pet>
                    {new Pet{Name = "Fido",Type = PetType.Dog}}
                }
            };

            dogsOnly = new List<Person>()
            {
                new Person
                {Name = "Zaphod Beeblebrox",Age = 26,Gender = Sex.Male,Pets = new List<Pet>
                    {new Pet{Name = "Slartibartfast",Type = PetType.Dog}}
                },
                new Person
                {Name = "Ford Prefect",Age = 28,Gender = Sex.Male,Pets = new List<Pet>
                    {new Pet{Name = "Fenchurch",Type = PetType.Dog}}
                }
            };

            noPets = new List<Person>()
            {
                new Person {
                    Name = "Deep Thought",Age = 26,Gender = Sex.Male
                },
                new Person {
                    Name = "Ted",Age = 28,Gender = Sex.Male
                }
            };

            //Test output data for Comparison
            catsOnlyResult = new List<GenderPetViewModel>()
            {
                new GenderPetViewModel {
                    Gender = Sex.Male,
                    PetName = new List<string> { "Silvester", "TopCat" }
                },
                new GenderPetViewModel {
                    Gender = Sex.Female,
                    PetName = new List<string>(){}
                }
            };


            mixedResult = new List<GenderPetViewModel>()
            {
                new GenderPetViewModel {
                    Gender = Sex.Male,
                    PetName = new List<string> { "Marvin the Paranoid Android" }
                },
                new GenderPetViewModel {
                    Gender = Sex.Female,
                    PetName = new List<string>(){}
                }
            };


            dogsOnlyResult = new List<GenderPetViewModel>()
            {
                new GenderPetViewModel {
                    Gender = Sex.Male,
                    PetName = new List<string>()
                },
                new GenderPetViewModel {
                    Gender = Sex.Female,
                    PetName = new List<string>()
                }
            };

            noPetsResult = new List<GenderPetViewModel>()
            {
                new GenderPetViewModel {
                    Gender = Sex.Male,
                    PetName = new List<string>()
                },
                new GenderPetViewModel {
                    Gender = Sex.Female,
                    PetName = new List<string>()
                }
            };

    }

}

}
