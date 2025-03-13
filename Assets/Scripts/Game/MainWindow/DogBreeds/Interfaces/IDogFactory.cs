namespace Game.MainWindow.DogBreeds
{
    public interface IDogFactory
    {
        IDogUIElement CreateDogUIElement(string order, string id, string name);
    }
}