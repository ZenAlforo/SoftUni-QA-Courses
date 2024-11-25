
Dog smallDog = new Dog();
smallDog.Name = "Ricky";
smallDog.Breed = "Pincher";
smallDog.Age = 1;

Console.WriteLine(smallDog.Bark());

class Dog
{
    public string Name { get; set; }
    public string Breed { get; set; }
    public int Age {  get; set; }   

    public string Bark()
    {
        return $"{this.Name}, the {Breed} barks!";
    }
}
