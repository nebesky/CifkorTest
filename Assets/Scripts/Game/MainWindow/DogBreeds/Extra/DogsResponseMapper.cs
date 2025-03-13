using Engine.Network.Responses;

namespace Game.MainWindow.DogBreeds.Extra
{
    public static class DogsResponseMapper
    {
        public static DogsResponse MapToDogsResponse(DogsApiResponse apiResponse)
            => new DogsResponse()
            {
                Code = 200,
                Breeds = apiResponse.Data.ConvertAll(breed => new DogBreedElement
                {
                    Id = breed.Id,
                    Name = breed.Attributes.Name
                })
            };
    }
}