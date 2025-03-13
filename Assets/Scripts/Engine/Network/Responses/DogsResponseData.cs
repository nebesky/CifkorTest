using System.Collections.Generic;

namespace Engine.Network.Responses
{
    public struct DogsResponse
    {
        public int Code;
        public List<DogBreedElement> Breeds;
    }

    public struct DogBreedElement
    {
        public string Id;
        public string Name;
    }
}